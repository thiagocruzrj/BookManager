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
    public class AdminBookController : ApiController
    {
        private readonly IBookAppService _bookAppService;

        public AdminBookController(IBookAppService bookAppService, INotificationHandler<DomainNotification> notifications,
            IMediatrHandler mediatr) : base(notifications, mediatr)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("all-books")]
        public IActionResult GetAll()
        {
            return Response(_bookAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("book-by-id")]
        public IActionResult GetById(Guid id)
        {
            var byId = _bookAppService.GetById(id);
            return Response(byId);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("book-by-isbn")]
        public IActionResult GetByIsbn(BookIdentificator isbn)
        {
            var byIsbn = _bookAppService.GetByIsbn(isbn);
            return Response(byIsbn);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("book-by-author")]
        public IActionResult GetByAuthor(Document cpf)
        {
            var byCpf = _bookAppService.GetByAuthor(cpf);
            return Response(byCpf);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("book-by-category")]
        public IActionResult GetByCategory(int code)
        {
            var byCategory = _bookAppService.GetByCategory(code);
            return Response(byCategory);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("book-manager")]
        public IActionResult Post(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(bookViewModel);
            }

            _bookAppService.Add(bookViewModel);

            return Response(bookViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("book-by-category")]
        public IActionResult Put(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(bookViewModel);
            }

            _bookAppService.Update(bookViewModel);

            return Response(bookViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("book-by-category")]
        public IActionResult Delete(Guid id)
        {
            _bookAppService.Delete(id);

            return Response();
        }
    }
}
