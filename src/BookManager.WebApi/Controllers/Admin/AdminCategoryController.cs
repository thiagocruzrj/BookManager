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
    public class AdminCategoryController : ApiController
    {
        private readonly ICategoryAppService _categoryAppService;

        public AdminCategoryController(ICategoryAppService categoryAppService, INotificationHandler<DomainNotification> notifications,
            IMediatrHandler mediatr) : base(notifications, mediatr)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("all-categories")]
        public IActionResult GetAll()
        {
            return Response(_categoryAppService.GetCategories());
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("categories-manager")]
        public IActionResult Post(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(categoryViewModel);
            }

            _categoryAppService.Add(categoryViewModel);

            return Response(categoryViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("categories-manager")]
        public IActionResult Put(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(categoryViewModel);
            }

            _categoryAppService.Update(categoryViewModel);

            return Response(categoryViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("categories-manager")]
        public IActionResult Delete(Guid id)
        {
            _categoryAppService.Delete(id);

            return Response();
        }
    }
}
