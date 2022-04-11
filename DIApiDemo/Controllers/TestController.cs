using Luck.Module.Email;
using Luck.Module.Pay;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public readonly PayService payService;
        public readonly EmailSender emailSender;
        public TestController(PayService payService, EmailSender emailSender)
        {
            this.emailSender = emailSender;
            this.payService = payService;
        }
        [HttpGet]
        public ActionResult<bool> Index()
        {
            return emailSender.SendEmail();
        }
        [HttpGet]
        public ActionResult<bool> Index1()
        {
            return payService.IsPay();
        }
    }
    
}
