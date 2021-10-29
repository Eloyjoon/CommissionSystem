using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Services.Interfaces
{
    public interface IFiscalYearService
    {
        IEnumerable<Models.DomainModels.DomainFiscalYear> ListOfFiscalYears();
    }
}
