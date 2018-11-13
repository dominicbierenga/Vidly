using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.DAL;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyContext _context;

        public CustomersController()
        {
            _context = new VidlyContext();
        }

        protected override void Dispose (bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Route("customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        // GET: Customer with ID
        [Route("customers/{id}")]
        public ActionResult Details(int? id)
        {
            try
            {
                var customer = _context.Customers.Include(c => c.MembershipType).Single(c => c.Id == id);
                return View(customer);
            }

            catch (InvalidOperationException)
            {
                Customer customer = null;
                return View(customer);
            }
        }
    }
}