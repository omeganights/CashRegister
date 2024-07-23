using CashRegister.FileProcessing.Models;

namespace CashRegister.FileProcessing.Calculators.Interfaces
{
    public interface IChangeCalculator
    {
        /// <summary>
        /// Calculate the change totals based on the transaction info
        /// </summary>
        /// <param name="transactionInfo">Information about the transaction</param>
        /// <returns>Populated ChangeTotals object</returns>
        ChangeTotals CalculateChange(TransactionInfo transactionInfo);
    }
}
