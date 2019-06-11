using IdentidadeAcesso.API.Application.Validations.Perfil;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.Perfil
{
    public class CriarPerfilCommand : BasePerfilCommand<CriarPerfilCommand>, IRequest<bool>
    {
        public CriarPerfilCommand(Guid id, string nome, string descricao, bool status,
            IList<PermissaoAssinadaDTO> permissoesAssinadas)
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
            return ValidationResult.IsValid;
        }
    }
}
