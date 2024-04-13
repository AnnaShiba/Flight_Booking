using Microsoft.AspNetCore.Identity.UI.Services;
using RestSharp.Authenticators;
using RestSharp;

namespace COMP2139_Assignment.Services {
    public class EmailSender : IEmailSender {
        private readonly string apiKey;
        private readonly string domain;

        public EmailSender(string apiKey, string domain) {
            this.apiKey = apiKey;
            this.domain = domain;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage) {
            RestClientOptions options = new RestClientOptions();
            options.Authenticator = new HttpBasicAuthenticator("api", apiKey);
            options.BaseUrl = new Uri("https://api.mailgun.net/v3");
            RestClient client = new RestClient(options);

            RestRequest request = new RestRequest();
            request.AddParameter("domain", domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Anna Shibanova <anna.shibanova@georgebrown.ca>");
            request.AddParameter("to", email);
            request.AddParameter("subject", subject);
            request.AddParameter("html", htmlMessage);
            request.Method = Method.Post;

            await client.ExecuteAsync(request);
        }
    }
}
