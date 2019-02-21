using Microsoft.AspNetCore.Mvc;
using SiteParser.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteParser.API.IRepositories
{
    public interface IBaseRepository : IDisposable
    {
        Task<IEnumerable<ResultModel>> GetResultsAsync();
        // Task<IEnumerable<ResultModel>> CalculatedWords(BaseModel baseModel);
        Task ParserResult(BaseModel item);
        void Save();
    }
}
