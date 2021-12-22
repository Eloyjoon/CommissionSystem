using AutoMapper;
using CommissionSystem.Entities;
using CommissionSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Services.Concretes
{
    public class QuoteService :BaseService, IQuoteService
    {
        private readonly Data.CommisionContext commisionContext;

        public QuoteService(Data.CommisionContext commisionContext, IMapper mapper):base(mapper)
        {
            this.commisionContext = commisionContext;
        }
        public async Task<bool> AddItemToQuote(QuoteItem quoteItem, int userID, int count, decimal unitPrice)
        {
            var openQuote =await GetOpenQuote(userID);

            var dataOpenQuote = mapper.Map<Data.Quote>(openQuote);

            var dataQuoteItem= mapper.Map<Data.QuoteItem>(quoteItem);

            dataOpenQuote.QuoteItems.Add(dataQuoteItem);

            await commisionContext.SaveChangesAsync();

            return true;
        }

        public async Task<Quote> GetOpenQuote(int userId)
        {
            var openQuote = commisionContext.Quotes.FirstOrDefault(x => x.QuoteStatus.Name.ToLower() == "open" && x.CreatorID == userId);

            if (openQuote == null)
            {
                var number = commisionContext.Quotes.Max().Number + 1;
                Data.Quote quote = new Data.Quote()
                {
                    CreationDate = DateTime.Now,
                    CreatorID = userId,
                    AssigneeID = userId,
                    Number = number,
                    QuoteStatus = commisionContext.QuoteStatuses.First(a => a.Name.ToLower() == "open")
                };
                commisionContext.Quotes.Add(quote);
                await commisionContext.SaveChangesAsync();
                openQuote = commisionContext.Quotes.First(x => x.QuoteStatus.Name.ToLower() == "open");
            }

            return mapper.Map<Entities.Quote>(openQuote);
        }
    }
}
