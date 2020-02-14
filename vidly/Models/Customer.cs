using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        private string _name;
        public MembershipType membershipType { get; set; }

        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name ="Subscribe to Newsletter?")]
        public bool IsSubscribedToNewsLetter { get; set; }
        [Required]
        [StringLength(255)]

        [Display(Name ="Customer Name")]
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        [Display(Name = "Date of Birth")]
        public DateTime birthdate { get; set; }
        public Customer() { }
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}