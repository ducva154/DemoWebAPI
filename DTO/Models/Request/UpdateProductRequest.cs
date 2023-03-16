using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models.Request
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
