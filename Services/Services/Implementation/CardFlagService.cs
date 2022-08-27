﻿using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Exceptions.Shared;
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
            var flagExists = _repository.CardFlagRepository.FindByCondition(x => x.Name.ToLower() == name.ToLower());

            if(flagExists is not null)
            {
                throw new AlreadyExists("Card Flag", name);
            }

            var newCardFlag = new CardFlag()
            {
                Name = name
            };

            newCardFlag.Generate();

            _repository.CardFlagRepository.Create(newCardFlag);
            _repository.Save();
        }

        public void DeleteCardFlag(Guid cardFlagId)
        {
            var cardFlag = _repository.CardFlagRepository.FindByCondition(x => x.Id == cardFlagId).FirstOrDefault();

            if(cardFlag is null)
            {
                throw new NotFound("Card Flag");
            }

            _repository.CardFlagRepository.Delete(cardFlag);
            _repository.Save();
        }

        public CardFlagDTO GetCardFlag(Guid cardFlagId)
        {
            var cardFlag = _repository.CardFlagRepository.FindByCondition(x => x.Id == cardFlagId).FirstOrDefault();

            if (cardFlag is null)
            {
                throw new NotFound("Card Flag");
            }

            var cardFlagDTO = new CardFlagDTO
            {
                Id = cardFlag.Id,
                Name = cardFlag.Name
            };

            return cardFlagDTO;
        }

        public List<CardFlagDTO> GetCardFlags()
        {
            var cardFlags = _repository.CardFlagRepository.GetAll().Select(x => new CardFlagDTO
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

            return cardFlags;
        }

        public void UpdateCardFlag(CardFlagDTO cardFlag)
        {
            var cardFlagFound = _repository.CardFlagRepository.FindByCondition(x => x.Id == cardFlag.Id).FirstOrDefault();

            if (cardFlagFound is null)
            {
                throw new NotFound("Card Flag");
            }

            cardFlagFound.Name = cardFlag.Name;

            _repository.CardFlagRepository.Update(cardFlagFound);
            _repository.Save();
        }
    }
}
