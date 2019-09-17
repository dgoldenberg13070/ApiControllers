using System.Collections.Generic;

namespace ContactManagementApi.Models {

    public interface IRepository {

        IEnumerable<Contact> Contacts { get; }
                
        //Create a contact record
        Contact AddContact(Contact contact);

        //Retrieve a contact record
        Contact this[int id] { get; }

        //Update a contact record
        Contact UpdateContact(Contact contact);

        //Delete a contact record
        void DeleteContact(int id);
        
    }
}
