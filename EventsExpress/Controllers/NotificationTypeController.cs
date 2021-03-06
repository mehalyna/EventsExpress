﻿using System.Collections.Generic;
using AutoMapper;
using EventsExpress.Core.IServices;
using EventsExpress.Policies;
using EventsExpress.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsExpress.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = PolicyNames.UserPolicyName)]
    [ApiController]
    public class NotificationTypeController : Controller
    {
        private readonly INotificationTypeService _notificationTypeService;
        private readonly IMapper _mapper;

        public NotificationTypeController(
            INotificationTypeService notificationTypeService,
            IMapper mapper)
        {
            _notificationTypeService = notificationTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// This method have to return all notifications.
        /// </summary>
        /// <returns>The method returns all notifications.</returns>
        /// <response code="200">Return IEnumerable NotificationTypeDto model.</response>
        [HttpGet("[action]")]
        public IActionResult All()
        {
            return Ok(_mapper.Map<IEnumerable<NotificationTypeViewModel>>(_notificationTypeService.GetAllNotificationTypes()));
        }
    }
}
