using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IShopeRepository : IRepositoryBase<Shope>
    {
        IEnumerable<Shope> GetAllShope();

        Shope GetShope(int Id);

        IEnumerable<Shope> Search(string searchTerm);

        Shope Delete(int Id);
    }
}
