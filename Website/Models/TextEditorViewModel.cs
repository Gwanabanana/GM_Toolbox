using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class TextEditorViewModel
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string Title { get; set; }

        [RegularExpression(@"^\S*$", ErrorMessage = "Space is not allowed")]
        public string Category { get; set; }

        [AllowHtml]
        public string Content { get; set; }
    }
}