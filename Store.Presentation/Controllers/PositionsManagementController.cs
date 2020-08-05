using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Application.Interaces;
using Store.Application.Services;
using Store.Domain.PositionDomain;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsManagementController : ControllerBase
    {
        private readonly IPositionService _service;
        private readonly ILogger<PositionsManagementController> _logger;

        /// <summary>
        /// CompanyManagementController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public PositionsManagementController(IPositionService service, ILogger<PositionsManagementController> logger)
        {
            _service = service ?? throw new NullReferenceException(nameof(service));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }
        /// <summary>
        /// GetAllCompanies
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-positions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            _logger.LogDebug("PositionsManagementController: GetAllCompanies() called");
            return Ok(_service.GetAll<PositionModel>());
        }
        /// <summary>
        /// GetCompanyById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-position-by-vehicule-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByVehiculeId(int id)
        {
            _logger.LogDebug("PositionsManagementController: GetByVehiculeId() called");
            return Ok(_service.GetByCriteria<PositionModel, PositionCriteria>(new PositionCriteria() { Id = id }));
        }
        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <param name="positionModel"></param>
        /// <returns></returns>
        [HttpPost("create-position")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] PositionModel positionModel)
        {
            _logger.LogDebug("PositionsManagementController: Create() called");
            if (positionModel == null) return BadRequest();
            return Ok(_service.Add<PositionModel>(positionModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="positionModel"></param>
        /// <returns></returns>
        [HttpPut("update-position")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] PositionModel positionModel)
        {
            _logger.LogDebug("PositionsManagementController: Update() called");
            if (positionModel == null) return BadRequest();
            return Ok(_service.Update<PositionModel>(positionModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("delete-position/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("PositionsManagementController: Delete() called");
            throw new NotImplementedException();
        }
       
    }
}
