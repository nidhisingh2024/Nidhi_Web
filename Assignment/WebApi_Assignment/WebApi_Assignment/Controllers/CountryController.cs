using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Assignment.Models;
namespace WebApi_Assignment.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>()
        {
            new Country { CountryId = 1, CountryName = "INDIA",  CountryCapital= "New-Delhi" },
            new Country { CountryId = 2, CountryName = "China", CountryCapital = "Beijing" },
            new Country { CountryId = 3, CountryName = "Denmark", CountryCapital = "Copenhagen" }
        };
       
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return countries;
        }

       
        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.CountryId == id);
            if (country == null)
                return NotFound();
            return Ok(country);
        }

   
        public IHttpActionResult Post(Country country)
        {
            country.CountryId = countries.Count + 1;
            countries.Add(country);
            return CreatedAtRoute("DefaultApi", new { id = country.CountryId }, country);
        }

       
        public IHttpActionResult Put(int id, Country country)
        {
            var existingCountry = countries.FirstOrDefault(c => c.CountryId == id);
            if (existingCountry == null)
                return NotFound();

            existingCountry.CountryName = country.CountryName;
            existingCountry.CountryCapital = country.CountryCapital;

            return StatusCode(HttpStatusCode.NoContent);
        }

   
        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.CountryId == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return Ok(country);
        }
    }
}

