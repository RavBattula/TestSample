// See https://aka.ms/new-console-template for more information
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

Console.WriteLine("Hello, World!");

HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
httpContextAccessor.HttpContext = new DefaultHttpContext();

var identity = new ClaimsIdentity();
identity.AddClaim(new Claim(ClaimTypes.Name, "Ravi"));
httpContextAccessor.HttpContext.User = new ClaimsPrincipal(identity);
//httpContextAccessor.HttpContext.Authentication = new AuthenticationManager();
httpContextAccessor.HttpContext.Authentication.SignInAsync("Cookies", httpContextAccessor.HttpContext.User);
httpContextAccessor.HttpContext?.Response.Cookies.Append("name1", "textvalue1");
httpContextAccessor.HttpContext?.Response.Cookies.Append("name2", "textvalue2");
string value1 = httpContextAccessor.HttpContext?.Request.Cookies["name1"];
string value2 = httpContextAccessor.HttpContext?.Request.Cookies["name2"];
//httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue("name1", out string value1);
//httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue("name1", out string value2);
Console.WriteLine(value1);
Console.WriteLine(value2);