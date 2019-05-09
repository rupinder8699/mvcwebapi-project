using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMvcStu.Models
{
    public class Enrollment
    {
        [Display(Name = "EnrollmentId")]
        public int EnrollmentId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Current Qualification")]
        public string CurrentQualification { get; set; }

        [Display(Name = "Course")]
        public string Course { get; set; }

    }
}