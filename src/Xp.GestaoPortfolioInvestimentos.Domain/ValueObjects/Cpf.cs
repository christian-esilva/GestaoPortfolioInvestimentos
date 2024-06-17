using Xp.GestaoPortfolioInvestimentos.Domain.Validation;

namespace Xp.GestaoPortfolioInvestimentos.Domain.ValueObjects;

public sealed class Cpf
{
    public string Documento { get; private set; }

    public Cpf(string documento)
    {
        if (!EhCpfValido(documento))
            _ = new DomainValidation("Cpf inválido");

        Documento = documento;
    }

    public static bool EhCpfValido(string cpf)
    {
        if (string.IsNullOrEmpty(cpf)) return false;

        if (cpf.Length != 11)
        {
            return false;
        }

        bool todosIguais = true;
        for (int i = 1; i < cpf.Length; i++)
        {
            if (cpf[i] != cpf[0])
            {
                todosIguais = false;
                break;
            }
        }
        if (todosIguais)
        {
            return false;
        }

        int soma = 0;
        for (int i = 0; i < 9; i++)
        {
            soma += int.Parse(cpf[i].ToString()) * (10 - i);
        }
        int resto = soma % 11;
        int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

        if (digitoVerificador1 != int.Parse(cpf[9].ToString()))
        {
            return false;
        }

        soma = 0;
        for (int i = 0; i < 10; i++)
        {
            soma += int.Parse(cpf[i].ToString()) * (11 - i);
        }
        resto = soma % 11;
        int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

        if (digitoVerificador2 != int.Parse(cpf[10].ToString()))
        {
            return false;
        }

        return true;
    }
}
