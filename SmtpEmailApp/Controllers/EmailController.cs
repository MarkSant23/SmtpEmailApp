using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace SmtpEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailService _service;

        public EmailController(IEmailService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult SendMail(Email body)
        {
            _service.SentMail(body);
            return Ok();
        }
    }
}
