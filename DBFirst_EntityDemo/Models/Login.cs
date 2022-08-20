//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirst_EntityDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Login
    {
        public int Id { get; set; }

        [Display(Name ="User Name:")]
        [Required(ErrorMessage ="UserName can't be blank")]
        [RegularExpression(@"\w{6,20}",ErrorMessage ="Username must be of 6-20 chars")]
        public string Username { get; set; }

        [Display(Name = "User Password:")]
        [Required(ErrorMessage = "Password can't be blank")]
        [RegularExpression(@"\w{8,30}@", ErrorMessage = "Password must be of 8-20 chars")]
        public string Password { get; set; }
    }
}
