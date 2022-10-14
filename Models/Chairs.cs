using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace chairs.Models
{
    public class Chairs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Colour { get; set; }
        public string Height { get; set; }
        public decimal Price { get; set; }
    }
}
