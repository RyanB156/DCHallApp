using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCHallApp.Models
{
    /// <summary>
    /// Represents the duration of the experience and the approximate number of miles driven with that vehicle type.
    /// </summary>
    public class Experience
    {
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDate { get; set; }
        public int? ApproxMiles { get; set; }
        public string Description { get; set; }

        public Experience() { }

        public Experience(DateTime start, DateTime end, int miles, string description)
        {
            StartDate = start;
            EndDate = end;
            ApproxMiles = miles;
            Description = description;
        }

        public override string ToString()
        {
            return $"Start Date: {StartDate.Value.ToLongDateString()}, End Date: {StartDate.Value.ToLongDateString()}, Approximate Miles: {ApproxMiles}, Description: {Description}";
        }

    }
}