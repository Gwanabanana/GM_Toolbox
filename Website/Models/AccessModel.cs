using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class AccessModel
    {
        public int Id { get; set; }

        [Required]
        public int NoteId { get; set; }
        public string UserId { get; set; }
        public bool CanEdit { get; set; }
    }
}