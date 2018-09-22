﻿using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Entities
{
    public interface IServiceRotaEntityService
    {
        Task<List<ServiceRota>> GetAll();
        Task<ServiceRota> Get(int id);
    }
}
