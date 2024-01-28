using ErrorOr;
using HotelManagementApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementApp.Application.Room.Queries
{
    public class RoomSummaryQuery : IRequest<List<RoomDto>>
    {
    }
}
