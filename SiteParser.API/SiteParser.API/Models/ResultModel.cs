using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteParser.API.Models
{
    public class ResultModel
    {
        [Key]
        public int ID { get; set; }
        public string Sentence { get; set; }
        public string Word { get; set; }
        public int Count { get; set; }
    }
}
