using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using Store.Application.Interaces;
using Store.Domain.SharedDomain;
using Store.Domain.StationDomain;
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
    public class StationService : IStationService
    {
        private readonly STOREContext _context;
        private readonly IMapper _mapper;

        public StationService(STOREContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public IEnumerable<T> GetAll<T>() where T : StationModel
        {
            var entities = _context.Stations
                  .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public IEnumerable<T> GetByCriteria<T, C>(C criteria)
            where T : StationModel
            where C : ICriteriaBaseModel<Station>
        {
            var entities = _context.Stations
                   .Where(criteria.Match())
                   .OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.CreationDate)
                   .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public T GetById<T>(int id) where T : StationModel
        {
            throw new NotImplementedException();
        }
        public T Add<T>(T entity) where T : StationModel
        {
            var newEntity = _mapper.Map<Station>(entity);
            newEntity.CreationDate = DateTime.Now;

            _context.Stations.Add(newEntity);
            _context.SaveChanges();

            return entity;
        }
        public T Update<T>(T entity) where T : StationModel
        {
            if (entity is null || entity.Id.Equals(0)) return null;
            var oldEntity = _context.Stations
                                             .FirstOrDefault(p => p.Id == entity.Id);
            if (oldEntity is null) return null;

            var updatedEntity = _mapper.Map<Station>(entity);

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
    public class StationCriteria : ICriteriaBaseModel<Station>
    {
        public int? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }

        public Expression<Func<Station, bool>> Match()
        {
            var predicate = PredicateBuilder.New<Station>(t => true);
            if (Id.HasValue) predicate = predicate.And(d => d.Id == Id);
            if (!string.IsNullOrEmpty(Name)) predicate = predicate.And(d => d.Name.StartsWith(Name));
            return predicate;
        }
    }
}
