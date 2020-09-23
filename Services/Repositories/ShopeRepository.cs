using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Repositories
{
    public class ShopeRepository: RepositoryBase<Shope>, IShopeRepository
    {
        public ShopeRepository(WarehouseDBContext context) : base(context) { }

        public Shope Delete(int Id)
        {
            return Context.Shopes.Where(x => x.Id == Id).FirstOrDefault();
               // .Include(x => x.Productions)
                //.ThenInclude(x => x.Production).FirstOrDefault();
        }

        public IEnumerable<Shope> GetAllShope()
        {
            return Context.Shopes
                .Include(x => x.Productions)
                .ThenInclude(x => x.Production);
        }

        public Shope GetShope(int Id)
        {
            return Context.Shopes.Where(x => x.Id == Id)
                .Include(x => x.Productions)
                .ThenInclude(x => x.Production).FirstOrDefault();

        }

        public IEnumerable<Shope> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return Context.Shopes
                .Include(x => x.Productions)
                .Include(x => x.Productions);
            }
            return Context.Shopes.Where(e => e.Name.Contains(searchTerm) ||
                                             e.Address.Contains(searchTerm) ||
                                             e.Type.Contains(searchTerm))
                                             .Include(x => x.Productions)
                                             .Include(x => x.Productions);
        }
    }
}
