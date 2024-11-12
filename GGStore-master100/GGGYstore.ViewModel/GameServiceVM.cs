//using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Input;
using GGGYsore.Model.Application;
using System.Collections.ObjectModel;
namespace GGGYstore.ViewModel
{
    public partial class GameServiceVM
    {

        private readonly GameService gameService = new();
        public ObservableCollection<GameVMDto> gamesVM { get; set; } = [];
        //public AsyncRelayCommand<int> DeleteGameCommand { get; set; }
        public GameServiceVM()
        {
            setGamesVM();
            //DeleteGameAsyncCommand =new();
            //DeleteGameCommand = new (DeleteGame);
        }
        public async Task setGamesVM()
        {
            var gamesModel = await gameService.GetGamesAsync();
            foreach (var game in gamesModel)
            {
               var gameVM= FactoryGame.CreateGameVM(game);
                gamesVM.Add(gameVM);
            }
        }
        public RelayCommand DeleteGameAsyncCommand { get; set; }
        [RelayCommand]
        public async void DeleteGameAsync(int id)=>
        
           await gameService.DeleteGameByIdAsync(id);
        
    }
}
