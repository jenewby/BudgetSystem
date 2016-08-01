using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetSystem.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using BudgetSystem.Models.Helpers;

namespace BudgetSystem.Controllers
{
    public class HouseholdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Households
        public ActionResult Index()
        {
            return View(db.Household.ToList());
        }

        // GET: Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Households households = db.Household.Find(id);
            if (households == null)
            {
                return HttpNotFound();
            }
            return View(households);
        }

        // GET: Households/Create
        public ActionResult Create()
        {
                return View();
        }

        // POST: Households/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,Created,Updated")] Households households)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                db.Household.Add(households);
                user.HouseholdId = households.Id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(households);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Join([Bind(Include = "Id,name")] Households households)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                db.Household.Add(households);
                user.HouseholdId = households.Id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(households);
        }

        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Households households = db.Household.Find(id);
            if (households == null)
            {
                return HttpNotFound();
            }
            return View(households);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,Created,Updated")] Households households)
        {
            if (ModelState.IsValid)
            {
                db.Entry(households).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(households);
        }

        // GET: Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Households households = db.Household.Find(id);
            if (households == null)
            {
                return HttpNotFound();
            }
            return View(households);
        }

        [AuthorizedHouseholdRequired]
        public ActionResult Dashboard()
        {
            return View();
        }

        // GET: Households/Invite/5
        public ActionResult Invite()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Invite([Bind(Include = "Id, HouseholdId, email")]Invitations invitation)
        {
            if (ModelState.IsValid)
            {
                var usrHouseholdId = db.Users.Find(User.Identity.GetUserId()).HouseholdId;
                var usr = db.Users.Find(User.Identity.GetUserId());

                invitation.HouseholdId = (int)usrHouseholdId;
                db.Invitation.Add(invitation);
                db.SaveChanges();


             


                var callbackUrl = Url.Action("Create");
                //await SendEmailAsync(usr.Id, "Join this household", "Please click the link and enter your household Id to join your household.  <a href=\"" + callbackUrl + "\">here</a>");

                //var Email = new EmailService();
                //var message = new IdentityMessage();
                // the above code is the same as the below just done differently

                EmailService es = new EmailService();
                IdentityMessage im = new IdentityMessage();
                im.Destination = invitation.email;
                im.Subject = "Join this household";
                im.Body ="Please click the link and enter your household Id to join your household.  <a href=\"" + callbackUrl + "\">here</a>";

                await es.SendAsync(im);
                return RedirectToAction("Dashboard", "Households");
                //if (user == null)
                //{
                //    // Don't reveal that the user does not exist or is not confirmed
                //    return View("ForgotPasswordConfirmation");
                //}

                //// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //// Send an email with this link
                //var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id }, protocol: Request.Url.Scheme);
                //await Microsoft.AspNet.Identity.UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                //return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Households households = db.Household.Find(id);
            db.Household.Remove(households);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
