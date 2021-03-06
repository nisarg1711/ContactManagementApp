//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContactManagement.Data
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ContactDetail
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string JobTitle { get; set; }
        [Column(Order = 3), ForeignKey("Company")]
        public int CompanyId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> LastDateContacted { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public virtual Company Company { get; set; }
        public virtual ContactDetail ContactDetails1 { get; set; }
        public virtual ContactDetail ContactDetail1 { get; set; }

        [NotMapped]
        public virtual SelectList Companies { get; set; }
    }
}
