using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;
using Microsoft.AspNet.Identity;

namespace Website.Controllers
{
    [AllowAnonymous]
    public class TextEditorController : Controller
    {
        private ApplicationDbContext _context;

        public TextEditorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(string category = null)
        {
            TextEditorViewModel model = new TextEditorViewModel { Category = category };

            return View();
        }

        public ActionResult ErrorNote()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var currentUser = User.Identity.GetUserId();
                TextEditorViewModel noteInDb = _context.Notes.Single(c => c.Id == id);
                TextAccessViewModel noteModel = new TextAccessViewModel { textEditorViewModel = noteInDb };

                if (noteInDb.CreatorId ==  currentUser || 
                    (_context.Access.SingleOrDefault(a => a.UserId == currentUser && a.NoteId == noteInDb.Id && a.CanEdit) != null))
                {
                    return View("Edit", noteInDb);
                }
                else
                {
                    return View("ErrorNote");
                }
            }
        }

        [HttpPost]
        public ActionResult Create(TextEditorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            if (model.Id == 0)
            {
                model.CreatorId = User.Identity.GetUserId();
                _context.Notes.Add(model);
            }
            else
            {
                var currentUser = User.Identity.GetUserId();

                if (_context.Access.SingleOrDefault(a => a.UserId == currentUser && a.NoteId == model.Id && a.CanEdit == true) != null ||
                    _context.Notes.SingleOrDefault(n => n.CreatorId == currentUser && n.Id == model.Id) != null)
                {
                    var noteInDb = _context.Notes.Single(c => c.Id == model.Id);
                    noteInDb.Title = model.Title;
                    noteInDb.Content = model.Content;
                    TryUpdateModel(noteInDb);
                }
            }


            _context.SaveChanges();

            var textModel = new TextAccessViewModel { textEditorViewModel = model};
            return View("TextDisplay", textModel);
        }

        public ActionResult GetNote(int id)
        {

            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var currentUser = User.Identity.GetUserId();

                TextEditorViewModel noteInDb = _context.Notes.Single(c => c.Id == id);
                var noteModel = new TextAccessViewModel { textEditorViewModel = noteInDb };
                var accessibleNotes = _context.Access.SingleOrDefault(a=>a.NoteId==id && a.UserId == currentUser && a.CanEdit == true);
                if (accessibleNotes == null)
                {
                    accessibleNotes = _context.Access.SingleOrDefault(a => a.NoteId == id && a.UserId == currentUser
                && a.CanEdit == false);
                }

                if (noteInDb.CreatorId == currentUser || accessibleNotes != null)
                {
                    //It would be nice to have something to protect CreatorId from a note that we pass to this view
                    return View("TextDisplay", noteModel);
                }
                else
                {
                    return View("ErrorNote");
                }
            }

        }

        public ActionResult Delete(int id, bool isInAllPage = false)
        {
            var noteInDb = _context.Notes.Single(c => c.Id == id);
            var categoryOfDeletedNote = noteInDb.Category;
            var currentUser = User.Identity.GetUserId();
            var neededAccess = _context.Access.SingleOrDefault(a => a.UserId == currentUser && a.NoteId == id && a.CanEdit == true);
            if (neededAccess != null || noteInDb.CreatorId == currentUser)
            {
                var accessToDelete = _context.Access.Where(a => a.NoteId == id).ToList();

                foreach (var access in accessToDelete)
                {
                    _context.Access.Remove(access);
                }
                _context.Notes.Remove(noteInDb);

                _context.SaveChanges();

                if(isInAllPage == true)
                {
                    return RedirectToAction("All", "Notes");
                }

                //Change the action that You redirect to
                return RedirectToAction("Index", "Notes", new { category = categoryOfDeletedNote });
            }
            return View("ErrorNote");
        }

        [HttpPost]
        public ActionResult Share(TextAccessViewModel helpModel)
        {
            var model = new AccessHelpModel
            {
                NoteId = helpModel.NoteId, Username = helpModel.Username, CanEdit = helpModel.CanEdit
            };

            var currentUserId = User.Identity.GetUserId();

            if ((_context.Notes.SingleOrDefault(n => n.CreatorId == currentUserId && n.Id == model.NoteId) != null) ||
                (_context.Access.SingleOrDefault(n => n.UserId == currentUserId && n.NoteId == model.NoteId && n.CanEdit == true) != null))
            {
                if (_context.Users.SingleOrDefault(u => u.UserName == model.Username) != null) {
                    string userId = _context.Users.SingleOrDefault(u => u.UserName == model.Username).Id;

                    if (_context.Access.SingleOrDefault
                            (
                                n => n.NoteId == model.NoteId &&
                                n.UserId == userId &&
                                n.CanEdit == model.CanEdit
                            ) == null)
                    {
                        AccessModel accessModel = new AccessModel { NoteId = model.NoteId, UserId = userId, CanEdit = model.CanEdit };
                        _context.Access.Add(accessModel);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    //Create alert when there is no user with given name
                }
                //Change the action that You redirect to
                return RedirectToAction("GetNote", new { id = model.NoteId });
            }
            return View("ErrorNote");
        }

    }
}