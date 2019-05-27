using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class CPF : ValueObject<CPF>
    {
        private const int MaxDigitos = 11;
        public string Digitos { get; private set; }

        public CPF(string digitos)
        {
            Digitos = digitos;

            Validar();
        }

        private void Validar()
        {
            ValidarCPF();
        }

        #region Validação
        private void ValidarCPF()
        {
            if(Digitos == null)
            {
                ValidationResult.AdicionarErro("CPF Nulo", "O CPF não pode ser nulo.");
                return;
            }

            if (Digitos == String.Empty)
            {
                ValidationResult.AdicionarErro("CPF Vazio", "O CPF não pode ser vazio.");
                return;
            }

            if (!CPFValido())
            {
                ValidationResult.AdicionarErro("CPF Inválido", "O CPF informado é inválido.");
                return;
            }
        }

        private bool CPFValido()
        {
            var cpf = CPF.LimparFormatacaoCPF(Digitos);

            if (cpf.Length > MaxDigitos)
                return false;

            while (cpf.Length != MaxDigitos)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < MaxDigitos; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != MaxDigitos - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % MaxDigitos;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != MaxDigitos - resultado)
                return false;

            return true;
        }
        #endregion

        public static string LimparFormatacaoCPF(string cpf)
        {
            if (cpf == null) return null;
            if (cpf == String.Empty) return "";
            if (cpf.Length < 11)
                cpf = "0" + cpf;

            var pattern = @"[.-]";

            var cpfLimpo = Regex.Replace(cpf, pattern, "");

            return cpfLimpo;
        }

        public static CPF ObterCPFComFormatacao(string cpfStr)
        {
            cpfStr = CPF.LimparFormatacaoCPF(cpfStr);
            if (cpfStr == null) return new CPF(null);
            if (cpfStr == String.Empty) return new CPF("");

            var cpfFormatado = String.Format("{0}.{1}.{2}-{3}", cpfStr.Substring(0,3), 
                cpfStr.Substring(3, 3), cpfStr.Substring(6, 3), cpfStr.Substring(9, 2));

            return new CPF(cpfFormatado);
        }

        public static CPF ObterCPFSemFormatacao(string cpf)
        {
            if (cpf == null) return new CPF(null);
            if (cpf == String.Empty) return new CPF("");

            var cpfLimpo = CPF.LimparFormatacaoCPF(cpf);

            return new CPF(cpfLimpo);
        }

        //TODO: Implementar obter um cpf com a mascara.

        protected override bool EqualsCore(CPF other)
        {
            return Digitos.Equals(other.Digitos);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (Digitos.GetHashCode() * 907) ^ Digitos.GetHashCode();

                return hash;
            }
        }
    }
}