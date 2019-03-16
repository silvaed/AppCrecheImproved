using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S00190492_Creche.Model;

namespace S00190492_Creche.Pages.Student
{
    public class ValueDetailsModel : PageModel
    {
        private readonly CrecheContext _db;

        public ValueDetailsModel(CrecheContext db)
        {
            _db = db;
        }

        public IList<S00190492_Creche.Model.Student> Students { get; private set; }

        public async Task OnGetAsync()
        {
            Students = await _db.Students.AsNoTracking().ToListAsync();
        }
       
    }
}