using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler
{
    public class CommandHandler
    {
        IMediator _meadiator;
        IUnitOfWork unitOfWork;

        public CommandHandler(IMediator meadiator, IUnitOfWork unitOfWork)
        {
            _meadiator = meadiator;
            this.unitOfWork = unitOfWork;
        }
    }
}
