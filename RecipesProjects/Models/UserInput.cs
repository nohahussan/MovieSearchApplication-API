using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MovieAPI_Project.Models
{
    public class UserInput
    {
        [Required(ErrorMessage = "Must not be empty")]
        public string MovieName { get; set; }
        
        public UserInput()
        { }
    }
}