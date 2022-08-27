using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICardFlagService
    {
        List<CardFlagDTO> GetCardFlags();
        CardFlagDTO GetCardFlag(Guid cardId);
        void CreateCardFlag(string name);
        void UpdateCardFlag(CardFlagDTO cardFlag);
        void DeleteCardFlag(Guid cardId);
    }
}
