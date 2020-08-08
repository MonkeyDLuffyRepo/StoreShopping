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
            throw new NotImplementedException();
        }
        public T Add<T>(T entity) where T : ProductModel
        {
            var newEntity = _mapper.Map<Product>(entity);
            newEntity.CreationDate = DateTime.Now;

            _context.Products.Add(newEntity);
            _context.SaveChanges();

            return entity;
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
}
