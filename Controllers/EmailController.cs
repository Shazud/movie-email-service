using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieEmailService.Models;
using MovieEmailService.Services;
using NETCore.MailKit.Core;
using System;

namespace MovieEmailService.Controllers
{
    [Route("api/mail")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _usersService;

        public EmailController(IEmailService emailService, IUserService usersService)
        {
            _emailService = emailService;
            _usersService = usersService;
        }


        //POST api/mail/username
        [HttpPost("{username}")]
        public ActionResult EmailUser(string username, Email email)
        {
            Console.WriteLine(username + " " + email.subject + " " + email.body);
            email.email = _usersService.GetUserByUsername(username).Result.email;
            if(email.email == null)
            {
                return NotFound();
            }
            return EmailTarget(email);
        }


        [HttpPost("newsletter")]
        public ActionResult EmailNewsletter(Email email)
        {
            var users = _usersService.GetAllUsers().Result.Where(u => u.email != string.Empty);
            foreach(var user in users){
                _emailService.Send(
                    mailTo: user.email,
                    subject: email.subject,
                    message: email.body,
                    isHtml: false
                );
            }
            return Ok();
        }


        [HttpPost("broadcast")]
        public ActionResult EmailBroadcast(Email email)
        {
            var users = _usersService.GetAllUsers().Result.Where(u => u.email != string.Empty);
            foreach(var user in users){
                _emailService.Send(
                    mailTo: user.email,
                    subject: email.subject,
                    message: email.body,
                    isHtml: false
                );
            }
            return Ok();
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