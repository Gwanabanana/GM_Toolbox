using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.ViewModels
{
    public class WorldViewModel
    {
        public int Id { get; set; }
        public List<World> Worlds { get; set; }
    }
}