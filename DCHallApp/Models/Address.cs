using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCHallApp.Models
{
    /// <summary>
    /// Represents an address with street, city, state, and zip fields.
    /// </summary>
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address() { }

        public Address(string street, string city, string state, string zip)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }

        public override string ToString()
        {
            return $"Street: {Street}, City: {City}, State: {State}, Zip: {Zip}";
        }
    }
}