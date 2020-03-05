using Models;
using Resources.Request;
using Resources.Response;
using Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICheckinLogsService
    {
        Task<CheckInResource> CreateAsync();
        Task<IEnumerable<CheckinLogsResource>> ReadAllAsync(string log);
    }
}