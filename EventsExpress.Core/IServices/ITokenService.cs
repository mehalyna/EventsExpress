﻿using EventsExpress.Core.DTOs;
using EventsExpress.Db.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventsExpress.Core.IServices
{
    public interface ITokenService
    {
        string GenerateAccessToken(UserDTO user);
        RefreshToken GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<AuthenticateResponseModel> RefreshToken(string token);
        void SetTokenCookie(string token);

    }
}