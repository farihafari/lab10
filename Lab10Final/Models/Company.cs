using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab10Final.Models
{
    [Table("Details")]
    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public string gender { get; set; }

    }
}