using System.Text.RegularExpressions;
using Xp.GestaoPortfolioInvestimentos.Domain.Validation;

namespace Xp.GestaoPortfolioInvestimentos.Domain.ValueObjects;

public sealed class Email
{
    public string Endereco { get; private set; }

    public Email(string endereco)
    {
        if (!EhEmailValido(endereco))
            _ = new DomainValidation("E-mail inválido");
        Endereco = endereco;
    }

    public static bool EhEmailValido(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;

        string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(email);
    }
}
