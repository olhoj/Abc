﻿using Abc.Domain.Quantity;
using Abc.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Abc.Infra.Quantity
{
    public class MeasuresRepository : iMeasuresRepository
    {
        private readonly QuantityDbContext db;
        public MeasuresRepository(QuantityDbContext c)
        { db = c; }
        public async Task Add(Measure obj)
        {
            db.Measures.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var d = await db.Measures.FindAsync(id);

            if (id != null)
            {
                db.Measures.Remove(d);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Measure>> Get() 
        {
            var l = await db.Measures.ToListAsync();
            return (from e in l
                    select new Measure(e)).ToList();
        }

        public async Task<Measure> Get(string id)
        {
            var d = await db.Measures.FirstOrDefaultAsync(m => m.Id == id);
            return new Measure(d);
        }

        public async Task Update(Measure obj)
        {
            var d = db.Measures.FirstOrDefaultAsync(x => x.Id == obj.Data.Id);
            d.Code = obj.Data.Code;
            d.Name = obj.Data.Name;
            d.Definition = obj.Data.Definition;
            d.ValidFrom = obj.Data.ValidFrom;
            d.ValidTo = obj.Data.ValidTo;
            db.Measures.Update(d);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MeasureViewExists(MeasureView.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //  throw;
                //}
            }
        }
    }
}
