using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using Store.Application.Interaces;
using Store.Domain.SharedDomain;
using Store.Domain.VehiculeDomain;
using Store.Infrastructure;
using Store.Persistance.Contexts;
using Store.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services
{
    public class VehiculeService : IVehiculeService
    {
        private readonly STOREContext _context;
        private readonly IMapper _mapper;
        public VehiculeService(STOREContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<T> GetAll<T>() where T : VehiculeModel
        {
            var entities = _context.People
                  .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }
        public IEnumerable<T> GetByCriteria<T, C>(C criteria)
            where T : VehiculeModel
            where C : ICriteriaBaseModel<Vehicule>
        {
            var entities = _context.Vehicules
                    .Where(criteria.Match())
                    .OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.CreationDate)
                    .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }
        public T GetById<T>(int id) where T : VehiculeModel
        {
            throw new NotImplementedException();
        }
        public T Add<T>(T entity) where T : VehiculeModel
        {
            var newEntity = _mapper.Map<Vehicule>(entity);
            newEntity.CreationDate = DateTime.Now;

            _context.Vehicules.Add(newEntity);
            _context.SaveChanges();

            return entity;
        }
        public T AddState<T>(T entity) where T : VehiculeStateModel
        {
            var newEntity = _mapper.Map<VehiculeState>(entity);
            newEntity.CreationDate = DateTime.Now;

            _context.VehiculeStates.Add(newEntity);
            _context.SaveChanges();

            return entity;
        }
        public T Update<T>(T entity) where T : VehiculeModel
        {
            if (entity is null || entity.Id.Equals(0)) return null;
            var oldEntity = _context.Vehicules
                                             .FirstOrDefault(p => p.Id == entity.Id);
            if (oldEntity is null) return null;

            var updatedEntity = _mapper.Map<Vehicule>(entity);

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
    public class VehiculeCriteria : ICriteriaBaseModel<Vehicule>
    {
        public int? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }
        public Expression<Func<Vehicule, bool>> Match()
        {
            var predicate = PredicateBuilder.New<Vehicule>(t => true);
            if (Id.HasValue) predicate = predicate.And(d => d.Id == Id);
            if (!string.IsNullOrEmpty(Name)) predicate = predicate.And(d => d.Name.StartsWith(Name));
            return predicate;
        }
    }
}
