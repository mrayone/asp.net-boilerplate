using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

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
                _logger.LogError(1, context.Exception, context.Exception.Message);
            }

            context.ExceptionHandled = true;
        }
    }
}
