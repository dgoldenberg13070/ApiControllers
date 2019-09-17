using System;
namespace ContactManagementApi.Models {

    public class Contact {
        public int ContactId { get; set; }       
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Company { get; set; }
        public string ProfileImage { get; set; }        
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }        
        public string WorkPhone { get; set; }
        public string PersonalPhone { get; set; }
        public string City { get; set; }       
        public string State { get; set; }
        public string Zip { get; set; }        
    }
}
