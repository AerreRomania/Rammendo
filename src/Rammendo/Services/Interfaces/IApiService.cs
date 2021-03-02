﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rammendo.Services.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<T>> GetAll<T>();

        Task<IEnumerable<T>> GetAllByFilter<T>(string[] filter);
    }
}