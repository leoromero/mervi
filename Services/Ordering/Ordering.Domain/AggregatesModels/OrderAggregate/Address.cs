using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregatesModels.OrderAggregate
{
    public class Address
    {
        private string street;
        private string Number;
        private string city;
        private string province;
        private string Comments;
        private string country;

        public Address(string street, string number, string city, string province, string country, string comments)
        {
            this.street = street;
            this.Number = number;
            this.city = city;
            this.province = province;
            this.Comments = comments;
            this.country = country;
        }
    }
}
