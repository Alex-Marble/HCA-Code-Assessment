using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HCA_Code_Assessment.Models
{
    [Table("ClassAssignments")]
    public class ClassAssignment
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }
}
