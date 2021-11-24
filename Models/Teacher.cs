using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HCA_Code_Assessment.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
