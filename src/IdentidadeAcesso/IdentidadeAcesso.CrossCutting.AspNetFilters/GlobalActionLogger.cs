using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Elmah.Io.Client;
using Elmah.Io.Client.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace IdentidadeAcesso.CrossCutting.AspNetFilters
{
    public class GlobalActionLogger : IActionFilter
    {
        private readonly ILogger<GlobalActionLogger> _logger;
        private readonly IHostingEnvironment _hostingEnviroment;
        private readonly IOptionsMonitor<ElmahIoOptions> _options;
        public GlobalActionLogger(ILogger<GlobalActionLogger> logger,
                                             IHostingEnvironment hostingEnviroment,
                                             IOptionsMonitor<ElmahIoOptions> options)
        {
            _logger = logger;
            _hostingEnviroment = hostingEnviroment;
            _options = options;
        }

        public async void OnActionExecuted(ActionExecutedContext context)
        {
            if (_hostingEnviroment.IsProduction())
            {
                var message = new CreateMessage
                {
                    Version = "v1.0",
                    Application = "KnowLedge.IO",
                    Source = "GlobalActionLoggerFilter",
                    Hostname = context.HttpContext.Request.Host.Host,
                    Url = context.HttpContext.Request.GetDisplayUrl(),
                    DateTime = DateTime.Now,
                    Method = context.HttpContext.Request.Method,
                    StatusCode = context.HttpContext.Response.StatusCode,
                    Data = context.Exception?.ToDataList(),
                    Detail = JsonConvert.SerializeObject(new { DadoExtra = "Ação Executada" })
                };
                var usuario = context.HttpContext.User;
                if ( usuario != null ) {
                    try
                    {
                        message.User = usuario.Claims.FirstOrDefault(c => c.Type == "email").Value;
                    }
                    catch (Exception)
                    {

                    }
                }

                var client = ElmahioAPI.Create("daa07db41fff467f9a4cde8e96d8a5f5", _options.CurrentValue);
                await client.Messages.CreateAsync(new Guid("324d3dc7-d02e-44b1-92b2-c5f8ff17c741").ToString(), message);
            }
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            if (_hostingEnviroment.IsProduction())
            {
                var message = new CreateMessage
                {
                    Version = "v1.0",
                    Application = "KnowLedge.IO",
                    Source = "GlobalActionLoggerFilter",
                    Hostname = context.HttpContext.Request.Host.Host,
                    Url = context.HttpContext.Request.GetDisplayUrl(),
                    DateTime = DateTime.Now,
                    Method = context.HttpContext.Request.Method,
                    StatusCode = context.HttpContext.Response.StatusCode,
                    ServerVariables = context.HttpContext.Request?.Headers?.Keys.Select(k => new Item(k, context.HttpContext.Request.Headers[k])).ToList(),
                    Detail = JsonConvert.SerializeObject(new { DadoExtra = "Executando ação", Dados = context.ActionArguments.Values })
                };
                var usuario = context.HttpContext.User;
                if (usuario != null)
                {
                    try
                    {
                        message.User = usuario.Claims.FirstOrDefault(c => c.Type == "email").Value;
                    }
                    catch (Exception)
                    {

                    }
                }
                var client = ElmahioAPI.Create("daa07db41fff467f9a4cde8e96d8a5f5", _options.CurrentValue);
                await client.Messages.CreateAsync(new Guid("324d3dc7-d02e-44b1-92b2-c5f8ff17c741").ToString(), message);
            }
        }
    }
}
