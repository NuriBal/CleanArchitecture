using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Services;

public sealed class MailService : IMailService
{
    private readonly EMailOptions _emailOptions;

    public MailService(IOptions<EMailOptions> emailOptions)
    {
        _emailOptions = emailOptions.Value;
    }

    public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)
    {
        using var mail = new MailMessage();
        mail.From = new MailAddress(_emailOptions.SenderEmail, _emailOptions.SenderName);
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = isHtml;

        using var smtp = new SmtpClient(_emailOptions.SmtpServer, _emailOptions.Port);
        smtp.Credentials = new NetworkCredential(_emailOptions.Username, _emailOptions.Password);
        smtp.EnableSsl = _emailOptions.EnableSsl;

        await smtp.SendMailAsync(mail, cancellationToken);
    }
}
