using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Persistance.Entities
{
  public  class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
