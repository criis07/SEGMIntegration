using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Amazon.SecurityToken.Model;
using AutoMapper.Internal;
using Lafise.SEGMIntegration.Application.Common.Interfaces;
using Lafise.SEGMIntegration.Domain.Entities.SEGM;
using LAFISE.CrossCutting.Core.Entities;
using LAFISE.CrossCutting.Core.Exceptions;
using LAFISE.CrossCutting.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using StackExchange.Profiling.Internal;

namespace Lafise.SEGMIntegration.Infrastructure.Services.SEGMService
{
    public class SEGMService : ISEGMService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ILogger<SEGMService> _logger;

        public SEGMService(HttpClient httpClient, IConfiguration config, ILogger<SEGMService> logger)
        {
            _httpClient = httpClient;
            _config = config;
            _logger = logger;
        }

        public class AuthenticationRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public async Task<AuthResponse> AuthMethod()
        {
            var url = $"{_config[$"SEGM:ApiUrl"]}/api/Account/DoLogIn";
            var email = _config["SEGM:Email"].ToString();
            var password = _config["SEGM:Password"].ToString();
            var options = new RestClientOptions(url);
            using var client = new RestClient(options);

            var request = new RestRequest("").AddBody(new AuthenticationRequest { Email = email, Password = password });

            var response = await client.PostAsync<AuthResponse>(request);

            if (response?.data?.jwToken == null)
            {
                throw new ErrorException("", "400", "Error en la autenticación, acceso denegado");
            }
            return response;

        }

        public async Task<Result<SecurityInterestsTypes>> GetTypesSecurityInterest()
        {
            try
            {
                var url = $"{_config[$"SEGM:ApiUrl"]}/api/TipoGarantiaMobiliaria";
                var result = await _httpClient.GetAsync(url);
                var content = await result.Content.ReadAsStringAsync();
                var securityInterestsTypes = JsonConvert.DeserializeObject<SecurityInterestsTypes>(content);
                return new Result<SecurityInterestsTypes>(securityInterestsTypes, true, "", "");
            }
            catch (As400ApiResponseException ex)
            {
                var errorCode = ex.SqlState.SQLStateInfo.SQLError.SQLState;
                var errorMessage = ex.SqlState.SQLStateInfo.SQLError.message;

                _logger.LogError(ex, $"{errorCode} => {errorMessage}");

                return new Result<SecurityInterestsTypes>(null, false, errorCode.GetErrorCode(), errorMessage.GetErrorMessage());
            }
        }

        public async Task<Result<NoticesTypes>> GetRegistrationNoticeTypes()
        {
            try
            {
                var authData = await AuthMethod();
                var url = $"{_config[$"SEGM:ApiUrl"]}/api/TipoAvisosInscripcion/GetAllTipoAvisosInscripcion";
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", $"Bearer {authData?.data?.jwToken} ");
                var result = await _httpClient.SendAsync(requestMessage);
                var content = await result.Content.ReadAsStringAsync();
                var noticesTypes = JsonConvert.DeserializeObject<NoticesTypes>(content);
                return new Result<NoticesTypes>(noticesTypes, true, "", "");
            }
            catch (As400ApiResponseException ex)
            {
                var errorCode = ex.SqlState.SQLStateInfo.SQLError.SQLState;
                var errorMessage = ex.SqlState.SQLStateInfo.SQLError.message;

                _logger.LogError(ex, $"{errorCode} => {errorMessage}");

                return new Result<NoticesTypes>(null, false, errorCode.GetErrorCode(), errorMessage.GetErrorMessage());
            }
        }
    }
}
