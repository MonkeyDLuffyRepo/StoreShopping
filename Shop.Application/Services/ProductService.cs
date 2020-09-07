using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using Shop.Application.Domains;
using Shop.Application.Infrastructures;
using Shop.Application.Interfaces;
using Shop.Persistance.Contexts;
using Shop.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Store.API.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        public ProductService(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region public product services
        public IEnumerable<T> GetAll<T>() where T : ProductModel
        {
            var entities = _context.Products
                  .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }
        public IEnumerable<T> GetByCriteria<T, C>(C criteria)
            where T : ProductModel
            where C : ICriteriaBaseModel<Product>
        {
            var entities = _context.Products
                    .Where(criteria.Match())
                    .OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.CreationDate)
                    .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }
        public T GetById<T>(int id) where T : ProductModel
        {
            var entity = _context.Products
                    .FirstOrDefault(e => e.Id == id);

            return _mapper.Map<T>(entity);
        }
        public T Add<T>(T entity) where T : ProductModel
        {
            var newEntity = _mapper.Map<Product>(entity);
            newEntity.CreationDate = DateTime.Now;

            _context.Products.Add(newEntity);
            _context.SaveChanges();

            return entity;
        }
        public void AddList<T>(IEnumerable<T> entities) where T : ProductModel
        {
            foreach(var entity in entities)
            {
                Add<T>(entity);
            }
        }
        public T Update<T>(T entity) where T : ProductModel
        {
            if (entity is null || entity.Id.Equals(0)) return null;
            var oldEntity = _context.Products
                                             .FirstOrDefault(p => p.Id == entity.Id);
            if (oldEntity is null) return null;

            var updatedEntity = _mapper.Map<Product>(entity);

            var changedFields = ObjectsComparer.GetChangedFields(oldEntity, updatedEntity);

            oldEntity.InjectFrom<AvoidNullProps>(updatedEntity);
            _context.Entry(oldEntity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region public related services
        public IEnumerable<T> GetRelatedData<T>(BaseModel entity) where T : BaseModel
        {
            return (IEnumerable<T>) RelatedData(entity);
        }
        public IEnumerable<T> GetAllCategories<T>() where T : ProductCategoryModel
        {
            var entities = _context.Categories
                   .Where(e => e.Enable)
                   .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public T GetCategoryById<T>(int id) where T : ProductCategoryModel
        {
            var entity = _context.Categories
                   .FirstOrDefault(e => e.Id == id);

            return _mapper.Map<T>(entity);
        }

        public T AddCategory<T>(T entity) where T : ProductCategoryModel
        {
            var categoryCriteria = new CategoryCriteria() { Name = entity.Name };
            if (AnyCategory(categoryCriteria)) return null;

            var newEntity = _mapper.Map<Category>(entity);
            newEntity.CreationDate = DateTime.Now;

            _context.Categories.Add(newEntity);
            _context.SaveChanges();

            return _mapper.Map<T>(newEntity);
        }

        private bool AnyCategory(CategoryCriteria categoryCriteria)
        {
            return _context.Categories.Any(categoryCriteria.Match());
        }

        public void ToggleVisibility(int id)
        {
            var entity = _context.Categories
                  .FirstOrDefault(e => e.Id == id);

            if (entity is null) return;
            entity.Enable = !entity.Enable;
            _context.SaveChanges();
        }
        #endregion

        #region private services
       
        private IEnumerable<BaseModel> RelatedData(BaseModel entity)
        {
            dynamic entities;
            switch (entity.type)
            {
                case RelatedProductDataEnum.CATEGORY:
                    entities = _context.Categories.ToList();
                    break;
                case RelatedProductDataEnum.COLOR:
                    entities = _context.Colors.ToList();
                    break;
                case RelatedProductDataEnum.COUNTRY:
                    entities = _context.Countries.ToList();
                    break;
                case RelatedProductDataEnum.CONSERVATION:
                    entities = _context.Conservations.ToList();
                    break;
                case RelatedProductDataEnum.ORINALITY:
                    entities = _context.Originalities.ToList();
                    break;
                case RelatedProductDataEnum.REGION:
                    entities = _context.Regions.ToList();
                    break;
                case RelatedProductDataEnum.TASTE:
                    entities = _context.Tastes.ToList();
                    break;
                case RelatedProductDataEnum.VINTAGE:
                    entities = _context.Vintages.ToList();
                    break;
                case RelatedProductDataEnum.VOLUME:
                    entities = _context.Volumes.ToList();
                    break;
                default:
                    return entities = null;
                    
            }
            return _mapper.Map<IEnumerable<BaseModel>>(entities);

        }

       
        #endregion

    }

    public class ProductCriteria : ICriteriaBaseModel<Product>
    {
        public int? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }
        public Expression<Func<Product, bool>> Match()
        {
            var predicate = PredicateBuilder.New<Product>(t => true);
            if (Id.HasValue) predicate = predicate.And(d => d.Id == Id);
            return predicate;
        }
    }

    public class CategoryCriteria : ICriteriaBaseModel<Category>
    {
        public int? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }
        public Expression<Func<Category, bool>> Match()
        {
            var predicate = PredicateBuilder.New<Category>(t => true);
            if (Id.HasValue) predicate = predicate.And(d => d.Id == Id);
            if (!string.IsNullOrEmpty(Name)) predicate = predicate.And(d => d.Name.ToLower() == Name.ToLower());
            return predicate;
        }
    }
}
