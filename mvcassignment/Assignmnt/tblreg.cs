//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignmnt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Assignmnt.Models;

    public partial class tblreg
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }     
        public string State { get; set; }      
        public string City { get; set; }
       
    }
}