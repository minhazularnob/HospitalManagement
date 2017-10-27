using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOneApp.Models.Entity_Models
{
    public class PatientInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
    }
}