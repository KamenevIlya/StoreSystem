using System;

namespace StoreSystem.Domain
{
    public class Client
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
