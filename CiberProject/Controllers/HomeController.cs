using CiberProject.Models;
using CiberProject.Models.Entity;
using CiberProject.Models.ModelView;
using CiberProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PAKNAPI.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CiberProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IOrderService orderService)
        {
            _logger = logger;
            _config = config;
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid) {

                if (model.UserName == "HungTĐ" && model.Password == "Ciber") {
                    var token = generateJwtToken(model);

                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(Convert.ToInt32(_config["expire"])));

                    Response.Cookies.Append("accepToken", token, cookieOptions);
                    return Redirect("/");
                }

                TempData["Message"] = "Login failed.User name or password supplied doesn't exist!";
                return View();
                
            }
            return View();
        }



        [Authorize]
        public IActionResult Index()
        {
            try
            {
               
            }
            catch (Exception ex) {
                _logger.LogInformation("HomeController ~ Index ~ Ex: " + ex.Message);
            }

            return View();
        }

        public async Task<IActionResult> Order(string keySearch, int? orderBy = 0, int? pageSize = 2, int pageIndex = 1)
        {
            try
            {
                var response = await _orderService.getListOrder(keySearch, orderBy, pageSize, pageIndex);

                return View(response);
            }
            catch (Exception ex) {
                _logger.LogInformation("HomeController ~ Order ~ Ex: " + ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order model)
        {
            try
            {
                using (var context = new ApplicationDbContext()) {
                    await context.Order.AddAsync(model);
                    await context.SaveChangesAsync();
                    return Redirect("Order");
                }
            }
            catch (Exception ex)
            {

                _logger.LogInformation("HomeController ~ AddOrder ~ Ex: " + ex.Message);
                return View();
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private string generateJwtToken(Login user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _config["Jwt:Issuer"],
                Issuer = _config["Jwt:Issuer"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserName", user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;

        }
    }
}
