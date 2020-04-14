using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public List<Customer> Customers { get; set; }
    }
}