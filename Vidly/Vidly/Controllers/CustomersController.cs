using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            { 











                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
            return View("New", viewModel);
           }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
                
            //if (customer.Id == 0)
            //{
            //    _context.Customers.Add(customer);
            //    _context.SaveChanges();
            //}
            else
            {
                var customerDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerDb,"",new string[] { "Name","Email"});
                customerDb.Name = customer.Name;
                customerDb.Birthdate = customer.Birthdate;
                customerDb.MembershipTypeId = customer.MembershipTypeId;
                customerDb.IsSubscribeToNewsletter = customer.IsSubscribeToNewsletter;
                _context.SaveChanges();
            }

           
            return RedirectToAction("Index", "Customers");
       }
        public ViewResult Index()
        {
            //  var customers = _context.Customers.Include(c =>c.MembershipType).ToList();

            //  return View(customers);
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer=customer,
                MembershipTypes=_context.MembershipTypes.ToList()
            };
            return View("New",viewModel);
        }
        //private IEnumerable<Customer> GetCustomer()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer {Id=1,Name="Johan Smith" },
        //         new Customer {Id=2,Name="Mary Williams" },
        //    };
        //}
    }
}