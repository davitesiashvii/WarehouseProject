using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ProductionShope
    {
        public int Id { get; set; }

        public int ProductionID { get; set; }

        public int ShopeID { get; set; }

        public double Price { get; set; }

        public int Code { get; set; }

        public Production Production { get; set; }

        public  Shope Shope { get; set; }


    }
}
