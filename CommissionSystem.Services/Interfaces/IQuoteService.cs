using CommissionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Services.Interfaces
{
    public interface IQuoteService
    {
        Task<bool> AddItemToQuote(QuoteItem quoteItem, int userID, int count, decimal unitPrice);

        Task<Quote> GetOpenQuote(int userId);
    }
}
