using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCHallApp.Models
{
    /// <summary>
    /// Represents an accident that the applicant has been in during their career.
    /// </summary>
    public class Accident
    {
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Date { get; set; }

        public string Description { get; set; }
        public string Injuries { get; set; } = "no";
        public string Fatalities { get; set; } = "no";

        public Accident() { }

        public Accident(DateTime date, string description, string injuries, string fatalities)
        {
            Date = date;
            Description = description;
            Injuries = injuries;
            Fatalities = fatalities;
        }

        public override string ToString()
        {
            return $"Date: {Date.Value.ToLongDateString()}, Description: {Description}, Injuries: {Injuries}, Fatalities: {Fatalities}";
        }

    }
}