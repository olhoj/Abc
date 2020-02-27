using Abc.Data.Quantity;
using System;
using System.Collections.Generic;
using System.Text;
using Abc.Data.Common;

namespace Abc.Domain.Quantity
{
    public class Measure : Entity<MeasureData>
    {
        public Measure(MeasureData data) : base(data) { }
    }
}
