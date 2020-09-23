using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserRate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShopeId { get; set; }
        public int Score { get; set; }

        public Shope Shope{ get; set; }
        public User User { get; set; }

    }
}
