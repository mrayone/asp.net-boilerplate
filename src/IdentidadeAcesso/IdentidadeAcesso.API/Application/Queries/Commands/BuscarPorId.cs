using IdentidadeAcesso.API.Application.Models;
using MediatR;
using System;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class BuscarPorId<T> : IRequest<T> where T: IQueryModel
    {
        public BuscarPorId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}