 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abc.Facade.Quantity;
using Soft.Data;
using Abc.Pages;
using Abc.Domain.Quantity;

namespace Soft.Areas.Quantity.Pages.Measures
{
        public class DeleteModel : MeasuresPage
        {
            public DeleteModel(iMeasuresRepository r) : base(r) { }
        
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeasureView = MeasureViewFactory.Create(await data.Get(id));

            if (MeasureView == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await data.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
