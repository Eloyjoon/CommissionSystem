using CommissionSystem.Data.Sepidar;
using CommissionSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommissionSystem.Services.Concretes
{
    public class FiscalYearService : IFiscalYearService
    {
        private readonly SepidarContext sepidarContext;

        public FiscalYearService(SepidarContext sepidarContext)
        {
            this.sepidarContext = sepidarContext;
        }
        public IEnumerable<FiscalYear> ListOfFiscalYears()
        {
            var fiscalYears = sepidarContext.FiscalYears.FromSqlRaw(@"SELECT [FiscalYearId]
                                                                  ,[Title]
                                                                    FROM [FMK].[FiscalYear]
                                                            order by [FiscalYearId] desc");

            return fiscalYears;
        }
    }
}
