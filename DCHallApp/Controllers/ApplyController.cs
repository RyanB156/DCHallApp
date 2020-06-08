using DCHallApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Mime;
using SendGrid;

namespace DCHallApp.Controllers
{
    public class ApplyController : Controller
    {

        private readonly bool testing = false;

        // TODO: Turn this into a form to receive the results.
        public ActionResult Index()
        {

            Applicant applicant;

            if (testing)
            {
                applicant = new Applicant
                {
                    FullName = "Ryan Michael Bressette",
                    EmailAddress = "bressetteryan@gmail.com",
                    FirstName = "Ryan",
                    MiddleInitial = "M",
                    LastName = "Bressette",
                    Initials = "RB",
                    DisclosureDate = DateTime.Now,
                    ApplicationDate = DateTime.Now,
                    Position = "Advertised Position",
                    PhoneNumber = "(123)456-7890",
                    CurrentAddress = new PreviousAddress(new Address("2855 CR615C", "Bushnell", "FL", "33513"), "22 years"),
                    WorkAuthorized = "yes",
                    BirthDate = new DateTime(1997, 10, 7),
                    CanProveAge = "yes",
                    HasWorkedHereBefore = "yes",
                    WhereWorkedBefore = "Desk work",
                    StartDateBefore = new DateTime(2020, 5, 1),
                    EndDateBefore = new DateTime(2020, 5, 14),
                    PayBefore = "$30/hour",
                    PositionBefore = "Desk Helper Intern",
                    ReasonForLeavingBefore = "Internship ended",
                    IsCurrentlyEmployed = "no",
                    TimeSinceEmployment = "1 day",
                    WhoReferred = "Job posting",
                    RateOfPayExpected = "$35/hour",
                    HasBeenBonded = "yes",
                    NameOfBondingCompany = "Bonding, LLC",
                    CanPerformDuties = "no",
                    ReasonForNotPerformingDuties = "No CDL",
                    EmploymentHistory = new List<Employment>() { new Employment("FL Poly", new Address("street", "Lakeland", "FL", "zip"), "Dr. Sesha", "1234567890", "yes", "yes", new DateTime(2019, 11, 1), new DateTime(2020, 5, 4), "Student Research Assistant", "$10/hour", "Graduated") },
                    AccidentHistory = new List<Accident>() { new Accident(new DateTime(2020, 1, 1), "Car crash", "yes", "yes") },
                    TrafficConvictions = new List<TrafficConviction> { new TrafficConviction("Earth", DateTime.Now, "Bad driving", "Stern talking to") },
                    Qualifications = new List<Qualification>() { new Qualification("FL", "12345", "E", "Driving", new DateTime(2014, 10, 8)) },
                    DrivingExperience = new List<Experience>() { new Experience(DateTime.Now, DateTime.Now, 20000, "General driving") },
                    LicenseHasBeenDenied = "yes",
                    LicenseHasBeenSuspended = "yes",
                    WhyDeniedOrSuspended = "Reason for denial or suspension here",
                    StatesOperatedIn = "FL, GA, SC, NC, TN",
                    SpecialCoursesOrTraining = "Dad's training",
                    SafeDrivingAwards = "Gold star",
                    OtherExperience = "Office work, computers",
                    OtherEquipment = "Tractors, fork lifts",
                    YearCompleted = YearChoice.Senior,
                    SchoolLevel = SchoolChoice.College,
                    LastSchoolAttendedName = "Florida Polytechnic University",
                    LastSchoolAttendedAddress = "Lakeland, FL",
                    OtherSchooling = "Other description here",
                    CertifySignature = "Ryan Bressette",
                    CertifyDate = DateTime.Now
                };
            }
            else
            {
                applicant = new Applicant()
                {
                    EmploymentHistory = new List<Employment>(),
                    AccidentHistory = new List<Accident>(),
                    TrafficConvictions = new List<TrafficConviction>(),
                    Qualifications = new List<Qualification>(),
                    DrivingExperience = new List<Experience>()
                };
            }

            // Note: Keep this loop to populate the list fields.
            for (int i = 0; i < 5; i++)
            {
                applicant.EmploymentHistory.Add(new Employment());
                applicant.AccidentHistory.Add(new Accident());
                applicant.TrafficConvictions.Add(new TrafficConviction());
                applicant.Qualifications.Add(new Qualification());
                applicant.DrivingExperience.Add(new Experience());
            }

            return View(applicant);
        }

        /// <summary>
        /// Receive form input from the application. Returns a page showing the json version of the application date.
        /// TODO: Make this show a confirmation page instead...
        /// </summary>
        /// <param name="applicant">An Applicant object containing all information entered in the application</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(applicant);

                // Create a file from the application data.
                var fileContents = applicant.ToString();
                
                var fileName = $"Application_{applicant.FullName.Replace(' ', '_')}_{DateTime.Now.ToLongDateString()}.txt";

                // Send file path and filename as an email.
                SendMail(fileContents, fileName);

                return RedirectToAction("Confirmation");
            }
            else
            {
                return View(applicant);
            }
        }

        /// <summary>
        /// Send an email using the specified path as the attachment with the specified filename.
        /// TODO: Change email addresses, get this working with David's GoDaddy email, set email and passwords in config...
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        [NonAction]
        private void SendMail(string fileContent, string fileName)
        {
            try
            {
                var email = System.Web.Configuration.WebConfigurationManager.AppSettings["SenderEmail"];
                var password = System.Web.Configuration.WebConfigurationManager.AppSettings["SenderEmailPassword"];
                // Set contents of the email message.
                var fromAddress = new MailAddress(email, "Application_Site");
                var toAddress = new MailAddress(email, "David");
                string subject = fileName;

                //var smtp = new SmtpClient("smtpout.secureserver.net", Convert.ToInt32(587))
                var smtp = new SmtpClient()
                {
                    Host = "smtpout.secureserver.net",
                    Port = 80,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(email, password),
                    EnableSsl = false
                };

                using (var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject
                })
                {
                    // Create attachment.
                    //var attachment = new Attachment(path, MediaTypeNames.Text.Plain);
                    var attachment = new Attachment(new MemoryStream(ASCIIEncoding.ASCII.GetBytes(fileContent)), fileName, MimeType.Text);
                    mailMessage.Attachments.Add(attachment);
                    // Send message.
                    smtp.Send(mailMessage);
                }
                smtp.Dispose();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            
        }

        public ActionResult Confirmation(string data)
        {
            return View(data);
        }
    }
}