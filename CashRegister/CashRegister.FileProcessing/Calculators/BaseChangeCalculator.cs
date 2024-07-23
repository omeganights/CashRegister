using CashRegister.FileProcessing.Calculators.Interfaces;
using CashRegister.FileProcessing.Models;

namespace CashRegister.FileProcessing.Calculators
{
    public abstract class BaseChangeCalculator : IChangeCalculator
    {
        public BaseChangeCalculator() { }

        public ChangeTotals CalculateChange(TransactionInfo transactionInfo)
        {
            var changeOwed = transactionInfo.PaymentTendered - transactionInfo.AmountOwed;
            if (changeOwed < 0)
            {
                var changeTotals = new ChangeTotals();
                changeTotals.InsufficientFundsMessage = $"Transaction is incomplete; user owes {Math.Abs(changeOwed)}";
                return changeTotals;
            }

            return DoChangeCalculations(transactionInfo);
        }

        /// <summary>
        /// Abstract to allow for unique implementations from inherited classes
        /// </summary>
        /// <param name="transactionInfo">Information about the transaction</param>
        /// <returns>Populated ChangeTotals object</returns>
        protected abstract ChangeTotals DoChangeCalculations(TransactionInfo transactionInfo);

        /// <summary>
        /// Perform normal highest-denomination-first change calculations
        /// </summary>
        /// <param name="changeOwed">Amount owed in change</param>
        /// <returns>Populated ChangeTotals object</returns>
        protected ChangeTotals DoNormalChangeCalculations(decimal changeOwed)
        {
            var changeTotals = new ChangeTotals();
            while (changeOwed > 0)
            {
                switch (changeOwed)
                {
                    case > 1:
                        changeTotals.Dollars++;
                        changeOwed -= 1;
                        break;
                    case > 0.25m:
                        changeTotals.Quarters++;
                        changeOwed -= 0.25m;
                        break;
                    case > 0.1m:
                        changeTotals.Dimes++;
                        changeOwed -= 0.1m;
                        break;
                    case > 0.05m:
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
    }
}
