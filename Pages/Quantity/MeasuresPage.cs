using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Abc.Pages
{
    public abstract class MeasuresPage : PageModel
    {
        protected internal readonly iMeasuresRepository data;

        protected internal MeasuresPage(iMeasuresRepository r)
        {
            data = r;
        }

        [BindProperty]
        public MeasureView MeasureView { get; set; } //MeasureView=Item 
        public IList <MeasureView> Items { get; set; }
    }
}
