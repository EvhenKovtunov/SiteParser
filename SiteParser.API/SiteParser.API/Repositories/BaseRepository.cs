using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteParser.API.Context;
using SiteParser.API.IRepositories;
using SiteParser.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteParser.API.Repositories
{
    public class BaseRepository : IBaseRepository, IDisposable
    {
        private  SIteParserContext _context;
        private bool disposed = false;

        public BaseRepository(SIteParserContext context)
        {
            this._context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<ResultModel>> GetResultsAsync()
        {
                return await _context.ResultModels.ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task CalculatedWords(BaseModel baseModel)
        {
            List<ResultModel> resultArrayModel = new List<ResultModel>();
            ResultModel resultModel = new ResultModel();


            char[] separatorSentence = { '.' };
            char[] separatorWord = { ' ' };
            string[] words;
            int count = 0;
            string[] sentences = baseModel.Text.Split(separatorSentence);
            foreach (var sentence in sentences)
            {
                words = sentence.Split(separatorWord);
                foreach (var word in words)
                {
                    if (word == baseModel.Word)
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    resultModel.Word = baseModel.Word;
                    resultModel.Sentence = Reverse(sentence);
                    resultModel.Count = count;
                    resultArrayModel.Add(resultModel);

                }
                count = 0;
            }
            _context.ResultModels.AddRange(resultArrayModel);
            await _context.SaveChangesAsync();
        }

        public async Task ParserResult(BaseModel item)
        {
            await CalculatedWords(item);
            await _context.SaveChangesAsync();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

}
