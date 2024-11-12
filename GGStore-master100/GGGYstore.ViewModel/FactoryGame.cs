using GGGYsore.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace GGGYstore.ViewModel
{
    public class FactoryGame
    {
        public static GameVMDto CreateGameVM(GameModel gameModel) => new GameVMDto { Id = gameModel.Id, Title = gameModel.Title, Description = gameModel.Description, Publisher = gameModel.Publisher, DateRelease = gameModel.DateRelease.ToString("D"), };

    }
}
