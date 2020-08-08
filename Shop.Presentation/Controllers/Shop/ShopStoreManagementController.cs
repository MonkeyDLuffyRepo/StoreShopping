using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ShopStoreManagementController : ControllerBase
    {
        private readonly IShopStoreService _service;
        private readonly ILogger<ShopStoreManagementController> _logger;

        /// <summary>
        /// CompanyManagementController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public ShopStoreManagementController(IShopStoreService service, ILogger<ShopStoreManagementController> logger)
        {
            _service = service ?? throw new NullReferenceException(nameof(service));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }
        /// <summary>
        /// GetAllCompanies
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-stores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            _logger.LogDebug("ShopStoreManagementController: GetAll() called");
            return Ok(_service.GetAll<ShopStoreModel>());
        }
        /// <summary>
        /// GetCompanyById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-store-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            _logger.LogDebug("ShopStoreManagementController: GetById() called");
            return Ok(_service.GetByCriteria<ShopStoreModel, ShopStoreCriteria>(new ShopStoreCriteria() { Id = id }));
        }
        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <param name="shopStoreModelModel"></param>
        /// <returns></returns>
        [HttpPost("create-store")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] ShopStoreModel shopStoreModelModel)
        {
            _logger.LogDebug("ShopStoreManagementController: Create() called");
            if (shopStoreModelModel == null) return BadRequest();
            return Ok(_service.Add<ShopStoreModel>(shopStoreModelModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="VehiculeModel"></param>
        /// <returns></returns>
        [HttpPut("update-store")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] ShopStoreModel shopStoreModelModel)
        {
            _logger.LogDebug("ShopStoreManagementController: Update() called");
            if (shopStoreModelModel == null) return BadRequest();
            return Ok(_service.Update<ShopStoreModel>(shopStoreModelModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("delete-store/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("ShopStoreManagementController: Delete() called");
            throw new NotImplementedException();
        }

    }
}
