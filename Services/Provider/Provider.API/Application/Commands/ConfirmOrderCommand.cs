using MediatR;
using Provider.API.Application.Model;
using Provider.API.Extensions;
using Provider.DTOs.OrderAggregateDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Provider.API.Application.Commands
{
    [DataContract]
    public class ConfirmOrderCommand
        : IRequest<bool>
    {
        [DataMember]
        public int OrderId { get; private set; }

        [DataMember]
        public string Comments { get; private set; }

        [DataMember]
        public DateTime OrderDate{ get; private set; }

        [DataMember]
        public string ProviderId { get; internal set; }
        
        public ConfirmOrderCommand(int orderId, string providerId, DateTime orderDate)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            ProviderId = providerId;
        }
    }
}
