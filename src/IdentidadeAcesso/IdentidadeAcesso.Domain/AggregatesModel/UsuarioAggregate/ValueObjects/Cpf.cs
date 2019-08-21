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

        public static CPF ObterCPFLimpo(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) throw new ArgumentNullException("CPF Nulo.");
            if (cpf.Length < 11)
                cpf = "0" + cpf;

            var pattern = @"[.-]";

            var cpfLimpo = Regex.Replace(cpf, pattern, "");

            return new CPF(cpfLimpo);
        }

        public static bool ValidarCPFPatterns(string cpf)
        {
            if (Regex.IsMatch(cpf, @"\d{3}\.\d{3}\.\d{3}-\d{2}")) return true;
            else if (Regex.IsMatch(cpf, @"\d{10,11}")) return true;

            return false;
        }

        public static CPF ObterCPFComFormatacao(string cpfStr)
        {
            cpfStr = CPF.ObterCPFLimpo(cpfStr).Digitos;
            if (string.IsNullOrEmpty(cpfStr)) return new CPF(cpfStr);

            var cpfFormatado = String.Format("{0}.{1}.{2}-{3}", cpfStr.Substring(0,3), 
                cpfStr.Substring(3, 3), cpfStr.Substring(6, 3), cpfStr.Substring(9, 2));

            return new CPF(cpfFormatado);
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