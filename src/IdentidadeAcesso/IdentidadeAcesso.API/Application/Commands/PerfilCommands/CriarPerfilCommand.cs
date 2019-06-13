using IdentidadeAcesso.API.Application.Validations.Perfil;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentidadeAcesso.Domain.SeedOfWork.Extensions;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class CriarPerfilCommand : BasePerfilCommand<CriarPerfilCommand>, IRequest<bool>
    {
        public CriarPerfilCommand(Guid id, string nome, string descricao, bool status,
            IList<AssinarPermissaoPerfilCommand> permissoesAssinadas)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Status = status;
            PermissoesAssinadas = permissoesAssinadas;
        }

        public override bool isValid()
        {
            ValidationResult = new CriarPerfilCommandValidation().Validate(this);
            foreach (var item in PermissoesAssinadas)
            {
                if(!item.isValid())
                {
                    ValidationResult.Errors.AddRangeIfNotEmpty(item.ValidationResult.Errors);
                } 
            }
            return ValidationResult.IsValid;
        }
    }
}
