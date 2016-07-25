namespace isucorp.testApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using isucorp.testApp.DataBaseModel;
    using isucorp.testApp.Models;
    using isucorp.testApp.Utilities;

    using Microsoft.Ajax.Utilities;

    public class HomeController : Controller
    {
        private readonly DataContext context = new DataContext();

        public async Task<ActionResult> Index(string sortExp, int page = 1, int rows = 10)
        {
            if (!string.IsNullOrEmpty(sortExp))
            {
              return this.RedirectToAction("OrderBy", new { sortExp, page, rows });
            }
            long totalRecords;
            var reservations = await this.context.Reservations
                .OrderByDescending(m => m.CreatedDate)
                .GetPage(page, rows, out totalRecords).ToListAsync();

            this.ViewBag.totalRecords = totalRecords;
            this.ViewBag.pagesCount = (totalRecords / rows) + (totalRecords % rows) > 0 ? 1 : 0;
            this.ViewBag.currentPage = page;
            return this.View(reservations);
        }

        public async Task<ActionResult> OrderBy(string sortExp, int page = 1, int rows = 10)
        {
            var sorter = EntitySorter<Reservation>.SortExpression(!string.IsNullOrEmpty(sortExp) ? sortExp : "CreatedDate desc");
            long totalRecords;
            var list = await sorter.Sort(this.context.Reservations)
                .GetPage(page, rows, out totalRecords).ToListAsync();
            this.ViewBag.totalRecords = totalRecords;
            this.ViewBag.pagesCount = (totalRecords / rows) + (totalRecords % rows) > 0 ? 1 : 0;
            this.ViewBag.currentPage = page;
            return this.View("Index", list);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reservation = await this.context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return this.HttpNotFound();
            }
            var contacTypes = await this.ContacTypesListItems(reservation.ContactType.Id);
            this.ViewBag.ContacTypesList = contacTypes;
            return this.View(reservation);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Reservation reservation)
        {
            if (this.ModelState.IsValid)
            {
                var reservationContext = this.context.Reservations.Attach(reservation);
                if (reservationContext == null)
                {
                    return this.HttpNotFound();
                }

                reservationContext.ModifiedDate = DateTime.Now;
                this.context.Entry(reservation).State = EntityState.Modified;
                bool saveFailed;
                do
                {
                    saveFailed = false;
                    try
                    {
                        await this.context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update original values from the database 
                        var entry = ex.Entries.Single();
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());

                    }
                } while (saveFailed);


                return this.RedirectToAction("Index");
            }
            return this.View(reservation);
        }

        public async Task<ActionResult> Create()
        {
            var contacTypes = await this.ContacTypesListItems();
            this.ViewBag.ContacTypesList = contacTypes;
            return this.View();
        }

        private async Task<IEnumerable<SelectListItem>> ContacTypesListItems(int selectedId = -1)
        {
            var contacTypesEntities = await this.context.ContactTypes.ToListAsync();
            var contacTypes = contacTypesEntities.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString(), Selected = m.Id == selectedId });
            return contacTypes;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Reservation reservation)
        {
            if (this.ModelState.IsValid)
            {
                reservation.CreatedDate = DateTime.Now;
                this.context.Reservations.Add(reservation);
                this.context.Entry(reservation).State = EntityState.Added;

                await this.context.SaveChangesAsync();
                return this.RedirectToAction("Index");
            }
            return this.View(reservation);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = this.context.Reservations.Find(id);
            if (entity == null)
            {
                return this.HttpNotFound();
            }
            this.context.Reservations.Remove(entity);
            await this.context.SaveChangesAsync();

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> SetRanking([Bind(Include = "ReservationId,Ranking")]RankingModel rankingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new
                {
                    success = false
                });
            }
            var reservation = await this.context.Reservations.FindAsync(rankingModel.ReservationId);
            if (reservation == null)
            {
                return
                    this.Json(
                        new { success = false, this.HttpNotFound().StatusCode, this.HttpNotFound().StatusDescription });
            }
            reservation.Ranking = rankingModel.Ranking;
            this.context.Entry(reservation).State = EntityState.Modified;
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    // Update original values from the database 
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());

                }
            } while (saveFailed);

            return this.Json(new { success = true, ranking = reservation.Ranking });
        }

        [HttpPost]
        public async Task<JsonResult> SetToFavourite([Bind(Include = "ReservationId,Favourite")] FavouriteModel favouriteModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new
                {
                    success = false
                });
            }

            var reservation = await this.context.Reservations.FindAsync(favouriteModel.ReservationId);

            if (reservation == null)
            {
                return
                    this.Json(
                        new { success = false, this.HttpNotFound().StatusCode, this.HttpNotFound().StatusDescription });
            }
            reservation.IsFavourite = favouriteModel.Favourite;
            this.context.Entry(reservation).State = EntityState.Modified;
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    await this.context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    // Update original values from the database 
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());

                }
            } while (saveFailed);
            return this.Json(new { success = true, favourite = reservation.IsFavourite });
        }
    }
}