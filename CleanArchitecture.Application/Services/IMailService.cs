namespace CleanArchitecture.Application.Services;

public interface IMailService
{
    Task SendEmailAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default);
}
