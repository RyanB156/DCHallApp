using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCHallApp.Models
{
    /// <summary>
    /// Represents a driving qualification that the applicant may have.
    /// </summary>
    public class Qualification
    {
        public string State { get; set; }
        public string LicenseNumber { get; set; }
        public string Class { get; set; }
        public string Endorsement { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ExpirationDate { get; set; }

        public Qualification() { }

        public Qualification(string state, string license, string qClass, string endorsement, DateTime date)
        {
            State = state;
            LicenseNumber = license;
            Class = qClass;
            Endorsement = endorsement;
            ExpirationDate = date;
        }

        public override string ToString()
        {
            return $"State: {State}, LicenseNumber: {LicenseNumber}, Class: {Class}, Endorsement: {Endorsement}, Expiration Date: {ExpirationDate.Value.ToLongDateString()}";
        }
    }
}