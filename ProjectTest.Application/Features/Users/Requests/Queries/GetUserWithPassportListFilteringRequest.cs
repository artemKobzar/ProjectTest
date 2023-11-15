using MediatR;
using ProjectTest.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.Features.Users.Requests.Queries
{
    public class GetUserWithPassportListFilteringRequest : IRequest<List<UserJoinPassportDto>>
    {
        public string SearchTerm { get; set; }
        public string SortColumn{ get; set; }
        public string SortOrder { get; set; }
        public GetUserWithPassportListFilteringRequest(string? searchTerm, string? sortColumn, string? sortOrder)
        {
            SearchTerm = searchTerm;
            SortColumn = sortColumn;
            SortOrder = sortOrder;
        }
    }
}
