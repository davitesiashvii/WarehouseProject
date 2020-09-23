using DAL.Context;
using DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Repositories
{
    public class ProductionRepository : RepositoryBase<Production>, IProductionRepository
    {
        public ProductionRepository(WarehouseDBContext context) : base(context) { }
        private List<Production> productions;

        public IEnumerable<Production> GetAllProduction()
        {
            return Context.Productions;
        }

        public Production GetProduction(int Id)
        {
            return Context.Productions.Where(x => x.Id == Id).FirstOrDefault();  
        }

        public IEnumerable<Production> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return Context.Productions;
            }
            return Context.Productions.Where(e => e.Name.Contains(searchTerm) || e.ManufacturerCompany.Contains(searchTerm));
        }
    }
}
