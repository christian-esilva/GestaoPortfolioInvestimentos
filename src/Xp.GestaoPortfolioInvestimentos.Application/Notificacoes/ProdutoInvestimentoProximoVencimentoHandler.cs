using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Xp.GestaoPortfolioInvestimentos.Application.Notificacoes;

public class ProdutoInvestimentoProximoVencimentoHandler : 
    INotificationHandler<ProdutoInvestimentoVencimentoProximoNotification>
{
    private readonly ILogger<ProdutoInvestimentoProximoVencimentoHandler>? _logger;
    private readonly SmtpClient _smtpClient;
    private readonly IConfiguration _configuration;
    const string SUBJECT = "Produtos de Investimentos Próximos do vencimento";

    public ProdutoInvestimentoProximoVencimentoHandler(
        ILogger<ProdutoInvestimentoProximoVencimentoHandler>? logger, 
        SmtpClient smtpClient, 
        IConfiguration configuration)
    {
        _logger = logger;
        _smtpClient = smtpClient;
        _configuration = configuration;
    }

    public async Task Handle(ProdutoInvestimentoVencimentoProximoNotification notification, CancellationToken cancellationToken)
    {
        // TODO: Montar HTML com a lista dos produtos
        await EnviarEmailAsync(_configuration["EmailNotificacao"], SUBJECT, "html com investimentos");

        // Enviar confirmação
        _logger.LogInformation($"Email enviado com sucesso");     
    }

    private async Task EnviarEmailAsync(string to, string subject, string body)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_configuration["EmailNotificacao"]),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        mailMessage.To.Add(to);

        await _smtpClient.SendMailAsync(mailMessage);
    }
}
