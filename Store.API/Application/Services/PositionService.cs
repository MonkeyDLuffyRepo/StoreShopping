using AutoMapper;
using LinqKit;
using Store.API.Application.Interaces;
using Store.API.Domains.PositionModels;
using Store.API.Domains.SharedModels;
using Store.Persistance.Contexts;
using Store.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Store.API.Application.Services
{
   public class PositionService : IPositionService
    {
        private readonly STOREContext _context;
        private readonly IMapper _mapper;
        public PositionService(STOREContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<T> GetAll<T>() where T : PositionModel
        {
            var entities = _context.Positions
                  .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }
        public IEnumerable<T> GetByCriteria<T, C>(C criteria)
            where T : PositionModel
            where C : ICriteriaBaseModel<Position>
        {
            var entities = _context.Positions
                   .Where(criteria.Match())
                   .OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.CreationDate)
                   .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public T GetById<T>(int id) where T : PositionModel
        {
            throw new NotImplementedException();
        }

        public T Add<T>(T entity) where T : PositionModel
        {
            var newPosition = _mapper.Map<Position>(entity);
            newPosition.CreationDate = DateTime.Now;

            _context.Positions.Add(newPosition);
            _context.SaveChanges();

            return entity;
        }
        public T Update<T>(T entity) where T : PositionModel
        {
            throw new NotImplementedException();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class PositionCriteria : ICriteriaBaseModel<Position>
    {
        public int? Id { get ; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? ModificationDateFrom { get; set; }
        public DateTime? ModificationDateTo { get; set; }
        public string Name { get; set; }
       
        public Expression<Func<Position, bool>> Match()
        {
            var predicate = PredicateBuilder.New<Position>(t => true);
            if (Id.HasValue) predicate = predicate.And(d => d.VehiculeId == Id);
            if (CreationDateFrom.HasValue) predicate = predicate.And(d => d.CreationDate >= CreationDateFrom);
            if (CreationDateTo.HasValue) predicate = predicate.And(d => d.CreationDate >= CreationDateTo);
            return predicate;
        }
    }
}
