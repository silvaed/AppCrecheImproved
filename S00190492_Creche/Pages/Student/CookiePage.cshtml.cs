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
        public string Message { get; set; }

        
                

        public void OnGet()
        {
            
            if (Request.Cookies["Teste"] != null)
            {
                Message = $"There is a cookie which said {Request.Cookies["Teste"]}";
            }
            else
            {
                Message = "There is no cookie added";
            }

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("Teste", "Cookie add from Cookie Code", options);


        }

        
    }
}