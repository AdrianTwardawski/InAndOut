using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense Type")]
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        
        
    }
}
