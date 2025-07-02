using TerraAcquire.Contracts.ModelHouses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.WebSockets;
using TerraAcquire.Contracts.User;
using TerraAquire.Contracts.LoginInfo;


namespace TerraAcquire.Pages.Account
{
    public class Login : PageModel
    {
        public readonly ILoginInfoService _loginInfoService;
        public readonly IUserService _userService;

        [BindProperty]
        public string? EmailAddress { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public Login(ILoginInfoService loginInfoService, IUserService userService)
        {
            _userService = userService;
            _loginInfoService = loginInfoService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var user = _userService.GetUserByEmail(this.EmailAddress);

            if (user != null)
            {
                var loginInfos = _loginInfoService.GetPerUser(user.Id);

                if (loginInfos != null)
                {
                    var accountStatusInfo = loginInfos.FirstOrDefault(a => a.Key != null && a.Key.ToLower() == "accountstatus");

                    if (accountStatusInfo != null && accountStatusInfo.Value != null && accountStatusInfo.Value.ToLower() == "active")
                    {
                        var passwordInfo = loginInfos.FirstOrDefault(a => a.Key != null && a.Key.ToLower() == "password");

                        if (passwordInfo != null)
                        {
                            var result = BCrypt.Net.BCrypt.Verify(this.Password, passwordInfo.Value);

                            if (result == true)
                            {
                                HttpContext.Session.SetString("UserName", user.FirstName + " " + user.LastName);
                                HttpContext.Session.SetString("EmailAddress", user.EmailAddress!);

                                return RedirectPermanent("~/index");
                            }
                            else
                            {
                                var loginAttemptInfo = loginInfos.FirstOrDefault(a => a.Key != null && a.Key.ToLower() == "loginattempt");

                                int? attempts = 1;
                                if (loginAttemptInfo != null)
                                {
                                    attempts = int.Parse(loginAttemptInfo.Value!) + 1;

                                    loginAttemptInfo.Value = attempts.ToString();

                                    if (attempts > 3)
                                    {
                                        accountStatusInfo.Value = "lockedout";
   
                                    }
                                }
                                else
                                {
                                    loginAttemptInfo = new LoginInfoDto()
                                    {
                                        UserId = user.Id,
                                        Key = "loginattempt",
                                        Value = attempts.ToString()
                                    };
                                }

                                await _loginInfoService.Update(loginAttemptInfo);
                                await _loginInfoService.Update(accountStatusInfo);

                            }
                        }
                    }
                    else
                    {



                    }
                }
            }

            return Page();
        }
    }
}
