using IdentidadeAcesso.API.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class BuscarTodos<TResponse> : IRequest<IEnumerable<TResponse>> 
        where TResponse : IQueryModel
    {
        public BuscarTodos()
        {

        }
    }
}