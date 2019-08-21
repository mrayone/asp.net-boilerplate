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
            if (_hostingEnviroment.IsDevelopment())
            {
                var data = new
                {
                    Version = "v1.0",
                    User = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "email").Value,
                    IP = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Hostname = context.HttpContext.Request.Host.ToString(),
                    AreaAccessed = context.HttpContext.Request.GetDisplayUrl(),
                    Action = context.ActionDescriptor.DisplayName,
                    TimeStamp = DateTime.Now
                };

                _logger.LogInformation(1, data.ToString());
            }

            if (_hostingEnviroment.IsProduction())
            {
                var message = new CreateMessage
                {
                    Version = "v1.0",
                    Application = "KnowLedge.IO",
                    Source = "GlobalActionLoggerFilter",
                    User = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "email").Value,
                    Hostname = context.HttpContext.Request.Host.Host,
                    Url = context.HttpContext.Request.GetDisplayUrl(),
                    DateTime = DateTime.Now,
                    Method = context.HttpContext.Request.Method,
                    StatusCode = context.HttpContext.Response.StatusCode,
                    Data = context.Exception?.ToDataList(),
                    Detail = JsonConvert.SerializeObject(new { DadoExtra = "Ação Executada" })
                };


                var client = ElmahioAPI.Create("daa07db41fff467f9a4cde8e96d8a5f5", _options.CurrentValue);
                await client.Messages.CreateAsync(new Guid("324d3dc7-d02e-44b1-92b2-c5f8ff17c741").ToString(), message);
            }
        }


        private static List<Item> Form(ActionExecutingContext httpContext)
        {
            try
            {
                var list = new List<Item>();
                var argument = httpContext.ActionArguments.Values.FirstOrDefault();
                var type = argument.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
                foreach (var item in props)
                {
                    try
                    {
                        list.Add(new Item(item.Name, item.GetValue(argument, null).ToString()));
                    }
                    catch (Exception)
                    {

                    }
                }

                return list;
            }
            catch (InvalidOperationException)
            {
                // Request not a form POST or similar
            }

            return null;
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
                    User = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "email").Value,
                    Hostname = context.HttpContext.Request.Host.Host,
                    Url = context.HttpContext.Request.GetDisplayUrl(),
                    DateTime = DateTime.Now,
                    Method = context.HttpContext.Request.Method,
                    StatusCode = context.HttpContext.Response.StatusCode,
                    ServerVariables = context.HttpContext.Request?.Headers?.Keys.Select(k => new Item(k, context.HttpContext.Request.Headers[k])).ToList(),
                    QueryString = context.HttpContext.Request?.Query?.Keys.Select(k => new Item(k, context.HttpContext.Request.Query[k])).ToList(),
                    Form = Form(context),
                    Detail = JsonConvert.SerializeObject(new { DadoExtra = "Executando ação" })
                };


                var client = ElmahioAPI.Create("daa07db41fff467f9a4cde8e96d8a5f5", _options.CurrentValue);
                await client.Messages.CreateAsync(new Guid("324d3dc7-d02e-44b1-92b2-c5f8ff17c741").ToString(), message);
            }
        }
    }
}
