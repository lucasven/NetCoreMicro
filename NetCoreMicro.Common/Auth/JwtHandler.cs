using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NetCoreMicro.Common.Auth
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        public readonly JwtOptions options;
        private readonly SecurityKey issuerSiginigKey;
        private readonly SigningCredentials signingCredentials;
        private readonly JwtHeader jwtHeader;
        private readonly TokenValidationParameters tokenValidationParameters;

        public JwtHandler(IOptions<JwtOptions> _options)
        {
            options = _options.Value;
            issuerSiginigKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));
            signingCredentials = new SigningCredentials(issuerSiginigKey, SecurityAlgorithms.HmacSha256);
            jwtHeader = new JwtHeader(signingCredentials);
            tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = options.Issuer,
                IssuerSigningKey = issuerSiginigKey
            };
        }


        public JsonWebToken Create(Guid userId)
        {
            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddMinutes(options.ExpiryMinutes);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            var now = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            var payload = new JwtPayload
            {
                {"sub", userId },
                {"iss", options.Issuer},
                {"iat", now},
                {"exp", exp},
                {"unique_name", userId}
            };

            var jwt = new JwtSecurityToken(jwtHeader, payload);
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new JsonWebToken
            {
                Token = token,
                Expires = exp
            };
        }
    }
}
