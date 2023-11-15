using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.MessageReportDto;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Domain;
using ProjectTest.Persistence.Repositories;
using ProjectTest.Persistence.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Persistence.Services
{
    public class EmailService: IEmailService
    {
        public IReportEventServiceRepository _reportEventServiceRepository;
        public IMapper _mapper;
        public MessageReportService _messageReportService;

        public EmailService(IReportEventServiceRepository reportEventServiceRepository, MessageReportService messageReportService, IMapper mapper)
        {
            _reportEventServiceRepository = reportEventServiceRepository;
            _mapper = mapper;
            _messageReportService = messageReportService;
            _messageReportService.UserRetrieved += OnMessageReport;
        }
        public async void OnMessageReport(object? sender, MessageReportEventArgs e)
        {
            //UserDto user = e.User;
            CreateMessageResult(e.User);
            //var message = _mapper.Map<EventMessageResult>();
            //message = _reportEventServiceRepository.Add(message);
        }
        public async Task CreateMessageResult(UserJoinPassportDto user)
        {
            var message = _mapper.Map<EventMessageResult>(new CreateMessageResultDto { EventId = 1, Message = $"User {user.FirstName} subscribed by Email" });
            await _reportEventServiceRepository.Add(message);
        }
    }
}
