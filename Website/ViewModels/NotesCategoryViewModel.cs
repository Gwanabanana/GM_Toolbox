using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.ViewModels
{
    public class NotesCategoryViewModel
    {
        public int Id { get; set; }
        public List<TextEditorViewModel> Notes { get; set; }
        public List<String> Categories { get; set; }
    }
}