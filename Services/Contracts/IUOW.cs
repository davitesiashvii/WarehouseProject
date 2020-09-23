using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IUOW : IDisposable
    {
        IProductionRepository Production { get; }
        IShopeRepository Shope { get; }
        void Commit();
    }
}
