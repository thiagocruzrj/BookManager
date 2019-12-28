using BookManager.Application.Services;
using BookManager.Application.ViewModels;
using BookManager.Core.Communication.MediatR;
using BookManager.Core.DomainObjects.ValueObjects;
using BookManager.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookManager.WebApi.Controllers.Admin
{
    public class AdminAuthorController : ApiController
    {
        private readonly IAuthorAppService _authorAppService;

        public AdminAuthorController(IAuthorAppService authorAppService, INotificationHandler<DomainNotification> notifications,
            IMediatrHandler mediatr) : base(notifications, mediatr)
        {
            _authorAppService = authorAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("all-authors")]
        public IActionResult GetAll()
        {
            return Response(_authorAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("author-by-id")]
        public IActionResult GetById(Guid id)
        {
            var byId = _authorAppService.GetById(id);
            return Response(byId);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("author-by-cpf")]
        public IActionResult GetByAuthor(Document cpf)
        {
            var byCpf = _authorAppService.GetByDoc(cpf);
            return Response(byCpf);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("author-manager")]
        public IActionResult Post(AuthorViewModel authorViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(authorViewModel);
            }

            _authorAppService.Add(authorViewModel);

            return Response(authorViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("author-manager")]
        public IActionResult Put(AuthorViewModel authorViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(authorViewModel);
            }

            _authorAppService.Update(authorViewModel);

            return Response(authorViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("author-manager")]
        public IActionResult Delete(Guid id)
        {
            _authorAppService.Delete(id);

            return Response();
        }
    }
}
