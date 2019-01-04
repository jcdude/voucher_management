using MediatR;
using PTS.Application.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Service.Commands
{
    public class PurchaseCommand :  IRequest<PurchaseViewModel>
    {
        public Guid ExternalId { get; set; }
    }
}
