using System;
using DailyBonus.Roulette;
using Server.API;
using UnityEngine;
using Zenject;

namespace DailyBonus.Roulette
{
    public class SetBalanceCommand
    {
        [Inject] private GameplayApi _gameplayApi;
        [Inject] private IRouletteModel _rouletteModel;

        public void Execute(SetBalanceSignal signal)
        {
            _gameplayApi.SetPlayerBalance(_rouletteModel.Balance).Done(signal.Resolve, signal.Reject);
        }
    }
}