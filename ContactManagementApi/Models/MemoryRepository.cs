using System;
using System.Collections.Generic;

namespace ContactManagementApi.Models {

    public class MemoryRepository : IRepository {

        private Dictionary<int, Contact> items;
      
        public MemoryRepository() {
            items = new Dictionary<int, Contact>();
            new List<Contact> {
                new Contact {FirstName = "Rick", LastName = "Danko", Company = "Acme", ProfileImage = "c:\\rick_danko.jpg", Email = "rick.danko@acme.com", BirthDate = new DateTime(1950,7,15), WorkPhone = "555-555-5555", PersonalPhone = "555-555-1234", City = "Chicago", State = "Illinois", Zip = "60648"},
                new Contact {FirstName = "Robbie", LastName = "Robertson", Company = "Acme", ProfileImage = "c:\\robbie_robertson.jpg", Email = "robbie.robertson@acme.com", BirthDate = new DateTime(1950,3,25), WorkPhone = "555-555-5555", PersonalPhone = "555-555-1232", City = "New York", State = "New York", Zip = "60648"},
                new Contact {FirstName = "Garth", LastName = "Hudson", Company = "Acme", ProfileImage = "c:\\garth_hudson.jpg", Email = "garth.hudson@acme.com", BirthDate = new DateTime(1940,9,18), WorkPhone = "555-555-5555", PersonalPhone = "555-555-1324", City = "Chicago", State = "Illinois", Zip = "60648"},
                new Contact {FirstName = "Levon", LastName = "Helm", Company = "Acme", ProfileImage = "c:\\levon_helm.jpg", Email = "levon.helm@acme.com", BirthDate = new DateTime(1952,2,15), WorkPhone = "555-555-5555", PersonalPhone = "555-555-1254", City = "Glenview", State = "Illinois", Zip = "60648"},
                new Contact {FirstName = "Richard", LastName = "Manuel", Company = "Acme", ProfileImage = "c:\\richard_manuel.jpg", Email = "richard.manuel@acme.com", BirthDate = new DateTime(1960,2,12), WorkPhone = "555-555-5555", PersonalPhone = "555-555-4352", City = "Austin", State = "Texas", Zip = "60648"}
            }.ForEach(c => AddContact(c));
        }
        
        public IEnumerable<Contact> Contacts => items.Values;

        //Create a contact record
        public Contact AddContact(Contact contact)
        {
            if (contact.ContactId == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                contact.ContactId = key;
            }
            items[contact.ContactId] = contact;
            return contact;
        }

        //Retrieve a contact record
        public Contact this[int id] => items.ContainsKey(id) ? items[id] : null;

        //Update a contact record
        public Contact UpdateContact(Contact contact)
        {
            return AddContact(contact);
        }

        //Delete a contact record
        public void DeleteContact(int id)
        {
            items.Remove(id);
        }

    }
}
