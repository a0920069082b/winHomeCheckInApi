using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Models;
using Repositories.IRepositories;
using Resources.Response;
using Services.Communication;
using Services.IServices;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using Microsoft.Extensions.Configuration;
using Utils;
using Resources.Request;

namespace Services
{

    public class CheckinLogsService : ICheckinLogsService
    {
        private readonly ICheckinLogsRepository _CheckinLogsRepository;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _accessor;
        private readonly IConfiguration _config;

        public CheckinLogsService(ICheckinLogsRepository CheckinLogsRepository, IMapper mapper, IHttpContextAccessor accessor, IConfiguration configuration)
        {
            this._CheckinLogsRepository = CheckinLogsRepository ??
                throw new ArgumentNullException(nameof(CheckinLogsRepository));

            this._mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            this._accessor = accessor ??
                throw new ArgumentNullException(nameof(accessor));

            this._config = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<CheckInResource> CreateAsync()
        {
            // Get User ID
            var Request = _accessor.HttpContext.Request;
            string Token = Request.Headers["Authorization"];
            var jwtArr = Token.Split('.');
            var PayLoad = JsonConvert.DeserializeObject<Dictionary<string, object>>(Base64UrlEncoder.Decode(jwtArr[1]));
            var user = await _CheckinLogsRepository.FindUserID(PayLoad["nameid"].ToString());
            // Get Client IP
            WebClient webClient = new WebClient();
            var user_ip = webClient.DownloadString("https://api.ipify.org");
            // Get ServerIP
            GetIPAddressUtils CreateIP = new GetIPAddressUtils();
            string ServerIP = CreateIP.GetIPAddress(); //撈取本機電腦IP

            CheckinLogsModels CheckinLogs = new CheckinLogsModels
            {
                user_id = user.user_id,
                ip = user_ip,
                create_user_id = user.user_id,
                update_user_id = user.user_id,
                create_time = DateTime.Now,
                update_time = DateTime.Now,
            };


            // bool in_company = user_ip.Contains(this._config["IP"]);
            // if (in_company) {
            //     int index = user_ip.IndexOf(this._config["IP"]);
            //     if (index == 0) {
            //         CheckinLogs.ip = user_ip;
            //     }
            // }

            // if (CheckinLogs.ip == null) {
            //     return new SaveCheckinLogsResponse("IP is invalid");
            // }

            await _CheckinLogsRepository.CreateAsync(CheckinLogs);

            CheckInResource CheckIn = new CheckInResource
            {
                ServerIP = ServerIP,
                ClientIP = user_ip,
            };


            return CheckIn;
        }

        public async Task<IEnumerable<CheckinLogsResource>> ReadAllAsync(string log)
        {
            var CheckinLogs = await _CheckinLogsRepository.ReadAllAsync(log);
            var resources = _mapper.Map<IEnumerable<CheckinLogsModels>, IEnumerable<CheckinLogsResource>>(CheckinLogs);
            return resources;
        }
    }
}