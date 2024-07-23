using CashRegister.FileProcessing.Models;

namespace CashRegister.FileProcessing.Calculators
{
    public class NormalChangeCalculator : BaseChangeCalculator
    {
        protected override ChangeTotals DoChangeCalculations(TransactionInfo transactionInfo)
        {
            // just do the normal calculations defined in the BaseChangeCalculator
            return DoNormalChangeCalculations(transactionInfo.ChangeOwed);
        }
    }
}
