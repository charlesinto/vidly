using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModel
{
    public class CustomerFormModel
    {
        public IEnumerable<MembershipType> membershipTypes;
        public Customer customer;

    }
}