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
    public class ProductsManagementController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductsManagementController> _logger;

        /// <summary>
        /// CompanyManagementController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public ProductsManagementController(IProductService service, ILogger<ProductsManagementController> logger)
        {
            _service = service ?? throw new NullReferenceException(nameof(service));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }
        #region products endpoints
        /// <summary>
        /// GetAllCompanies
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            _logger.LogDebug("ProductsManagementController: GetAll() called");
            return Ok(_service.GetAll<ProductModel>());
        }
        /// <summary>
        /// GetAllCompanies
        /// </summary>
        /// <returns></returns>
        [HttpPost("get-related-data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRelatedData([FromBody] BaseModel type )
        {
            _logger.LogDebug("ProductsManagementController: GetRelatedData() called");
            return Ok(_service.GetRelatedData<BaseModel>(type));
        }
        /// <summary>
        /// GetCompanyById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-product-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            _logger.LogDebug("ProductsManagementController: GetById() called");
            return Ok(_service.GetByCriteria<ProductModel, ProductCriteria>(new ProductCriteria() { Id = id }));
        }
        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        [HttpPost("create-product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] ProductModel productModel)
        {
            _logger.LogDebug("ProductsManagementController: Create() called");
            if (productModel == null) return BadRequest();
            return Ok(_service.Add<ProductModel>(productModel));
        }
        /// <summary>
        /// CreateCompany
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        [HttpPost("create-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateAll([FromBody] IEnumerable<ProductModel> productsModel)
        {
            _logger.LogDebug("ProductsManagementController: Create() called");
            if (productsModel == null) return BadRequest();
            _service.AddList<ProductModel>(productsModel);
            return Ok();
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        [HttpPut("update-product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] ProductModel productModel)
        {
            _logger.LogDebug("ProductsManagementController: Update() called");
            if (productModel == null) return BadRequest();
            return Ok(_service.Update<ProductModel>(productModel));
        }
        /// <summary>
        /// UpdateCompany
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("delete-product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("ProductsManagementController: Delete() called");
            throw new NotImplementedException();
        }
        #endregion
        #region categories endpoints
        /// <summary>
        /// GetAllCategories
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-categoreis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategoriesAll()
        {
            _logger.LogDebug("ProductsManagementController: GetCategoriesAll() called");
            return Ok(_service.GetAllCategories<ProductCategoryModel>());
        }
        /// <summary>
        /// GetCategoryById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-category-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategoryById(int id)
        {
            _logger.LogDebug("ProductsManagementController: GetCategoryById() called");
            return Ok(_service.GetCategoryById<ProductCategoryModel>(id));
        }
        /// <summary>
        /// CreateCategory
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        [HttpPost("create-category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCategory([FromBody] ProductCategoryModel categoryModel)
        {
            _logger.LogDebug("ProductsManagementController: CreateCategory() called");
            if (categoryModel == null) return BadRequest();
            return Ok(_service.AddCategory<ProductCategoryModel>(categoryModel));
        }
        /// <summary>
        /// CreateCategory
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        [HttpPut("update-category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCategory([FromBody] ProductCategoryModel categoryModel)
        {
            _logger.LogDebug("ProductsManagementController: CreateCategory() called");
            if (categoryModel == null) return BadRequest();
            return Ok(_service.UpdateCategory<ProductCategoryModel>(categoryModel));
        }
        /// <summary>
        /// GetCategoryById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("toggle-category-visiblity/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ToggleCategory(int id)
        {
            _logger.LogDebug("ProductsManagementController: ToggleCategory() called");
            _service.ToggleVisibility(id);
            return Ok();
        }
        #endregion

    }
}
