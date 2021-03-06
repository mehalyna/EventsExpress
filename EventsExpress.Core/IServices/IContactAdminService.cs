﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventsExpress.Core.DTOs;
using EventsExpress.Db.Enums;

namespace EventsExpress.Core.IServices
{
    public interface IContactAdminService
    {
        Task<Guid> SendMessageToAdmin(ContactAdminDto contactAdminDto);

        IEnumerable<ContactAdminDto> GetAll(ContactAdminFilterViewModel model, out int count);

        Task UpdateIssueStatus(Guid messageId, string resolutionDetails, ContactAdminStatus issueStatus);

        ContactAdminDto MessageById(Guid messageId);
    }
}
