namespace Core.Entities.OrderAggregate
{
    public class Address
    {
        public Address()
        {
            
        }
        public Address(string fisrtname, string lastName, string street, string city, string state, string zipCode)
            {
                Fisrtname = fisrtname;
                LastName = lastName;
                Street = street;
                City = city;
                State = state;
                ZipCode = zipCode;
            }
         public string  Fisrtname { get; set; }
         public string  LastName { get; set; }
         public string  Street { get; set; }
        public string  City { get; set; }
         public string  State { get; set; }
         public string  ZipCode { get; set; }
        
    }
}