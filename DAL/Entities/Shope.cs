using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Shope
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Type { get; set; }

        public ICollection<ProductionShope> Productions { get; set; }
        

        public ICollection<UserRate> Rates { get; set; }
    }
}
