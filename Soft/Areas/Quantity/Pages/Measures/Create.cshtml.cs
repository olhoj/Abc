
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abc.Facade.Quantity;
using Abc.Domain.Quantity;
using Abc.Pages;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class CreateModel : MeasuresPage
    {
        public CreateModel(iMeasuresRepository r) : base (r) {}

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MeasureView MeasureView { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            
            await data.Add(MeasureViewFactory.Create(MeasureView));

            return RedirectToPage("./Index");
        }
    }
}
