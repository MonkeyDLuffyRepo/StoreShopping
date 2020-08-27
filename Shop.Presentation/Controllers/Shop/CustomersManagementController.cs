using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Application.Domains;
using Shop.Application.Interfaces;
using Store.API.Application.Services;

namespace Shop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersManagementController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly ILogger<CustomersManagementController> _logger;

        /// <summary>
        /// CompanyManagementController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public CustomersManagementController(ICustomerService service, ILogger<CustomersManagementController> logger)
        {
            _service = service ?? throw new NullReferenceException(nameof(service));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }
        /// <summary>
        /// GetAllCompanies
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-customers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            _logger.LogDebug("CustomersManagementController: GetAll() called");
            return Ok(_service.GetAll<CustomerModel>());
        }
        /// <summary>
        /// GetCompanyById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-customer-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            _logger.LogDebug("CustomersManagementController: GetById() called");
            return Ok(_service.GetByCriteria<CustomerModel, CustomerCriteria>(new CustomerCriteria() { Id = id }));
        }
        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        [HttpPost("create-customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CustomerModel customerModel)
        {
            _logger.LogDebug("CustomersManagementController: Create() called");
            if (customerModel == null) return BadRequest();
            return Ok(_service.Add<CustomerModel>(customerModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        [HttpPut("update-customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] CustomerModel customerModel)
        {
            _logger.LogDebug("CustomersManagementController: Update() called");
            if (customerModel == null) return BadRequest();
            return Ok(_service.Update<CustomerModel>(customerModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("delete-customer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("CustomersManagementController: Delete() called");
            throw new NotImplementedException();
        }
       
    }
}
