﻿using DailyBonus.Roulette;
using Server.API;
using UnityEngine;
using Zenject;

namespace DailyBonus.Roulette
{
    public class GetMultiplierCommand
    {
        [Inject] private GameplayApi _gameplayApi;
        [Inject] private IRouletteModel _rouletteModel;
        
        public void Execute(GetMultiplierSignal signal)
        {
            _gameplayApi.GetMultiplier()
                .Done(multiplier =>
                    {
                        _rouletteModel.Multiplier = multiplier;

                        signal.Resolve();
                    },
                    signal.Reject);
        }
    }
}