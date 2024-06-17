using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xp.GestaoPortfolioInvestimentos.Application.Exceptions
{
    public class ClienteNaoEncontradoException : Exception
    {
        public ClienteNaoEncontradoException()
            : base($"Já existe um cliente cadastrado com esse Cpf.") { }
    }
}
