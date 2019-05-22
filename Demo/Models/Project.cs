using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LazyLoadInMVC.Models
{
    public class Project
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string Email { get; set; }
    }
}