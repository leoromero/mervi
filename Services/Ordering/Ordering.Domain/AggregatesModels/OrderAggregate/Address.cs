using Mervi.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string Comments { get; private set; }
        public string Country { get; private set; }

        public Address(string street, string number, string city, string province, string country, string comments)
        {
            this.Street = street;
            this.Number = number;
            this.City = city;
            this.Province = province;
            this.Comments = comments;
            this.Country = country;
        }

        private Address() { }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return Number;
            yield return City;
            yield return Province;
            yield return Comments;
            yield return Country;
        }
    }
}
