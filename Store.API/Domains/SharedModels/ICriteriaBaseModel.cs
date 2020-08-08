using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Store.API.Domains.SharedModels
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
