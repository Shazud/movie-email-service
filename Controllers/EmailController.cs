using Microsoft.AspNetCore.Mvc;
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
        public ActionResult EmailTarget()
        {
            return Ok(new { ok = "target" });
        }
}