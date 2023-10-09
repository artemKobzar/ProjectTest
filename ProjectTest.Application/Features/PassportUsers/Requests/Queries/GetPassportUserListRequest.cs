using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectTest.Application.DTOs.PassportUserDto;

namespace ProjectTest.Application.Features.PassportUsers.Requests.Queries
{
    public class GetPassportUserListRequest: IRequest<List<PassportUserListDto>>
    {

    }
}
