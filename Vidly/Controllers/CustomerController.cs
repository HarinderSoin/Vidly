using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    using Vidly.Models;

    public class CustomerController : Controller
    {
        // GET: Customer

        private ApplicationDbContext _context;

        public CustomerController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        public ActionResult CustomerList()
        {
            var customers = this._context.Customers.Include(c => c.MembershipType).ToList();
            return View("CustomerList", customers);
        }
        
         /*
        private IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customer = new List<Customer>();
            customer.Add(new Customer() {CustomerID = 1, CustomerName = "John Smith"});
            customer.Add(new Customer() {CustomerID = 2, CustomerName = "Mary Williams"});
            return customer; 
        }
        */

        [Route("customer/customerdetail/{customerID}")]
        public ActionResult CustomerDetail(int customerID)
        {
            var customerDetail = new Customer();
            customerDetail = this._context.Customers.SingleOrDefault(x => x.CustomerID == customerID);

            if (customerDetail == null)
            {
                return Content("No customer found");
            }
            else
            {
                return View("CustomerDetail", customerDetail);
            }
            
        }
    }
}