using CashRegister.FileProcessing.Models;
using Microsoft.Extensions.Options;

namespace CashRegister.FileProcessing.Calculators
{
    public class RandomChangeCalculator : BaseChangeCalculator
    {
        private Dictionary<int, decimal> MonetaryDenominations = new Dictionary<int, decimal>()
        {
            { 1, 0.01m },
            { 2, 0.05m },
            { 3, 0.1m },
            { 4, 0.25m },
            { 5, 1 }
        };
        private Random rnd = new Random();
        private int _randomDivisor;

        public RandomChangeCalculator(int randomDivisor) : base()
        {
            _randomDivisor = randomDivisor;
        }

        protected override ChangeTotals DoChangeCalculations(TransactionInfo transactionInfo)
        {
            var changeOwed = transactionInfo.ChangeOwed;

            // random divisor is configured in appsettings.json and is retrieved by the ChangeCalculatorFactory
            if (((transactionInfo.AmountOwed * 100) % _randomDivisor) != 0)
                return DoNormalChangeCalculations(changeOwed);

            var changeTotals = new ChangeTotals();
            while (changeOwed > 0)
            {
                var upperSeed = GetRandomUpperSeed(changeOwed);
                var randomChangeIndex = rnd.Next(1, upperSeed);
                var denomination = MonetaryDenominations[randomChangeIndex];

                switch (denomination)
                {
                    case 1:
                        changeTotals.Dollars++;
                        changeOwed -= 1;
                        break;
                    case 0.25m:
                        changeTotals.Quarters++;
                        changeOwed -= 0.25m;
                        break;
                    case 0.1m:
                        changeTotals.Dimes++;
                        changeOwed -= 0.1m;
                        break;
                    case 0.05m:
                        changeTotals.Nickels++;
                        changeOwed -= 0.05m;
                        break;
                    default:
                        changeTotals.Pennies++;
                        changeOwed -= 0.01m;
                        break;
                }
            }
            return changeTotals;
        }

        private int GetRandomUpperSeed(decimal changeOwed)
        {
            switch (changeOwed)
            {
                case > 1:
                    return 5;
                case > 0.25m:
                    return 4;
                case > 0.1m:
                    return 3;
                case > 0.05m:
                    return 2;
                default:
                    return 1;
            }
        }
    }
}
