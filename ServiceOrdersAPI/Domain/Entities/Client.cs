using System.ComponentModel.DataAnnotations;

namespace ServiceOrdersManagement.Domain.Entities
{
    public class Client(string name, string document, string email, string phone)
    {
        public string Name { get; private set; } = name;
        public string Document { get; private set; } = document;
        public string Email { get; private set; } = email;
        public string Phone { get; private set; } = phone;
    }

}
