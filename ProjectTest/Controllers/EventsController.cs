using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Application.Features.Users.Requests.Commands;
using ProjectTest.Application.Features.Users.Requests.Queries;
using ProjectTest.Persistence.Services;
using ProjectTest.Persistence.Services.Interfaces;
using System.Globalization;
using ProjectTest.Domain;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using ProjectTest.Application.DTOs.MessageReportDto;
using ProjectTest.Application.Contracts.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MessageReportService _messageReportService;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        public IReportEventServiceRepository _reportEventServiceRepository;
        public EventsController(IMediator mediator, MessageReportService messageReportService,
            IReportEventServiceRepository reportEventServiceRepository, IEmailService emailService, ISmsService smsService)
        
        {
            _mediator = mediator;
            _messageReportService = messageReportService;
            _reportEventServiceRepository = reportEventServiceRepository;
            _emailService = emailService;
            _smsService = smsService;
        }

        [HttpPost]
        [Route("/SendMessageResult")]
        public async Task<IActionResult> CreateMessageEmail(Guid id)
        {
            var user = await _messageReportService.GetUser(id);
            
            return Ok(user);
        }

        //[HttpPost]
        //[Route("/SMS", Name = "Sms")]
        //public async Task<IActionResult> CreateMessageSms(Guid id)
        //{
        //    var user = await _messageReportService.GetUser(id);

        //    return Ok(user);
        //}
    }
}
