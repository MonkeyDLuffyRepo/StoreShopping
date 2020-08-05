using Store.Persistance.Contexts;
using Store.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Persistance.Repositories.PositionRepo
{
   public class PositionRepository : GenericRepository<Position, STOREContext>
    {
        public PositionRepository(STOREContext context) : base(context)
        {

        }
    }
}
