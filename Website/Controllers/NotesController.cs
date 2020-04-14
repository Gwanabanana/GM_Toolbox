using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;
using Microsoft.AspNet.Identity;

namespace Website.Controllers
{
    public class NotesController : Controller
    {
        private ApplicationDbContext _context;

        public NotesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(string category=null)
        {
            var note = GetNotesCategoryViewModel(0, category);
            return View(note);
        }
        
        public ActionResult All()
        {
            var viewModel = GetAllMyNotesViewModel();
            
            return View(viewModel);
        }

        private NotesCategoryViewModel GetAllMyNotesViewModel(int id = 0)
        {
            var userId = User.Identity.GetUserId();
            var notes = _context.Notes.Where(n => n.CreatorId == userId).ToList();
            var accessList = _context.Access.Where(a => a.UserId == userId).ToList();

            foreach(var access in accessList)
            {
                var accessibleNote = _context.Notes.SingleOrDefault(n => n.Id == access.NoteId);
                if (accessibleNote != null)
                {
                    notes.Add(_context.Notes.SingleOrDefault(n => n.Id == access.NoteId));
                }
            }

            var categories = _context.Notes.Where(n => n.CreatorId == userId && n.Category != null).ToList();

            foreach (var access in accessList)
            {
                var accessibleCategory = _context.Notes.SingleOrDefault(n => n.Id == access.NoteId);
                if (accessibleCategory != null)
                {
                    categories.Add(_context.Notes.SingleOrDefault(n => n.Id == access.NoteId && n.Category != null));
                }
            }

            var listOfCategories = new List<string>();
            foreach (var note in categories)
            {
                listOfCategories.Add(note.Category);
            }
            listOfCategories = listOfCategories.Distinct().ToList();

            return new NotesCategoryViewModel
            {
                Id = id,
                Notes = notes,
                Categories = listOfCategories
            };

        }

        private NotesViewModel GetNotesViewModel(int id=0, string category=null)
        {
            var userId = User.Identity.GetUserId();
            var notes = _context.Notes.Where(n => n.CreatorId == userId && n.Category == category).ToList();

            return new NotesViewModel
            {
                Id = id,
                Notes = notes
            };
        }

        private NotesCategoryViewModel GetNotesCategoryViewModel(int id=0, string category=null)
        {
            var userId = User.Identity.GetUserId();
            var notes = _context.Notes.Where(n => n.CreatorId == userId && n.Category == category).ToList();
            var accessList = _context.Access.Where(a => a.UserId == userId).ToList();

            foreach (var access in accessList)
            {
                var accessibleNote = _context.Notes.SingleOrDefault(n => n.Id == access.NoteId && n.Category == category);
                if (accessibleNote != null)
                {
                    notes.Add(accessibleNote);
                }
            }

            var categories = _context.Notes.Where(n => n.CreatorId == userId && n.Category != null).ToList();

            foreach (var access in accessList)
            {
                var accessibleCategory = _context.Notes.SingleOrDefault(n => n.Id == access.NoteId);
                if (accessibleCategory != null)
                {
                    categories.Add(_context.Notes.SingleOrDefault(n => n.Id == access.NoteId && n.Category != null));
                }
            }

            var listOfCategories = new List<string>();
            foreach(var note in categories)
            {
                listOfCategories.Add(note.Category);
            }
            listOfCategories = listOfCategories.Distinct().ToList();

            return new NotesCategoryViewModel
            {
                Id = id,
                Notes = notes,
                Categories = listOfCategories
            };

        }
    }
}