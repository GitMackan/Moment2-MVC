using Microsoft.AspNetCore.Mvc;
using Moment2.Models;
using Newtonsoft.Json;

namespace Moment2.Controllers
{
    public class MovieController : Controller
    {
        // Startsida
        public IActionResult Index()
        {
            // Kontrollera om cookie-nyckel "Name" har ett värde
            if (Request.Cookies["name"] != null)
            {
                // Lagra värde i ViewBag.Message
                ViewBag.Message = Request.Cookies["name"];
            }
            else
            {
                // Sätt tomt värde om ingen cookie finns
                ViewBag.Message = "";
            }

            // Sätt värden för TopMoviesPartial
            TopMoviesModel Top3 = new TopMoviesModel();
            Top3.First = "Sagan om ringen";
            Top3.Second = "Nyckeln till frihet";
            Top3.Third = "Batman - Dark Knight";
            // Skicka med partial till view
            return View(Top3);
        }

        // Lägga till användarnamn i startsida
        [HttpPost]
        public IActionResult Index(IFormCollection fc)
        {
            // Skapa nytt cookie-objekt
            CookieOptions options = new CookieOptions();
            // Ställ in hur länge cookie ska vara lagrad
            options.Expires = DateTime.Now.AddHours(12);
            // Lägg till cookie
            Response.Cookies.Append("name", fc["user"], options);
            // Ladda om sida
            return RedirectToAction("Index", "Movie");
        }

        // Filmer
        public IActionResult Movies()
        {
            // Hämta data från JSON-fil
            var JsonStr = System.IO.File.ReadAllText("movies.json");
            // Deserialize hämtad data
            var JsonObj = JsonConvert.DeserializeObject<List<MovieModel>>(JsonStr);
            return View(JsonObj);
        }

        // Lägg till film-sida
        public IActionResult Add()
        {
            return View();
        }

        // Lägg till film
        [HttpPost]
        public IActionResult Add(MovieModel model)
        {
            // Kontrollera inputs
            if (ModelState.IsValid)
            {
                var JsonStr = System.IO.File.ReadAllText("movies.json");
                var JsonObj = JsonConvert.DeserializeObject<List<MovieModel>>(JsonStr);

                // Lägg till film till List om JsonObj inte är null
                if (JsonObj != null)
                {
                    JsonObj.Add(model);
                }

                // Lägg till film till JSON-fil
                System.IO.File.WriteAllText("movies.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                // Skicka till Filmsidan
                return RedirectToAction("Movies", model);
            }
            return View();
        }

        // Kontaktsidan
        // Ändra sökväg
        [HttpGet("/contact")]
        public IActionResult Contact()
        {
            // Skapa värden för ContactPartial och MessagePartial
            ContactModel co = new ContactModel();
            co.FullName = "Marcus Nygård";
            co.Address = "Sigfrid Edströms Gata 25B";
            co.Zip_Code = "72566";
            co.City = "Västerås";
            co.Email = "many2005@student.miun.se";
            co.Phone = "07X-8582662";
            ViewData["msg"] = "Vänligen kontakta mig vid eventuella frågor eller funderingar";
            return View(co);
        }
    }
}