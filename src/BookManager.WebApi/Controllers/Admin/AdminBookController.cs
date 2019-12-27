using AutoMapper;
using BookManager.Application.Services;
using BookManager.Application.ViewModels;
using BookManager.Core.Communication.MediatR;
using BookManager.Core.DomainObjects.ValueObjects;
using BookManager.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.WebApi.Controllers.Admin
{
    public class AdminBookController : ApiController
    {
        private readonly IBookAppService _bookAppService;

        public AdminBookController(IBookAppService bookAppService, INotificationHandler<DomainNotification> notifications,
            IMediatrHandler mediatr) : base(notifications, mediatr)
        {
            _bookAppService = bookAppService;
        }
    }
}
