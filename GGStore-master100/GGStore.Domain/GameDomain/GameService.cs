﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using GGStore.Domain.GameDomain.Interfaces;
using System.Text;
using System.Text.Json;

namespace GGStore.Domain.GameDomain;

public class GameService(IMapper mapper, IGameRepository gameRepository, CreateGameValidation createGameValidation) : IGameService
{
    public async Task<int> AddAsync(GameDto gameDto)
    {
        var resultCreateGameValidation = createGameValidation.Validate(gameDto);

        var errors = new StringBuilder();

        if (!resultCreateGameValidation.IsValid)
        {
            foreach (var failure in resultCreateGameValidation.Errors)
            {
                errors.Append($"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
            }

            throw new ValidationException(errors.ToString());
        }

        return await gameRepository.AddAsync(gameDto);
    }

    public async Task DeleteAsync(int id) =>
        await gameRepository.DeleteAsync(id);

    public async Task EditAsync(int id, GameDto gameDto) =>
        await gameRepository.EditAsync(id, gameDto);

    public IEnumerable<GameVM> GetAll() =>
        gameRepository.GetAll().ProjectTo<GameVM>(mapper.ConfigurationProvider);

    public async Task<GameDetailsVM> GetByIdAsync(int id)
    {
        var game = await gameRepository.GetByIdAsync(id);
        var gameVM = mapper.Map<GameDetailsVM>(game);

        return gameVM;
    }
    /*
    async Task GetGamesAsync()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://localhost:7292/Game");
        string content = await response.Content.ReadAsStringAsync();
        var gamesModel = JsonSerializer.Deserialize<List<GameModel>>(content);

        if (gamesModel is not null)
        {
            foreach (var gameModel in gamesModel)
            {
                Console.WriteLine(gameModel);
            }
        }
    }
    */
}