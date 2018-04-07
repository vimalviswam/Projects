using ResistorValueCalculator;
using OhmValueCalculator.Models;
using System;
using System.Web.Mvc;

namespace OhmValueCalculator.Controllers
{
    public class ResistorValueController : Controller
    {
        private IResistorValueCalculator resistorValueCalculator;

        public ResistorValueController(IResistorValueCalculator resistorValueCalculator)
        {
            this.resistorValueCalculator = resistorValueCalculator;
        }

        public ActionResult ResistorValue()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CalculateResistorValue(ResistorValueModel calcModel)
        {
            if (Enum.IsDefined(typeof(BandAColors), calcModel.bandAColor) &&
                Enum.IsDefined(typeof(BandBColors), calcModel.bandBColor) &&
                Enum.IsDefined(typeof(BandCColors), calcModel.bandCColor) &&
                Enum.IsDefined(typeof(BandDColors), calcModel.bandDColor))
            {
                try
                {
                    int result = resistorValueCalculator.CalculateResistorValue(calcModel.bandAColor.ToString(), calcModel.bandBColor.ToString(),
                    calcModel.bandCColor.ToString(), calcModel.bandDColor.ToString());
                    double tolerance = resistorValueCalculator.GetTolerance(calcModel.bandDColor.ToString());
                    return Json(new { Result = $"Resistor value: { result } Ohms +/- { tolerance } %" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(new { Result = $"An error occured while processing the request." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json(new { Result = "One or more of the input color code is invalid" }, JsonRequestBehavior.AllowGet);

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
    }
}