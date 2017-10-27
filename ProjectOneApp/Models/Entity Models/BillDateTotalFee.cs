using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOneApp.Models.Entity_Models
{
    public class BillDateTotalFee
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BillNumber { get; set; }
        public double TotalFee { get; set; }
        public int PatientId { get; set; }
        public string Status { get; set; }
    }
}