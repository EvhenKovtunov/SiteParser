using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteParser.API.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Word { get; set; }
    }
}
