using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class CardFlagService : ServiceBase, ICardFlagService
    {
        public CardFlagService(IRepositoryWrapper repository) : base(repository)
        {
        }

        public void CreateCardFlag(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteCardFlag(Guid cardId)
        {
            throw new NotImplementedException();
        }

        public CardFlagDTO GetCardFlag(Guid cardId)
        {
            throw new NotImplementedException();
        }

        public List<CardFlagDTO> GetCardFlags()
        {
            throw new NotImplementedException();
        }

        public void UpdateCardFlag(CardFlagDTO cardFlag)
        {
            throw new NotImplementedException();
        }
    }
}
