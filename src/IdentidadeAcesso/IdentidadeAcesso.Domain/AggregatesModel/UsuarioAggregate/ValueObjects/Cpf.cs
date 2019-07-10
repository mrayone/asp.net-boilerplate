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
        }

        public static string LimparFormatacaoCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return "";
            if (cpf.Length < 11)
                cpf = "0" + cpf;

            var pattern = @"[.-]";

            var cpfLimpo = Regex.Replace(cpf, pattern, "");

            return cpfLimpo;
        }

        public static CPF ObterCPFComFormatacao(string cpfStr)
        {
            cpfStr = CPF.LimparFormatacaoCPF(cpfStr);
            if (string.IsNullOrEmpty(cpfStr)) return new CPF(cpfStr);

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