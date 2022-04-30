using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Service.DTO
{
    public class QuoteDTO
    {
        public int ID { get; set; }
        public string QuoteType { get; set; }
        public string Contact { get; set; }
        public string Task { get; set; }
        public DateTime? DueDate { get; set; }
        public string TaskType { get; set; }
    }
}
