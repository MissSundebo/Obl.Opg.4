using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Opgave4RESTServiceBog.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opgave4RESTServiceBog.Controllers
{
    [Route("api/Bog")]
    [ApiController]
    public class BogController : Controller
    {
        // GET: /<controller>/
        /*public IActionResult Index()
        {
            return View();
        }*/

        // GET: api/Boeger
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return Boeger;
        }

        // GET: api/Boeger/5
        [HttpGet]
        [Route("Bog/{isbn}")]
        public Bog Get(string isbn)
        {
            return Boeger.Find(s => s.Isbn13 == isbn);
        }

        // POST: api/Boeger
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            Boeger.Add(value);
        }

        // PUT: api/Boeger/5
        [HttpPut]
        [Route("{isbn}")]
        public void Put(string isbn, [FromBody] Bog value)
        {
            Bog Bog = Get(isbn);
            if (Bog != null)
            {
                Bog = new Bog(value.Titel,value.Forfatter, value.Sidetal, value.Isbn13);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{isbn}")]
        public void Delete(string isbn)
        {
            Bog Bog = Get(isbn);
            Boeger.Remove(Bog);
        }

        private static List<Bog> Boeger = new List<Bog>()
        {
            new Bog("Harry Potter and the Prisoner of Azkaban", "J.K.Rowling", 480 , "0000000000001"),
            new Bog("Lord of the Rings", "J.R.R.Tolkien",576 , "0000000000002"),
            new Bog("Dracula", "Bram Stoker", 418, "0000000000003"),
            new Bog("Les Miserables", "Victor Hugo",1232 , "0000000000004"),
            new Bog("The Pillars of the Earth", "Ken Follett",806, "0000000000005"),
            new Bog("Sejrens triumf","Lars Jørgensen", 451, "0000000000006"),
            new Bog("Danmarks Oldtid", "Jørgen Jensen", 619, "0000000000007"),
            new Bog("Mammal Bones And Teeth", "Simon Hillson", 132, "0000000000008")
        };
    }
}
