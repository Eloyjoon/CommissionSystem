using CommissionSystem.Entities;
using CommissionSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Services.Concretes
{
    public class QuoteService : IQuoteService
    {
        private readonly Data.CommisionContext commisionContext;

        public QuoteService(Data.CommisionContext commisionContext)
        {
            this.commisionContext = commisionContext;
        }
        public Task<bool> AddItemToQuote(QuoteItem quoteItem,int userID)
        {
            var openQuote = commisionContext.Quotes.FirstOrDefault(x => x.QuoteStatus.Name.ToLower() == "open");

            if (openQuote==null)
            {
                Data.Quote quote=new Data.Quote()
                {
                    CreationDate=DateTime.Now,
                    CreatorID=userID,
                    QuoteStatus=new 
                }
            }

        }
    }
}
