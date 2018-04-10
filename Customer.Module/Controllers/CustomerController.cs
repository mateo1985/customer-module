using System;

namespace Customer.Module.Controllers
{
    using Customer.Module.Common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Customer = Common.Models.Customer;

    /// <summary>
    /// This is the main Customer controller
    /// </summary>
    public class CustomerController: Controller
    {
        private ICustomerService customerService;
        private ILogger<CustomerController> logger;

        public CustomerController(ICustomerService customerService,
                                  ILogger<CustomerController> logger)
        {
            this.customerService = customerService;
            this.logger = logger;
        }

        [HttpGet]
        [ActionName("Index")]
        public IActionResult GetAll()
        {
            return new ObjectResult(this.customerService.GetAll());
        }

        [HttpDelete]
        [ActionName("Index")]
        public IActionResult DeleteCustomer(long id)
        {
            customerService.Remove(id);
            logger.LogInformation($"Customer removed id:{id}");
            return this.Ok();
        }

        [HttpPut]
        [ActionName("Index")]
        public IActionResult AddCustomer([FromBody]Customer customer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!customer.Id.HasValue)
            {
                return this.BadRequest(new { Id = "The Id field should be empty" });
            }

            this.customerService.Add(customer);
            logger.LogInformation($"Customer added");
            return this.Ok();
        }
        
        [HttpPost]
        [ActionName("Index")]
        public IActionResult Update([FromBody]Customer customer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!customer.Id.HasValue)
            {
                return this.BadRequest(new {Id = "The Id field is required"});
            }

            customerService.Update(customer);
            return this.Ok();
        }
    }
}
