using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPratice.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Int64 Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public int BOD { get; set; }
        public string Gender { get; set; }
    }
}