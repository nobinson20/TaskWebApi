using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWebApi.WebApi.Models
{
    public class QuoteModel
    {
        public int ID { get; set; }
        public string QuoteType { get; set; }
        public string Contact { get; set; }
        public string Task { get; set; }
        public DateTime? DueDate { get; set; }
        public string TaskType { get; set; }
    }
}