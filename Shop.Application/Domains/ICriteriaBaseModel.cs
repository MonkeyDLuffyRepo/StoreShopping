using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Shop.Application.Domains
{
    public interface ICriteriaBaseModel<T>
    {
        public int? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }

        Expression<Func<T, bool>> Match();
    }
}
