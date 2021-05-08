using Microsoft.AspNetCore.Mvc;
using MovieEmailService.Models;
using NETCore.MailKit.Core;

namespace MovieEmailService.Controllers
{
    [Route("api/mail")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }


        //POST api/mail/username
        [HttpPost("{username}")]
        public ActionResult EmailUser(string username)
        {
            return Ok(new { ok = username} );
        }


        [HttpPost("newsletter")]
        public ActionResult EmailNewsletter()
        {
            return Ok(new { ok = "newsletter" });
        }



        [HttpPost]
        public ActionResult EmailTarget(Email email)
        {
            if(email.email == string.Empty) return BadRequest();
            _emailService.Send(
                mailTo: email.email,
                subject: email.subject,
                message: email.body,
                isHtml: false
            );
            return Ok(new { ok = "target" });
        }
    }
}