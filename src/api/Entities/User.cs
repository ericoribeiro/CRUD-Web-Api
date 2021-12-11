using System;

namespace api.Entities
{
    public class User
    {
        public Guid ID {get;set;}
        public string Email {get;set;}
        public string Name {get;set;}
        public string Password {get;set;}
        public string Role {get;set;}
        public bool Active {get;set;}
    }
}