using AutoMapper;
using ProjectTest.Application.Contracts.Persistence;
using ProjectTest.Application.DTOs.MessageReportDto;
using ProjectTest.Application.DTOs.UserDto;
using ProjectTest.Domain;
using ProjectTest.Persistence.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Persistence.Services
{
    public class SmsService: ISmsService
    {
        public IReportEventServiceRepository _reportEventServiceRepository;
        public MessageReportService _messageReportService;
        public IMapper _mapper;
        public SmsService(IReportEventServiceRepository reportEventServiceRepository, MessageReportService messageReportService, IMapper mapper)
        {
            _reportEventServiceRepository = reportEventServiceRepository;
            _mapper = mapper;
            _messageReportService = messageReportService;
            _messageReportService.UserRetrieved += OnMessageReport;

        }
        private async void OnMessageReport(object? sender, MessageReportEventArgs e)
        {
            await CreateMessageResult(e.User);
        }
        public async Task CreateMessageResult(UserJoinPassportDto user)
        {
            var message = _mapper.Map<EventMessageResult>(new CreateMessageResultDto { EventId = 2, Message = $"User {user.FirstName} subscribed by SMS" });
            await _reportEventServiceRepository.Add(message);
        }
    }
}
