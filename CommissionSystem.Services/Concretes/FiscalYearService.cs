using AutoMapper;
using CommissionSystem.Data.Sepidar;
using CommissionSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommissionSystem.Services.Concretes
{
    public class FiscalYearService : BaseService, IFiscalYearService
    {
        private readonly SepidarContext sepidarContext;

        public FiscalYearService(SepidarContext sepidarContext, IMapper mapper) : base(mapper)
        {
            this.sepidarContext = sepidarContext;
        }
        public IEnumerable<Entities.FiscalYear> ListOfFiscalYears()
        {
            var fiscalYears = sepidarContext.FiscalYears.FromSqlRaw(@"SELECT [FiscalYearId]
                                                                  ,[Title]
                                                                    FROM [FMK].[FiscalYear]
                                                            order by [FiscalYearId] desc");

            return mapper.Map<List<Entities.FiscalYear>>(fiscalYears);
        }
    }
}
