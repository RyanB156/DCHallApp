using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace DCHallApp.Models
{
    /// <summary>
    /// Represents previous employment.
    /// </summary>
    public class Employment
    {
        public string EmployerName { get; set; }
        public Address Address { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }

        // Operators of commercial vehicles are subject to testing to follow state and federal regulations.
        public string WasSubjectToFMCSRs { get; set; } = "no";
        public string WasSubjectToTesting { get; set; } = "no";

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndTime { get; set; }

        public string PositionHeld { get; set; }
        public string SalaryOrWage { get; set; }
        public string ReasonForLeaving { get; set; }

        public Employment() { }

        public Employment(string name, Address address, string contactPerson, string number, string fmcsr, string testing, 
            DateTime start, DateTime end, string position, string wage, string reason)
        {
            EmployerName = name;
            Address = address;
            ContactPerson = contactPerson;
            PhoneNumber = number;
            WasSubjectToFMCSRs = fmcsr;
            WasSubjectToTesting = testing;
            StartTime = start;
            EndTime = end;
            PositionHeld = position;
            SalaryOrWage = wage;
            ReasonForLeaving = reason;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Employer Name: {EmployerName}, Address: {Address.ToString()}, Contact Person: {ContactPerson}, " +
                $"Phone Number: {PhoneNumber}, FMCSRs: {WasSubjectToFMCSRs}, Testing: {WasSubjectToTesting}, Start Time: {StartTime.Value.ToLongDateString()}, " + 
                $"End Time: {EndTime.Value.ToLongDateString()}, Position Held: {PositionHeld}, Salary or Wage: {SalaryOrWage}, Reason for Leaving: {ReasonForLeaving}");

            return sb.ToString();
        }

    }

}