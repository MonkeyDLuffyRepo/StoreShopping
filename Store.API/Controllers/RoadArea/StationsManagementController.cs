using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.API.Application.Interaces;
using Store.API.Application.Services;
using Store.API.Domains.StationModels;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsManagementController : ControllerBase
    {
        private readonly IStationService _service;
        private readonly ILogger<StationsManagementController> _logger;

        /// <summary>
        /// CompanyManagementController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public StationsManagementController(IStationService service, ILogger<StationsManagementController> logger)
        {
            _service = service ?? throw new NullReferenceException(nameof(service));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }
        /// <summary>
        /// GetAllCompanies
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-stations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            _logger.LogDebug("StationsManagementController: GetAll() called");
            return Ok(_service.GetAll<StationModel>());
        }
        /// <summary>
        /// GetCompanyById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-station-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByStationId(int id)
        {
            _logger.LogDebug("StationsManagementController: GetByStationId() called");
            return Ok(_service.GetByCriteria<StationModel, StationCriteria>(new StationCriteria() { Id = id }));
        }
        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <param name="stationModel"></param>
        /// <returns></returns>
        [HttpPost("create-station")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] StationModel stationModel)
        {
            _logger.LogDebug("StationsManagementController: Create() called");
            if (stationModel == null) return BadRequest();
            return Ok(_service.Add<StationModel>(stationModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="stationModel"></param>
        /// <returns></returns>
        [HttpPut("update-station")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] StationModel stationModel)
        {
            _logger.LogDebug("StationsManagementController: Update() called");
            if (stationModel == null) return BadRequest();
            return Ok(_service.Update<StationModel>(stationModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("delete-station/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("StationsManagementController: Delete() called");
            throw new NotImplementedException();
        }
    }
}
