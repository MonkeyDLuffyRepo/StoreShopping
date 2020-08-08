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
    public class ShopStoreService : IShopStoreService
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;
        public ShopStoreService(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<T> GetAll<T>() where T : ShopStoreModel
        {
            var entities = _context.ShopStores
                  .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }
        public IEnumerable<T> GetByCriteria<T, C>(C criteria)
            where T : ShopStoreModel
            where C : ICriteriaBaseModel<ShopStore>
        {
            var entities = _context.ShopStores
                    .Where(criteria.Match())
                    .OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.CreationDate)
                    .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }
        public T GetById<T>(int id) where T : ShopStoreModel
        {
            throw new NotImplementedException();
        }
        public T Add<T>(T entity) where T : ShopStoreModel
        {
            var newEntity = _mapper.Map<ShopStore>(entity);
            newEntity.CreationDate = DateTime.Now;

            _context.ShopStores.Add(newEntity);
            _context.SaveChanges();

            return entity;
        }
      
        public T Update<T>(T entity) where T : ShopStoreModel
        {
            if (entity is null || entity.Id.Equals(0)) return null;
            var oldEntity = _context.ShopStores
                                             .FirstOrDefault(p => p.Id == entity.Id);
            if (oldEntity is null) return null;

            var updatedEntity = _mapper.Map<ShopStore>(entity);

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
    public class ShopStoreCriteria : ICriteriaBaseModel<ShopStore>
    {
        public int? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }
        public Expression<Func<ShopStore, bool>> Match()
        {
            var predicate = PredicateBuilder.New<ShopStore>(t => true);
            if (Id.HasValue) predicate = predicate.And(d => d.Id == Id);
            if (!string.IsNullOrEmpty(Name)) predicate = predicate.And(d => d.Name.StartsWith(Name));
            return predicate;
        }
    }
}
