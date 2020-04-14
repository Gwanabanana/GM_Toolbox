using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;
using System.ComponentModel.DataAnnotations;

namespace Website.ViewModels
{
    public class TextAccessViewModel
    {
        public int NoteId { get; set; }
        public string Username { get; set; }
        public bool CanEdit { get; set; }
        public TextEditorViewModel textEditorViewModel { get; set; }
    }
}