using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;

namespace Website.Controllers
{
    public class CampaignsController : Controller
    {
        private ApplicationDbContext _context;

        public CampaignsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            CampaignViewModel viewModel = GetCampaignViewModel();
            return View(viewModel);
        }

        private CampaignViewModel GetCampaignViewModel(int id = 0)
        {
            var campaigns = _context.Campaigns.ToList();

            return new CampaignViewModel
            {
                Id = id,
                Campaigns = campaigns
            };
        }
        
        public ActionResult Id(int id)
        {
            CampaignViewModel viewModel = GetCampaignViewModel(id);
            return View(viewModel);
        }
    }
}