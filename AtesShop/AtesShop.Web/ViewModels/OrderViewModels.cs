using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtesShop.Web.ViewModels
{
    public class OrderViewModels
    {
        public class OrderAddressViewModel
        {
            public string Country { get; set; }
            
            public string State { get; set; }
            
            public string City { get; set; }
            
            public string ZipCode { get; set; }
            
            public string Line1 { get; set; }

            public string Line2 { get; set; }
        }

        public class OrderDetailsViewModel
        {
            public string FirstName { get; set; }
            
            public string LastName { get; set; }
            
            public string CompanyName { get; set; }
            
            public string Email { get; set; }
            
            public string Phone { get; set; }

            public OrderAddressViewModel Address { get; set; }
        }
        
        public class OrderItemsViewModel
        {
            
        }

        public class OrderViewModel
        {
            public OrderDetailsViewModel Bill { get; set; }
           
            public OrderDetailsViewModel Ship { get; set; }

            public string OrderNote { get; set; }

            public bool isShipDifferent { get; set; }

            public bool SaveAddress { get; set; }
            
        }

    }
}