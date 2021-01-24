﻿using System;
using DailyBonus.Roulette;
using Server.API;
using UnityEngine;
using Zenject;

namespace DailyBonus.Roulette
{
    public class UpdateBalanceCommand
    {
        [Inject] private GameplayApi _gameplayApi;
        [Inject] private IRouletteModel _rouletteModel;

        public void Execute(UpdateBalanceSignal signal)
        {
            if (_rouletteModel.UpdateBalanceWithMultiplier())
            {
                signal.Resolve();
            }
            else
            {
                signal.Reject(new Exception("Unable to update balance."));
            }
        }
    }
}