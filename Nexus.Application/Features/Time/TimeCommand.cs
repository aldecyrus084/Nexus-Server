using MediatR;
using Nexus.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Features.AddTime
{
    public class TimeCommand : IRequest<GenericResponseDTO<TimeResponseDTO>>
    {
        public Guid PCId { get; set; }
        public Guid CustomerId { get; set; }
        public int AmountInserted { get; set; }
    }
}
