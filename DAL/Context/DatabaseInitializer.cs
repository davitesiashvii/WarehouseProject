using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public static class DatabaseInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Production>()
             .HasData(
                new Production
                {
                   // Id = 1,
                    Name = "bali",
                    ManufacturerCompany = "kaxetis bagnari",
                    Image = "sdsads"
                },

                new Production
                {
                    //Id=2,
                    Name="tevzi",
                    ManufacturerCompany="mtkvari",
                    Image="sdada"

                }
                );

            modelBuilder.Entity<Shope>()
                .HasData(
                   new Shope
                   {
                       //Id = 1,
                       Name = "didgorMarket",
                       Address = "saburtalo",
                       Type = "market"
                   },

                   new Shope
                   {
                       //Id=2,
                       Name = "spar",
                       Address = "gldani",
                       Type = "market"
                   }


                );

    




        }

    }
    
}
