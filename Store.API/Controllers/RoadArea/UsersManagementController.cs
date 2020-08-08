using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.API.Application.Interaces;
using Store.API.Application.Services;
using Store.API.Domains.UserModels;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersManagementController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UsersManagementController> _logger;

        /// <summary>
        /// CompanyManagementController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public UsersManagementController(IUserService service, ILogger<UsersManagementController> logger)
        {
            _service = service ?? throw new NullReferenceException(nameof(service));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }
        /// <summary>
        /// GetAllCompanies
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            _logger.LogDebug("UsersManagementController: GetAll() called");
            return Ok(_service.GetAll<UserModel>());
        }
        /// <summary>
        /// GetCompanyById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-user-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByUserId(int id)
        {
            _logger.LogDebug("UsersManagementController: GetByUserId() called");
            return Ok(_service.GetByCriteria<UserModel, UserCriteria>(new UserCriteria() { Id = id }));
        }
        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost("create-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] UserModel userModel)
        {
            _logger.LogDebug("UsersManagementController: Create() called");
            if (userModel == null) return BadRequest();
            return Ok(_service.Add<UserModel>(userModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPut("update-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] UserModel userModel)
        {
            _logger.LogDebug("UsersManagementController: Update() called");
            if (userModel == null) return BadRequest();
            return Ok(_service.Update<UserModel>(userModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("delete-user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("UsersManagementController: Delete() called");
            throw new NotImplementedException();
        }

    }
}
