﻿using System;

namespace DependencyInjectionTutorial.CreditCardServices
{
    public class GoldCard : ICreditCard
    {
        public decimal Balance { get; private set; }
        public decimal Rewards { get; private set; }

        private const decimal RewardsRatePointsPerDollar = 0.1m;
        
        public GoldCard()
        {
            var rand = new Random();
            Balance = rand.Next(-100, 100);
        }

        public void Charge(decimal amount)
        {
            Balance -= amount;
            IncreaseRewardsRelativeToChargeAmount(amount);
        }

        public void Load(decimal amount)
        {
            Balance += amount;
        }

        private void IncreaseRewardsRelativeToChargeAmount(decimal chargeAmount)
        {
            Rewards += chargeAmount * RewardsRatePointsPerDollar;
        }
    }
}