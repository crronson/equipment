using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EquipDisplay.Models;

namespace EquipDisplay.Controllers
{
    public class HomeController : Controller
    {
        //Used to generate alphanumeric ids with dashes
        StringBuilder result = new StringBuilder();

        private ApplicationDbContext _context;


        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Home Page View. Displays the datatable with the View Model of EquipmentType and SerialisedEquipment.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var displayModel = _context.Displays.ToList();

            return View(displayModel);
        }

        /// <summary>
        /// Display a Single Equipment.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult DisplayEquipment(int ID)
        {

            var displaEQ = _context.Displays.SingleOrDefault(d => d.ID == ID);

            return View(displaEQ);
        }

        /// <summary>
        /// Edit the Display Object that is currently loaded at DisplayEquipment View.
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Display display)
        {

            var displayInDb = _context.Displays.SingleOrDefault(p => p.ID == display.ID);
            displayInDb.ExternalId = display.ExternalId;
            displayInDb.Description = display.Description;
            displayInDb.MeterReading = display.MeterReading;

            _context.SaveChanges();

            return View("DisplayEquipment", displayInDb);
        }

        /// <summary>
        /// Search Action for ExternalId. The results are displayed using DisplayEquipment View.
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Search(Display display)
        {

            var displayInDb = _context.Displays.FirstOrDefault(d => d.ExternalId == display.ExternalId);

            if (displayInDb == null)
            {
                RedirectToAction("Index", displayInDb);
            }
            else
            {
                RedirectToAction("DisplayEquipment", displayInDb);
            }

            ModelState.Clear();
            return View("DisplayEquipment", displayInDb);
        }

        /// <summary>
        /// Delete an item model from database.
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Display display)
        {


            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                var displayInDb = _context.Displays.Single(d => d.ID == display.ID);
                _context.Displays.Remove(displayInDb);
            }

            _context.SaveChanges();

            return View();
        }

        /// <summary>
        /// Add item model to database.
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Display display)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                var displayInDb = _context.Displays.Single(d => d.ID == display.ID);
                displayInDb.Description = display.Description;
                displayInDb.ExternalId = display.ExternalId;
                displayInDb.MeterReading = display.MeterReading;
            }

            _context.SaveChanges();

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //########################################################################################
        //########################################################################################
        //#Below are the classes for generating an alphanumeric ID with dashes and Epoch Numbers.#
        //########################################################################################
        //########################################################################################


        /// <summary>
        /// Generates an Alphanumeric String.
        /// </summary>
        /// <returns></returns>
        private string AlphaNumeric()
        {

            Random random = new Random();
            int length = 32;
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            string newABN = result.ToString();

            result.Length = 0;
            result.Capacity = 0;
            result.Clear();


            return newABN;

        }

        /// <summary>
        /// Gets the string from the Alphanumeric fnction and inserts dashes.
        /// The final format if: 8 digit - 4 digit - 4 digit - 4 digits - 8 digits
        /// </summary>
        /// <returns>String with dashes</returns>
        private string AddDash()
        {

            string id = AlphaNumeric();

            string result = "";



            string firstEight = id.Substring(0, 8);

            result += firstEight;

            string firstFour = id.Substring(8, 4);

            result += "-" + firstFour;


            string secondFour = id.Substring(12, 4);

            result += "-" + secondFour;


            string thirdFour = id.Substring(16, 4);

            result += "-" + thirdFour;


            string lastEight = id.Substring(20, 8);

            result += lastEight;


            return result;
        }

        /// <summary>
        /// Generates the current Date and Time in Epoch (Numbers)
        /// </summary>
        /// <returns></returns>
        private int GetEpochTime()
        {
            var utcDate = DateTime.Now.ToUniversalTime();
            long baseTicks = 621355968000000000;
            long tickResolution = 10000000;
            long epoch = (utcDate.Ticks - baseTicks) / tickResolution;
            long epochTicks = (epoch * tickResolution) + baseTicks;
            var date = new DateTime(epochTicks, DateTimeKind.Utc);
            return Convert.ToInt32(epoch.ToString());
        }








    }
}