using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace IdentidadeAcesso.CrossCutting.AspNetFilters
{
    public class GlobalExceptionHandlerFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandlerFilter> _logger;
        private readonly IHostingEnvironment _hostingEnviroment;

        public GlobalExceptionHandlerFilter(ILogger<GlobalExceptionHandlerFilter> logger,
            IHostingEnvironment hostingEnviroment)
        {
            _logger = logger;
            _hostingEnviroment = hostingEnviroment;
        }

        public void OnException(ExceptionContext context)
        {
            if(_hostingEnviroment.IsProduction())
            {
                if(context.Exception.GetType() != typeof(KeyNotFoundException))
                    _logger.LogError(1, context.Exception, context.Exception.Message);
            }

            if(context.Exception.GetType() == typeof(KeyNotFoundException))
            {
                context.Result = new NotFoundObjectResult(new { Error = context.Exception.Message });
            }
            else
            {
                context.Result = new BadRequestObjectResult(new { Error = "Ocorreu algum erro interno, contate a administração" });
            }

            context.ExceptionHandled = true;
        }
    }
}
