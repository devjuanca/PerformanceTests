using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public static class EFBigQueryStoredProcedure
    {
        private static EFContext _ctx;

        public static async Task<IEnumerable<Data>> GetData()
        {
            _ctx = new EFContext();
            return await _ctx.Data.FromSqlRaw("GetData").ToListAsync();
        }
    }
}
