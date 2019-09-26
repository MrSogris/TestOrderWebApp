using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestOrderWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string OrderName { get; set; }

        [Required]
        [Display(Name = "Create date")]
        public DateTime CreateDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public String Status { get; set; }
    }
}
