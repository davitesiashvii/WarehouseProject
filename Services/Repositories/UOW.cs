using DAL.Context;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class UOW : IUOW
    {
        private WarehouseDBContext Context;
        private IProductionRepository _production;
        private IShopeRepository _shope;

        public UOW(WarehouseDBContext Context)
        {
            this.Context = Context;
        }

        public IShopeRepository Shope
        {
            get
            {
                if (_shope == null)
                    _shope = new ShopeRepository(Context);
                return _shope;
            }
        }

        public IProductionRepository Production
        {
            get
            {
                if (_production == null)
                    _production = new ProductionRepository(Context);
                return _production;
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
