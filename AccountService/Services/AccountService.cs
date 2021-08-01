using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService
{
    public class AccountService : Account.AccountBase
    {
        private readonly ILogger<AccountService> _logger;

        public AccountService(ILogger<AccountService> logger)
        {
            _logger = logger;
        }

        public override Task<UserSetResponse> SetUser(UserSetRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserSetResponse
            {
                Success = true
            });

            //return new UserSetResponse
            //{
            //    Success = true
            //});
        }

        public override Task<UserGetResponse> GetUser(UserGetRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserGetResponse
            {
                Success = true
            });
        }

        public override Task<PasswordResetRequestResponse> ResetPasswordRequest(PasswordResetRequest request, ServerCallContext context)
        {
            return Task.FromResult(new PasswordResetRequestResponse
            {
                Success = true
            });
        }

        public override Task<PasswordSetResponse> SetPassword(PasswordSetRequest request, ServerCallContext context)
        {
            return Task.FromResult(new PasswordSetResponse
            {
                Success = true
            });
        }
    }
}
