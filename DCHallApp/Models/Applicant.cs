using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace DCHallApp.Models
{
    /// <summary>
    /// Represents the prospective employee that is applying for the position. Stores all data entered by the user in the form data.
    /// This data will be formatted into a document and emailed to the hiring manager.
    /// </summary>
    public class Applicant
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        public string MiddleInitial { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Initials { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DisclosureDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ApplicationDate { get; set; }

        [Required]
        public string Position { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }

        public PreviousAddress CurrentAddress { get; set; }

        public string WorkAuthorized { get; set; } = "no";

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? BirthDate { get; set; }
        public string CanProveAge { get; set; } = "no";

        // Past employment with this company. Option to make all of this null.
        public string HasWorkedHereBefore { get; set; } = "no";
        public string WhereWorkedBefore { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? StartDateBefore { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDateBefore { get; set; }

        public string PayBefore { get; set; }
        public string PositionBefore { get; set; }
        public string ReasonForLeavingBefore { get; set; }

        // Current employment.
        public string IsCurrentlyEmployed { get; set; } = "no";
        public string TimeSinceEmployment { get; set; }
        public string WhoReferred { get; set; }
        public string RateOfPayExpected { get; set; } // Can be salary, per hour, per mile. Make this a string.
        public string HasBeenBonded { get; set; } = "no";
        public string NameOfBondingCompany { get; set; }

        // Unable to perform job duties.
        public string CanPerformDuties { get; set; } = "yes";
        public string ReasonForNotPerformingDuties { get; set; }

        // Employment history.
        public List<Employment> EmploymentHistory { get; set; }

        // Accident history.
        public List<Accident> AccidentHistory { get; set; }

        // Traffic Convictions.
        public List<TrafficConviction> TrafficConvictions { get; set; }

        // Experience and Qualifications.
        public List<Qualification> Qualifications { get; set; }
        public List<Experience> DrivingExperience { get; set; }

        // License, premit, or privilege denied, suspended, or revoked.
        public string LicenseHasBeenDenied { get; set; } = "no";
        public string LicenseHasBeenSuspended { get; set; } = "no";
        public string WhyDeniedOrSuspended { get; set; }

        public string StatesOperatedIn { get; set; }
        public string SpecialCoursesOrTraining { get; set; }
        public string SafeDrivingAwards { get; set; }

        // Other experience and qualifications.
        public string OtherExperience { get; set; }
        public string OtherEquipment { get; set; }

        // Education.
        [Required]
        public YearChoice? YearCompleted { get; set; }
        [Required]
        public SchoolChoice? SchoolLevel { get; set; }
        public string LastSchoolAttendedName { get; set; }
        public string LastSchoolAttendedAddress { get; set; }
        public string OtherSchooling { get; set; }

        [Required]
        public string CertifySignature { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? CertifyDate { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Applicant Name: {FirstName} {MiddleInitial} {LastName}");

            sb.AppendLine($"Application Date: {ApplicationDate.Value.ToLongDateString()}");

            sb.AppendLine($"Applicant Email Addres: {EmailAddress}");

            sb.AppendLine();
            sb.AppendLine($"Position: {Position}");

            sb.AppendLine($"Phone Number: {PhoneNumber}");

            sb.AppendLine($"Current Address: {CurrentAddress.ToString()}");

            sb.AppendLine($"Is work authorized: {WorkAuthorized}");

            sb.AppendLine($"Born {BirthDate.Value.ToLongDateString()}");
            sb.AppendLine($"Can prove age: {CanProveAge}");

            sb.AppendLine();
            sb.AppendLine($"Has worked here before: {HasWorkedHereBefore}");

            if (HasWorkedHereBefore == "yes")
            {
                sb.AppendLine("The applicant...");
                sb.AppendLine($"Worked in this position before: {WhereWorkedBefore},");

                sb.AppendLine($"Started this date: {StartDateBefore.Value.ToLongDateString()},");
                sb.AppendLine($"Ended this date: {EndDateBefore.Value.ToLongDateString()},");
                sb.AppendLine($"Earned this much: {PayBefore},");
                sb.AppendLine($"In this position: {PositionBefore},");
                sb.AppendLine($"And left for this reason: {ReasonForLeavingBefore}");
            }


            sb.AppendLine($"Is currently employed: {IsCurrentlyEmployed}");

            if (IsCurrentlyEmployed == "no")
            {
                sb.AppendLine($"Time since employment: {TimeSinceEmployment}");
            }

            sb.AppendLine($"Referred by {WhoReferred}");
            sb.AppendLine($"Expects pay rate: {RateOfPayExpected}");

            if (HasBeenBonded == "yes")
            {
                sb.AppendLine($"Applicant has been bonded by: {NameOfBondingCompany}");
            }

            if (CanPerformDuties == "no")
            {
                sb.AppendLine($"Applicant cannot perform duties because: {ReasonForNotPerformingDuties}");
            }

            sb.AppendLine("\nEmployment History");
            foreach (var e in EmploymentHistory)
            {
                if (!String.IsNullOrEmpty(e.PositionHeld))
                {
                    sb.AppendLine($"Employment: {e.ToString()}\n");
                }
            }

            sb.AppendLine("\nAccident History");
            foreach (var a in AccidentHistory)
            {
                if (!String.IsNullOrEmpty(a.Description))
                {
                    sb.AppendLine($"Accident: {a.ToString()}\n");
                }
            }


            sb.AppendLine("\nTraffic Convictions");
            foreach (var c in TrafficConvictions)
            {
                if (!String.IsNullOrEmpty(c.Charge))
                {
                    sb.AppendLine($"Traffic Conviction: {c.ToString()}\n");
                }
            }


            sb.AppendLine("\nQualifications");
            foreach (var q in Qualifications)
            {
                if (!String.IsNullOrEmpty(q.LicenseNumber))
                {
                    sb.AppendLine($"Qualification: {q.ToString()}\n");
                }
            }


            sb.AppendLine("\nDriving Experience");
            foreach (var e in DrivingExperience)
            {
                if (!String.IsNullOrEmpty(e.Description))
                {
                    sb.AppendLine($"Driving Experience: {e.ToString()}\n");
                }
            }

            sb.AppendLine($"Applicant's license has been denied: {LicenseHasBeenDenied}");
            sb.AppendLine($"Applicant's license has been suspended: {LicenseHasBeenSuspended}");

            if (LicenseHasBeenSuspended.Equals("yes") || LicenseHasBeenDenied.Equals("yes"))
            {
                sb.AppendLine($"Applicant's license has been denied or suspended because: {WhyDeniedOrSuspended}");
            }

            sb.AppendLine($"Applicant has operated in these states: {StatesOperatedIn}");
            sb.AppendLine($"Applicant has had these special courses or training(s): {SpecialCoursesOrTraining}");
            sb.AppendLine($"Applicant has earned these safe driving awards: {SafeDrivingAwards}");
            sb.AppendLine($"Applicant has the following other experience: {OtherExperience}");
            sb.AppendLine($"Applicant has experience with this equipment: {OtherEquipment}");

            sb.AppendLine("\nEducation");
            sb.AppendLine($"Highest grade completed: {YearCompleted.Value}");
            sb.AppendLine($"Highest school attended: {SchoolLevel.Value}");

            sb.AppendLine($"Applicant attended {LastSchoolAttendedName} at {LastSchoolAttendedAddress}");

            if (!String.IsNullOrEmpty(OtherSchooling))
            {
                sb.AppendLine($"Applicant attended other schooling: {OtherSchooling}");
            }

            return sb.ToString();
        }

    }
}