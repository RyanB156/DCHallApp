using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCHallApp.Models
{
    /// <summary>
    /// Represents traffic convictions that the applicant may have.
    /// </summary>
    public class TrafficConviction
    {
        public string Location { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Date { get; set; }
        public string Charge { get; set; }
        public string Penalty { get; set; }

        public TrafficConviction() { }

        public TrafficConviction(string location, DateTime date, string charge, string penalty)
        {
            Location = location;
            Date = date;
            Charge = charge;
            Penalty = penalty;
        }

        public override string ToString()
        {
            return $"Location: {Location}, Date: {Date.Value.ToLongDateString()}, Charge: {Charge}, Penalty: {Penalty}";
        }
    }
}