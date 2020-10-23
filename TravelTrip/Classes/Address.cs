﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTrip.Classes
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Addresses { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }


    }
}