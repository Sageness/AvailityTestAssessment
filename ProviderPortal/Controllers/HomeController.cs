using System;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Security.Application;
using ProviderPortal.Models;
// ReSharper disable UnusedVariable
#pragma warning disable 168

namespace ProviderPortal.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// This action handles the processing of the provider registration form.
        /// </summary>
        [HttpPost]
        public ActionResult SubmitProviderInquiry(string providerFirstName, string providerLastName, int providerNpi, string providerAddress, string providerCity, string providerState, string providerZip, string providerPhone, string providerEmail)
        {
            //TODO: Add session validation
            if (!ModelState.IsValid)
            {
                //TODO: Log invalid ModelState errors
                return StatusCode(Convert.ToInt16(HttpStatusCode.Forbidden)); 
            }

            try
            {
                //Sanitize and map inputs to object
                var provider = new Provider
                {
                    FirstName = Encoder.HtmlEncode(providerFirstName),
                    LastName = Encoder.HtmlEncode(providerLastName),
                    NPI = providerNpi,
                    Address = Encoder.HtmlEncode(providerAddress),
                    City = Encoder.HtmlEncode(providerCity),
                    State = Encoder.HtmlEncode(providerState),
                    Zip = Encoder.HtmlEncode(providerZip),
                    Phone = Encoder.HtmlEncode(providerPhone),
                    Email = Encoder.HtmlEncode(providerEmail)
                };

                //TODO: Save provider either to DAL or send object to Web Service

                return StatusCode(Convert.ToInt16(HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                //TODO: Log ex.Message
                return StatusCode(Convert.ToInt16(HttpStatusCode.InternalServerError));
            }
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
