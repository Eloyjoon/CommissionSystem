using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Data.Sepidar;
using CommisionSystem.WebApplication.Models.DomainModels;
using CommisionSystem.WebApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommisionSystem.WebApplication.Services.Concretes
{
    public class FiscalYearService : IFiscalYearService
    {
        private readonly SepidarContext sepidarContext;

        public FiscalYearService(SepidarContext sepidarContext)
        {
            this.sepidarContext = sepidarContext;
        }
        public IEnumerable<DomainFiscalYear> ListOfFiscalYears()
        {
            var brands = sepidarContext.FiscalYears.FromSqlRaw(@"SELECT [FiscalYearId]
                                                                  ,[Title]
                                                                    FROM [FMK].[FiscalYear]
                                                            order by [FiscalYearId] desc");

            return brands.Select(a => a.ToDomainFiscalYear()).ToList();
        }
    }
}
