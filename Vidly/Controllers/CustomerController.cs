using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;

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
        


        [Route("customer/customerdetail/{customerID}")]
        public ActionResult CustomerDetail(int customerID)
        {
            var customerDetail = new Customer();

            customerDetail = this._context.Customers.SingleOrDefault(x => x.CustomerID == customerID);

            var viewModel = new CustomerViewModel
            {
                Customer = customerDetail, 
                MembershipType = _context.MembershipTypes.ToList()
            };

            

            if (customerDetail == null)
            {
                return Content("No customer found");
            }
            else
            {
                return View("CustomerForm", viewModel);
            }
            
        }

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var customerViewModel = new CustomerViewModel();
            customerViewModel.MembershipType = membershipTypes;

            return View("CustomerForm", customerViewModel); 
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.CustomerID == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.CustomerID == customer.CustomerID);
                customerInDB.CustomerName = customer.CustomerName; 
                customerInDB.DateOfBirth = customer.DateOfBirth; 
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter; 
            }
            _context.SaveChanges();
            return RedirectToAction("CustomerList", "Customer");
        }
    }
}