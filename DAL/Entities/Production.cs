using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Production
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ManufacturerCompany { get; set; }

        public string Image { get; set; }

        public ICollection<ProductionShope> Shopes { get; set; }

        //public ICollection<UserProduction> Users { get; set; }
    }
}
