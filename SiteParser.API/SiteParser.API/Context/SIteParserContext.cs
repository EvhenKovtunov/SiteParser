using Microsoft.EntityFrameworkCore;
using SiteParser.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteParser.API.Context
{
    public class SIteParserContext : DbContext
    {
        public SIteParserContext(DbContextOptions<SIteParserContext> options)
           : base(options)
        { }

        public DbSet<ResultModel> ResultModels { get; set; }
        public DbSet<BaseModel> BaseModels { get; set; }
    }
}
