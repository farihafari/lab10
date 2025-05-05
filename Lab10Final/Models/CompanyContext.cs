using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab10Final.Models
{
    public class CompanyContext:DbContext
    {
        public DbSet<Company> Companies { get; set; }
    }
}