﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Services.Interfaces
{
    public interface IFiscalYearService
    {
        IEnumerable<Entities.FiscalYear> ListOfFiscalYears();
    }
}
