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
        public static Usuario ObterUsuarioInvalido()
        {
            var nome = NomeBuilder.ObterNomeInvalido();
            var email = EmailBuilder.ObterEmailInvalido();
            var sexo = SexoBuilder.ObterSexoInvalido();
            var cpf = CPFBuilder.ObterCPFInvalido();
            var dataDeNascimento = DataDeNascimentoBuilder.ObterDataInvalida();
            return new Usuario(nome, sexo, email, cpf, dataDeNascimento, Guid.NewGuid());
        }

        public static Usuario ObterUsuarioParcialmenteInvalido()
        {
            var nome = NomeBuilder.ObterNomeValido();
            var email = EmailBuilder.ObterEmailValido();
            var sexo = SexoBuilder.ObterSexoInvalido();
            var cpf = CPFBuilder.ObterCPFInvalido();
            var dataDeNascimento = DataDeNascimentoBuilder.ObterDataInvalida();
            return new Usuario(nome, sexo, email, cpf, dataDeNascimento, Guid.NewGuid());
        }

        public static Usuario ObterUsuarioValido()
        {
            var nome = NomeBuilder.ObterNomeValido();
            var email = EmailBuilder.ObterEmailValido();
            var sexo = SexoBuilder.ObterSexoValido();
            var cpf = CPFBuilder.ObterCPFValido();
            var dataDeNascimento = DataDeNascimentoBuilder.ObterDataValida();
            return new Usuario(nome, sexo, email, cpf, dataDeNascimento, Guid.NewGuid());
        }

        public static Usuario ObterUsuarioCompletoValido()
        {
            var nome = NomeBuilder.ObterNomeValido();
            var email = EmailBuilder.ObterEmailValido();
            var sexo = SexoBuilder.ObterSexoValido();
            var cpf = CPFBuilder.ObterCPFValido();
            var dataDeNascimento = DataDeNascimentoBuilder.ObterDataValida();
            var celular = CelularBuilder.ObterCelularValido();
            var telefone = TelefoneBuilder.ObterTelefoneValido();
            var endereco = EnderecoBuilder.ObterEnderecoValido();

            return UsuarioFactory.CriarUsuario(null, nome, sexo, email, cpf, dataDeNascimento, Guid.NewGuid(),celular,
                telefone, endereco);
        }
    }
}
