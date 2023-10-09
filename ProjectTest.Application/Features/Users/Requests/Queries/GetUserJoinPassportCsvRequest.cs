using MediatR;
using ProjectTest.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Features.Users.Requests.Queries
{
    public class GetUserJoinPassportCsvRequest: IRequest<List<UserJoinPassportDto>>
    {
    }
}
