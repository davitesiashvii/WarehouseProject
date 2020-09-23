using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IProductionRepository : IRepositoryBase<Production>
    {
        IEnumerable<Production> GetAllProduction();

        Production GetProduction(int Id);

        IEnumerable<Production> Search(string searchTerm);

    }
}
