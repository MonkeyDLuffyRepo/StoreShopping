using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Application.Interaces;
using Store.Application.Services;
using Store.Domain.VehiculeDomain;

namespace Store.Presentation.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculeManagementController : ControllerBase
    {
        private readonly IVehiculeService _service;
        private readonly ILogger<VehiculeManagementController> _logger;

        /// <summary>
        /// CompanyManagementController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public VehiculeManagementController(IVehiculeService service, ILogger<VehiculeManagementController> logger)
        {
            _service = service ?? throw new NullReferenceException(nameof(service));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }
        /// <summary>
        /// GetAllCompanies
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-vehicules")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            _logger.LogDebug("VehiculeManagementController: GetAll() called");
            return Ok(_service.GetAll<VehiculeModel>());
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
            _logger.LogDebug("VehiculeManagementController: GetByVehiculeId() called");
            return Ok(_service.GetByCriteria<VehiculeModel, VehiculeCriteria>(new VehiculeCriteria() { Id = id }));
        }
        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <param name="vehiculeModel"></param>
        /// <returns></returns>
        [HttpPost("create-vehicule")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] VehiculeModel vehiculeModel)
        {
            _logger.LogDebug("VehiculeManagementController: Create() called");
            if (vehiculeModel == null) return BadRequest();
            return Ok(_service.Add<VehiculeModel>(vehiculeModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="VehiculeModel"></param>
        /// <returns></returns>
        [HttpPut("update-vehicule")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] VehiculeModel vehiculeModel)
        {
            _logger.LogDebug("VehiculeManagementController: Update() called");
            if (vehiculeModel == null) return BadRequest();
            return Ok(_service.Update<VehiculeModel>(vehiculeModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("delete-vehicule/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("VehiculeManagementController: Delete() called");
            throw new NotImplementedException();
        }

    }
}
