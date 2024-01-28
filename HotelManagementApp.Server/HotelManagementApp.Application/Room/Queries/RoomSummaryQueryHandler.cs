using ErrorOr;
using HotelManagementApp.Application.Authentication.Queries.Login;
using HotelManagementApp.Application.Common.Interfaces.Persistence;
using HotelManagementApp.Application.DTOs;
using Mapster;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementApp.Application.Room.Queries
{
    internal class RoomSummaryQueryHandler : IRequestHandler<RoomSummaryQuery, List<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;

        public RoomSummaryQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<RoomDto>> Handle(RoomSummaryQuery request, CancellationToken cancellationToken)
        {
            var rooms = _roomRepository.GetRooms();

            var roomsDto = rooms.Adapt<List<RoomDto>>();
            return roomsDto;
        }

    }
}
