namespace Impulse.Infra.CrossCutting.Validacoes
{
    public static class Validacao
    {
        public static bool ValidarDocumento(this string valor)
        {
            if (!string.IsNullOrEmpty(valor) && !DocumentoEhValido(valor))
                return false;

            return true;
        }
        
        private static bool DocumentoEhValido(this string document)
        {
            if (document.Length != 11 && document.Length != 14)
                return false;

            switch (document.Length)
            {
                case 11 when ValidarCpf(document):
                    return true;
                case 14 when ValidarCnpj(document):
                    return true;
                default:
                    return false;
            }
        }
        
        public static bool ValidarCpf(this string cpf)
        {
            var multiplicator1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicator2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            for (var j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            var tempCpf = cpf.Substring(0, 9);
            var sum = 0;

            for (var i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplicator1[i];

            var rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            var digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;

            for (var i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplicator2[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest;

            return cpf.EndsWith(digit);
        }

        public static bool ValidarCnpj(this string cnpj)
        {
            var multiplicator1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicator2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            var tempCnpj = cnpj.Substring(0, 12);
            var sum = 0;

            for (var i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplicator1[i];

            var rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            var digit = rest.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;

            for (var i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplicator2[i];

            rest = (sum % 11);

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest;

            return cnpj.EndsWith(digit);
        }
    }
}