using Farfetch.Domain.HttpServices;
using Microsoft.AspNetCore.Mvc;

namespace Farfetch.Domain.Services.Contracts.Tasks
{
    public interface IAuthorizationFilterServiceTask
    {
        bool Validate(string rota, string authorization);        
    }
}
