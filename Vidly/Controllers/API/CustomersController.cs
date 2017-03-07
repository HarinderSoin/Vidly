using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get /api/customers
        public  IHttpActionResult GetCustomers()
        {
            var customerDTO = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customerDTO);
        }

        //Get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerID == id); 
            if (customer ==null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        //Post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if(!ModelState.IsValid) 
                return BadRequest();
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDTO.CustomerID = customer.CustomerID;
            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerID), customerDTO); 
        }

        //Put /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var customerInDB = _context.Customers.SingleOrDefault(c => c.CustomerID == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var customer = Mapper.Map(customerDTO, customerInDB);
            _context.SaveChanges();
            return Ok(Mapper.Map(customerInDB, customerDTO)); 
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(c => c.CustomerID == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();

            return Ok();
        }

    }

}
