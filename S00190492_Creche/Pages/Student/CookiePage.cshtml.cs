using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace S00190492_Creche.Pages.Student
{
    public class CookiePageModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }

        
            
        public void OnGet()
        {
            
            if (Request.Cookies["MyCookie"] != null)
            {
                Message = $"There is a cookie which said {Request.Cookies["MyCookie"]}";
            }
            else
            {
                Message = "There is no cookie added";
            }

            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Append("MyCookie", "Cookie add from Cookie Code", cookieOptions);


        }

        
    }
}