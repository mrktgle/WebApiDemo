using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using WebAPI.Models;

    /*
        Get =    Read
        Post =   Create
        Put =    Update
        Delete = Delete
    */

namespace WebAPI.Controllers
{
    /// <summary>
    /// This is where I give you all the information about my peeps.
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person {Id = 1, FirstName = "Mark", LastName = "Tagle"});
            people.Add(new Person { Id = 2, FirstName = "Alaine", LastName = "Castillo" });
            people.Add(new Person { Id = 3, FirstName = "Juan", LastName = "Luna" });
        }

        /// <summary>
        /// Get a list of the first names of all users.
        /// </summary>
        /// <param name="userId">The unique identifier for this person.</param>
        /// <param name="age">We want to know how old they are.</param>
        /// <returns>A list of first names...hehe</returns>
        [Route("api/People/GetFirstNames/{userId:int}/{age:int}")]
        [HttpGet]
        public List<string> GetFirstNames(int userId, int age)
        {
            List<string> output = new List<string>();

            foreach (var p in people)
            {
                output.Add(p.FirstName);
            }

            return output;
        }


        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(Person value)
        {
            people.Add(value);
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {

        }
    }
}
