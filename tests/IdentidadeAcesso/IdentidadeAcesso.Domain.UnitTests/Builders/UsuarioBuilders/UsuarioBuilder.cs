using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public abstract class UsuarioBuilder
    {
        public static Usuario ObterUsuarioValido()
        {
            var nome = NomeBuilder.ObterNomeValido();
            var email = EmailBuilder.ObterEmailValido();
            var sexo = SexoBuilder.ObterSexoValido();
            var cpf = CPFBuilder.ObterCPFValido();
            var dataDeNascimento = DataDeNascimentoBuilder.ObterDataValida();
            return new Usuario(nome, sexo, email, cpf, dataDeNascimento);
        }

        public static Usuario ObterUsuarioCompletoValido()
        {
            var nome = NomeBuilder.ObterNomeValido();
            var email = EmailBuilder.ObterEmailValido();
            var sexo = SexoBuilder.ObterSexoValido();
            var cpf = CPFBuilder.ObterCPFValido();
            var dataDeNascimento = DataDeNascimentoBuilder.ObterDataValida();
            var numContato = CelularBuilder.ObterCelularValido();
            var endereco = EnderecoBuilder.ObterEnderecoValido();

            return UsuarioFactory.CriarUsuario(null, nome.PrimeiroNome, nome.Sobrenome, sexo.Tipo, email.Endereco, 
                cpf.Digitos, dataDeNascimento.Data,numContato.NumeroCel, numContato.NumeroTelefone,
                endereco, Guid.NewGuid());
        }
    }
}
