using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Models
{
    public class GetOptions
    {
        [Required]
        public int pageSize { get; set; }
        [Required]
        public int pageNumber { get; set; }
        [Required]
        public bool filterForTrainer { get; set; }
    }
}
