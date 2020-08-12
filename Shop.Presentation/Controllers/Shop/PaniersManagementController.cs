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
    public class PaniersManagementController : ControllerBase
    {
        private readonly IPanierService _service;
        private readonly ILogger<PaniersManagementController> _logger;

        /// <summary>
        /// CompanyManagementController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public PaniersManagementController(IPanierService service, ILogger<PaniersManagementController> logger)
        {
            _service = service ?? throw new NullReferenceException(nameof(service));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }
        /// <summary>
        /// GetAllCompanies
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-paniers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            _logger.LogDebug("PaniersManagementController: GetAll() called");
            return Ok(_service.GetAll<PanierModel>());
        }
        /// <summary>
        /// GetCompanyById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-panier-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            _logger.LogDebug("PaniersManagementController: GetById() called");
            return Ok(_service.GetByCriteria<PanierModel, PanierCriteria>(new PanierCriteria() { Id = id }));
        }
        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <param name="panierModel"></param>
        /// <returns></returns>
        [HttpPost("create-panier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] PanierModel panierModel)
        {
            _logger.LogDebug("PaniersManagementController: Create() called");
            if (panierModel == null) return BadRequest();
            return Ok(_service.Add<PanierModel>(panierModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="panierModel"></param>
        /// <returns></returns>
        [HttpPut("update-panier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] PanierModel panierModel)
        {
            _logger.LogDebug("PaniersManagementController: Update() called");
            if (panierModel == null) return BadRequest();
            return Ok(_service.Update<PanierModel>(panierModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("delete-panier/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("PaniersManagementController: Delete() called");
            throw new NotImplementedException();
        }
    }
}
