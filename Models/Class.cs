using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HCA_Code_Assessment.Models
{
    [Table("Classes")]
    public class Class
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public string ClassName { get; set; }
        [NotMapped]
        public Teacher TeacherInfo { get; set; }
    }
}
