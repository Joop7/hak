using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordzCheat.Models.Factories;
using WordzCheat.Models.Dictionaries;
using WordzCheat.Models.Matrix;

namespace WordzCheat.Controllers
{
    public class WordzCheatController : Controller
    {
        //
        // GET: /WordzCheat/

        public ActionResult Index()
        {
            string[] letters = "đ l a r i k s m v e a n ž c p t".Split(' ').Select(item => item.ToUpper()).ToArray();
            LetterMatrix matrix = new WordzLetterMatrix(letters);
            IWordDictionary dict = DictionaryFactory.GetDictionary(Language.HR);
            List<string> words = matrix.FindeWords(dict);
            ViewBag.Words = words;
            ViewBag.Size = words.Count;
            return View();
        }

    }
}
