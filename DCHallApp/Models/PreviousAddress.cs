using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCHallApp.Models
{
    /// <summary>
    /// Represents the length of time that the applicant has been at an address.
    /// </summary>
    public class PreviousAddress
    {
        public Address Address { get; set; }
        public string TimeLivedHere{ get; set; }

        public PreviousAddress() { }

        public PreviousAddress(Address address, string timeLivedHere)
        {
            Address = address;
            TimeLivedHere = timeLivedHere;
        }

        public override string ToString()
        {
            return TimeLivedHere + ", " + Address.ToString();
        }

    }
}