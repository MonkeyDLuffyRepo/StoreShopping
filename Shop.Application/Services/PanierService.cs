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
    public class PanierService : IPanierService
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        public PanierService(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public IEnumerable<T> GetAll<T>() where T : PanierModel
        {
            var entities = _context.Paniers
                  .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public IEnumerable<T> GetByCriteria<T, C>(C criteria)
            where T : PanierModel
            where C : ICriteriaBaseModel<Panier>
        {
            var entities = _context.Paniers
                   .Where(criteria.Match())
                   .OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.CreationDate)
                   .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public T GetById<T>(int id) where T : PanierModel
        {
            throw new NotImplementedException();
        }
        public T Add<T>(T entity) where T : PanierModel
        {
            var newEntity = _mapper.Map<Panier>(entity);
            newEntity.CreationDate = DateTime.Now;

            _context.Paniers.Add(newEntity);
            _context.SaveChanges();

            return entity;
        }
        public T Update<T>(T entity) where T : PanierModel
        {
            if (entity is null || entity.Id.Equals(0)) return null;
            var oldEntity = _context.Paniers
                                             .FirstOrDefault(p => p.Id == entity.Id);
            if (oldEntity is null) return null;

            var updatedEntity = _mapper.Map<Panier>(entity);

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
    public class PanierCriteria : ICriteriaBaseModel<Panier>
    {
        public int? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }

        public Expression<Func<Panier, bool>> Match()
        {
            var predicate = PredicateBuilder.New<Panier>(t => true);
            if (Id.HasValue) predicate = predicate.And(d => d.Id == Id);
            return predicate;
        }
    }
}
