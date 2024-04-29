using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Json.Models
{
 
        public class Student
        {
            [Key]
            public int studentID { get; set; }
            [Required]
            public string studentName { get; set; }
            [Required]
            public string studentAddress { get; set; }
        }

    }
