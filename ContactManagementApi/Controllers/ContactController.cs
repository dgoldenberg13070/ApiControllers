using Microsoft.AspNetCore.Mvc;
using ContactManagementApi.Models;
using System.Linq;
using System.Collections.Generic;

namespace ContactManagementApi.Controllers {

    [Route("api/[controller]")]
    public class ContactController : Controller {

        private IRepository repository;

        public ContactController(IRepository repo)
        {
            repository = repo;
        }

        //Create a contact record
        //example http request: Invoke-RestMethod http://localhost:7000/api/contact -Method POST -Body (@{firstName="John"; lastName="Doe"; company="Acme"; profileImage="c:\\john_doe.jpg";email="john.doe@acme.com";birthDate="01/12/1960";workPhone="555-555-3000";personalPhone="555-555-2342";city="Des Plaines";state="Illinois";zip="60014"} | ConvertTo-Json) -ContentType "application/json"
        [HttpPost]
        public Contact Post([FromBody] Contact con)
        {
            return repository.AddContact(new Contact
            {
                FirstName = con.FirstName,
                LastName = con.LastName,
                Company = con.Company,
                ProfileImage = con.ProfileImage,
                Email = con.Email,
                BirthDate = con.BirthDate,
                WorkPhone = con.WorkPhone,
                PersonalPhone = con.PersonalPhone,
                City = con.City,
                State = con.State,
                Zip = con.Zip
            });
        }

        //Retrieve a contact record
        //example http request: Invoke-RestMethod http://localhost:7000/api/contact/2 -Method GET
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return repository[id];
        }

        //Update a contact record
        //example http request: Invoke-RestMethod http://localhost:7000/api/contact -Method PUT -Body (@{contactId="3";firstName="Levon"; lastName="Helm"; company="Acme"; profileImage="c:\\levon_helm.jpg";email="levon.helm@acme.com";birthDate="01/16/1936";workPhone="555-555-3000";personalPhone="555-555-3332";city="Chicago";state="Illinois";zip="60014"} | ConvertTo-Json) -ContentType "application/json"
        [HttpPut]
        public Contact Put([FromBody] Contact con)
        {
            return repository.UpdateContact(con);
        }

        //Delete a contact record
        //example http request: Invoke-RestMethod http://localhost:7000/api/contact/2 -Method DELETE
        [HttpDelete("{id}")]
        public void Delete(int id) {
            repository.DeleteContact(id);
        }
        
        //Search for record(s) by email, phone, state or city.
        //example http request: Invoke-RestMethod http://localhost:7000/api/contact?email=robbie.robertson@acme.com -Method GET
        //example http request: Invoke-RestMethod http://localhost:7000/api/contact?personalPhone=555-555-1232 -Method GET
        //example http request: Invoke-RestMethod http://localhost:7000/api/contact?state=Illinois -Method GET
        //example http request: Invoke-RestMethod http://localhost:7000/api/contact?state=Chicago -Method GET
        [HttpGet]
        public IEnumerable<Contact> Get(string email, string personalPhone, string state, string city)
        {
            if (email != null)
            {
                return repository.Contacts.Where(c => c.Email == email).ToList();
            }
            else if (personalPhone != null)
            {
                return repository.Contacts.Where(c => c.PersonalPhone == personalPhone).ToList();
            }
            else if (state != null)
            {
                return repository.Contacts.Where(c => c.State == state).ToList();
            }
            else
            {
                return repository.Contacts.Where(c => c.City == city).ToList();
            }
        }

    }
}
