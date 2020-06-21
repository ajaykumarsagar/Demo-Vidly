using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customersDtos = _context.Customers
                .Include(c=>c.MembershipType)
                .ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customersDtos);
            //return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        //Get /api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customers == null)
                //  throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customers));
        }
        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customersDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customersDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customersDto.Id = customer.Id;


            return Created(new Uri(Request.RequestUri +"/"+ customer.Id), customersDto);
           // return customersDto;
        }

        //PUT/api/customerss/1
        [HttpPut]
        public void UpdateCustomers(int id,CustomerDto customers)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customersInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customersInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customers,customersInDb);

            //customersInDb.Name=customers.Name;
            //customersInDb.Birthdate = customers.Birthdate;
            //customersInDb.IsSubscribeToNewsletter = customers.IsSubscribeToNewsletter;
            //customersInDb.MembershipTypeId = customers.MembershipTypeId;

            _context.SaveChanges();
        }
        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customersInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customersInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customersInDb);
            _context.SaveChanges();
        }

    }
}
