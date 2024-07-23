using System.Text;

namespace CashRegister.FileProcessing.Models
{
    public class ChangeTotals
    {
        public int Pennies { get; set; } = 0;
        public int Nickels { get; set; } = 0;
        public int Dimes { get; set; } = 0;
        public int Quarters { get; set; } = 0;
        public int Dollars { get; set; } = 0;
        public string InsufficientFundsMessage { get; set; } = string.Empty;

        /// <summary>
        /// Prints the established totals based on the currency denomination counts
        /// </summary>
        /// <returns>Human readable string denoting change due</returns>
        public string PrintTotals()
        {
            if (!string.IsNullOrWhiteSpace(InsufficientFundsMessage))
                return InsufficientFundsMessage;

            var sb = new StringBuilder();

            if (Dollars > 0)
                sb.Append($"{Dollars} {(Dollars > 1 ? "Dollars" : "Dollar")}, ");

            if (Quarters > 0)
                sb.Append($"{Quarters} {(Quarters > 1 ? "Quarters" : "Quarter")}, ");

            if (Dimes > 0)
                sb.Append($"{Dimes} {(Dimes > 1 ? "Dimes" : "Dime")}, ");

            if (Nickels > 0)
                sb.Append($"{Nickels} {(Nickels > 1 ? "Nickels" : "Nickel")}, ");

            if (Pennies > 0)
                sb.Append($"{Pennies} {(Pennies > 1 ? "Pennies" : "Penny")}, ");

            return sb.ToString().Trim().TrimEnd(',');
        }
    }
}
