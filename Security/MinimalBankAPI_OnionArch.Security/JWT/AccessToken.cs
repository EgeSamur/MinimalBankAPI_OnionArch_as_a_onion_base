﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalBankAPI_OnionArch.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }

        public AccessToken()
        {
            Token = string.Empty;
            RefreshToken = string.Empty;
        }

        public AccessToken(string token, DateTime expiration, string refreshToken, DateTime refreshTokenExpiration)
        {
            Token = token;
            Expiration = expiration;
            RefreshToken = refreshToken;
            RefreshTokenExpiration = refreshTokenExpiration;
        }
    }
}
