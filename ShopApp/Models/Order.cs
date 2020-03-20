using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage ="Field can not be empty")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Field can not be empty")]
        public string SurName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Field can not be empty")]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Number must contain at least 7 digits")]
        public string Phone { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime {get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
