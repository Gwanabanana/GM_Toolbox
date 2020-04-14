using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;

namespace Website.Controllers
{
    public class WorldsController : Controller
    {
        private ApplicationDbContext _context;

        public WorldsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var worlds = GetWorldViewModel();
            return View(worlds);
        }
        
        public ActionResult Id(int id)
        {
            var viewModel = GetWorldViewModel(id);
            
            return View(viewModel);
        }
        
        private WorldViewModel GetWorldViewModel(int id=0)
        {
            var worlds = _context.Worlds.ToList();

            return new WorldViewModel
            {
                Id = id,
                Worlds = worlds
            };
        }
    }
}