using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.ViewModels
{
    public class CampaignViewModel
    {
        public int Id { get; set; }
        public List<Campaign> Campaigns { get; set; }
    }
}