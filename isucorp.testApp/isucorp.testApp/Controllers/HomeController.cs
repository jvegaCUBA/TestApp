namespace isucorp.testApp.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using isucorp.testApp.DataBaseModel;
    using isucorp.testApp.Models;
    using isucorp.testApp.Utilities;

    public class HomeController : Controller
    {
        private readonly DataContext context = new DataContext();

        public ActionResult Index(string sortExp, int page = 1, int rows = 10)
        {
            var sorter = EntitySorter<Reservation>.SortExpression(!string.IsNullOrEmpty(sortExp) ? sortExp : "CreatedDate desc");
            long totalRecords;
            var reservations = sorter.Sort(this.context.Reservations)
                 .GetPage(page, rows, out totalRecords)
                 .ToList();

            this.ViewBag.totalRecords = totalRecords;
            this.ViewBag.pagesCount = (totalRecords / rows) + (totalRecords % rows) > 0 ? 1 : 0;
            this.ViewBag.currentPage = page;
            return this.View(reservations);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reservation = this.context.Reservations.Find(id);
            if (reservation == null)
            {
                return this.HttpNotFound();
            }
            var contacTypes =
                this.context.ContactTypes.ToList()
                    .Select(
                        m =>
                        new SelectListItem
                        {
                            Text = m.Name,
                            Value = m.Id.ToString(),
                            Selected = m.Id == reservation.ContactTypeId
                        });
            this.ViewBag.ContacTypesList = contacTypes;
            return this.View(reservation);
        }

        [HttpPost]
        public ActionResult Edit(Reservation reservation)
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
                this.context.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(reservation);
        }

        public ActionResult Create()
        {
            var contacTypes =
                this.context.ContactTypes.ToList()
                    .Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
            this.ViewBag.ContacTypesList = contacTypes;
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            if (this.ModelState.IsValid)
            {
                reservation.CreatedDate = DateTime.Now;
                this.context.Reservations.Add(reservation);
                this.context.Entry(reservation).State = EntityState.Added;

                this.context.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(reservation);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
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
            this.context.SaveChanges();

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult SetRanking([Bind(Include = "ReservationId,Ranking")]RankingModel rankingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new
                {
                    success = false
                });
            }
            var reservation = this.context.Reservations.Find(rankingModel.ReservationId);
            if (reservation == null)
            {
                return
                    this.Json(
                        new { success = false, this.HttpNotFound().StatusCode, this.HttpNotFound().StatusDescription });
            }
            reservation.Ranking = rankingModel.Ranking;
            this.context.Entry(reservation).State = EntityState.Modified;
            this.context.SaveChanges();

            return this.Json(new { success = true, ranking = reservation.Ranking });
        }

        [HttpPost]
        public JsonResult SetToFavourite([Bind(Include = "ReservationId,Favourite")] FavouriteModel favouriteModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new
                {
                    success = false
                });
            }

            var reservation = this.context.Reservations.Find(favouriteModel.ReservationId);

            if (reservation == null)
            {
                return
                    this.Json(
                        new { success = false, this.HttpNotFound().StatusCode, this.HttpNotFound().StatusDescription });
            }
            reservation.IsFavourite = favouriteModel.Favourite;
            this.context.Entry(reservation).State = EntityState.Modified;
            this.context.SaveChanges();

            return this.Json(new { success = true, favourite = reservation.IsFavourite });
        }
    }
}