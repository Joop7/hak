using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordzCheat.Models.Factories;
using WordzCheat.Models.Dictionaries;
using WordzCheat.Models.Matrix;
using WordzCheat.Properties;

namespace WordzCheat.Controllers
{
    public class WordzCheatController : Controller
    {
        //
        // GET: /WordzCheat/

        public ActionResult Index()
        {
            string[] letters = "t i i l t i u ž o s a p o n d s".Split(' ').Select(item => item.ToUpper()).ToArray();
            string[] delimiter = new string[] { "\r\n" };
            List<string> dict = Resources.HRdict.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToList();;
            TestMatrix matrix = new TestMatrix(letters);
            List<string> words = matrix.FindWords(dict);
            ViewBag.Words = words;
            ViewBag.Size = words.Count;
            return View();
        }

    }
}
