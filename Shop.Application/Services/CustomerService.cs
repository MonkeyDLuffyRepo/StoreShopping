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
using System.Data;
using System.Linq;
using System.Linq.Expressions;


namespace Store.API.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;
        public CustomerService(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<T> GetAll<T>() where T : CustomerModel
        {
            var entities = _context.Customers
                  .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }
        public IEnumerable<T> GetByCriteria<T, C>(C criteria)
            where T : CustomerModel
            where C : ICriteriaBaseModel<Customer>
        {
            var entities = _context.Customers
                   .Where(criteria.Match())
                   .OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.CreationDate)
                   .ToList();

            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public T GetById<T>(int id) where T : CustomerModel
        {
            throw new NotImplementedException();
        }

        public T Add<T>(T entity) where T : CustomerModel
        {
            var newPosition = _mapper.Map<Customer>(entity);
            newPosition.CreationDate = DateTime.Now;

            _context.Customers.Add(newPosition);
            _context.SaveChanges();

            return entity;
        }
        public T Update<T>(T entity) where T : CustomerModel
        {
            if (entity is null || entity.Id.Equals(0)) return null;
            var oldEntity = _context.Customers
                                             .FirstOrDefault(p => p.Id == entity.Id);
            if (oldEntity is null) return null;

            var updatedEntity = _mapper.Map<Customer>(entity);

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

    public class CustomerCriteria : ICriteriaBaseModel<Customer>
    {
        public int? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? ModificationDateFrom { get; set; }
        public DateTime? ModificationDateTo { get; set; }
        public string Name { get; set; }

        public Expression<Func<Customer, bool>> Match()
        {
            var predicate = PredicateBuilder.New<Customer>(t => true);
            if (CreationDateFrom.HasValue) predicate = predicate.And(d => d.CreationDate >= CreationDateFrom);
            if (CreationDateTo.HasValue) predicate = predicate.And(d => d.CreationDate >= CreationDateTo);
            return predicate;
        }
    }


    public class ClientSMS
    {
        public int Telephone { get; set; }
        public int SC { get; set; }
        public DateTime DateMessage { get; set; }

    }

    public  class ServiceVote{
        public  List<ClientSMS> clientSMs = new List<ClientSMS>();
        public  DateTime dateStart = new DateTime(2017,3,1); // 01/03/2017  
        public  DateTime dateEnd = new DateTime(2017,3,7); //  07/03/2017. 

        public  List<int> GetTreeWiner(List<ClientSMS> clientSMs)
        {
            var winers = new List<int>();
            var group = clientSMs
                .Where(c => (c.DateMessage >= dateStart && c.DateMessage <= dateEnd))
                .GroupBy(c => c.Telephone).Select(g =>
                new
                {
                    Telephone = g.Key,
                    CountVote = g.Count()
                }
                ).OrderByDescending(g => g.CountVote)
                .Take(10)
                .ToList();
             
                while(winers.Count != 3)
            {
                var rnd = new Random();
                var SelectedGroup = group.OrderBy(x => rnd.Next()).Take(1);
                var selectedWinner = SelectedGroup.Select(g => g.Telephone).First();
                if (!winers.Any(c => c == selectedWinner) ) winers.Add(selectedWinner);
            }


            return winers;
        }
    
    }

}
