using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI_Assignment.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace WebAPI_Assignment.Controllers
{
    
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>()
        {

        };
        // GET: Country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return countries;
        }

        // GET: api/Country/5
        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();
            return Ok(country);
        }

        // POST: api/Country
        public IHttpActionResult Post(Country country)
        {
            country.ID = countries.Count + 1;
            countries.Add(country);
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        // PUT: api/Country/5
        public IHttpActionResult Put(int id, Country country)
        {
            var existingCountry = countries.FirstOrDefault(c => c.ID == id);
            if (existingCountry == null)
                return NotFound();

            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Country/5
        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return Ok(country);
        }
    }
}