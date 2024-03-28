using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.DTOs.PassportUserDto;
using ProjectTest.Application.Features.Users.Requests.Queries;
using System.Text;
using ProjectTest.Persistence.Repositories;
using ProjectTest.Application.Contracts.MailSender;
using ProjectTest.Application.Models.MailSender;
using ProjectTest.Application.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using ProjectTest.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvExportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CsvExportController(IMediator mediator, IEmailSender emailSender, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }
        //[HttpPost]
        //[Route("/ExportCsv", Name = "Csv")]
        //public async Task<ActionResult<List<UserDto>>> ExportCsv()
        //{
        //    var users = await _mediator.Send(new GetUserListCsvRequest());

        //    string path = @".\CSV\file.csv";

        //    using (var writer = new StreamWriter(path, false))
        //    {
        //        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        //        {
        //            Delimiter = ";"
        //        };
        //        using (var csv = new CsvWriter(writer, csvConfig))
        //        {
        //            csv.WriteRecords(users);
        //        }
        //    }
        //    return Ok();
        //}
        [HttpPost]
        [Route("/ExportCsvJoin", Name = "ExportCsvJoin")]
        public async Task<ActionResult<List<UserJoinPassportDto>>> ExportCsvJoin()
        {
            var users = await _mediator.Send(new GetUserListCsvRequest());

            string path = @".\CSVJoin\file.csv";

            using (var writer = new StreamWriter(path, false))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var csv = new CsvWriter(writer, csvConfig))
                {
                    csv.WriteRecords(users);
                }
            }
            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("/ExportCsvString", Name = "ExportCsv")]
        public async Task<ActionResult<List<UserDto>>> ExportCsv(StringBuilder item)
        {
            var users = await _mediator.Send(new GetUserListCsvRequest());
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"\"First Name\", \"Last Name\", \"Phone Number\", \"Address\", \"Gender\", \"Nationality\"");
            foreach (var user in users) 
            {
                stringBuilder.AppendLine($"\"{user.FirstName}\",\"{user.LastName}\", \"{user.PhoneNumber}\", \"{user.Address}\", \"{user.Gender}\", \"{user.Nationality}\"");
            }
            var useR = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var email = new Email
            {
                To = "kobzar-artem90@ukr.net",
                Body = $"User with username: ''{useR.ToUpper()}'' has generated and downloaded CSV file with user's data",
                Subject = "Warning!"
            };
            await _emailSender.SendEmail(email);
            return File(Encoding.UTF8.GetBytes(stringBuilder.ToString()), "application/csv", "user.csv");
        }

        [HttpGet]
        [Route("/GenerateCsvString", Name = "CsvGenerator")]
        public async Task<ActionResult<List<UserJoinPassportDto>>> Generate()
        {
            var users = await _mediator.Send(new GetUserJoinPassportCsvRequest());
            new CsvGenerator<UserJoinPassportDto>(users, "users").Generate();
            return Ok();
        }

        [HttpGet]
        [Route("/GetFile")]
        public async Task<ActionResult<HttpRequestMessage>> GetFile()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "CSV/file.csv");
            //var stream = new FileStream(filePath, FileMode.Open);
            string fileType = "application/csv";
            return PhysicalFile(filePath, fileType, "file.csv");
        }

        [HttpGet]
        [Route("/GetFileJoin")]
        public async Task<ActionResult<HttpRequestMessage>> GetFileJoin()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "CSVJoin/file.csv");
            //var stream = new FileStream(filePath, FileMode.Open);
            string fileType = "application/csv";
            return PhysicalFile(filePath, fileType, "file.csv");
        }
    }
}

