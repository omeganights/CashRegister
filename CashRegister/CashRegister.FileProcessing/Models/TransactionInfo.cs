namespace CashRegister.FileProcessing.Models
{
    public class TransactionInfo
    {
        public decimal AmountOwed { get; set; }
        public decimal PaymentTendered { get; set; }

        public decimal ChangeOwed { get { return PaymentTendered - AmountOwed; } }

        public void ParseInput(string input)
        {
            var splitParts = input.Split(',');

            // in the case of ordinary decimal point, 2 numbers split by commas
            if (splitParts.Length == 2)
            {
                AmountOwed = decimal.Parse(splitParts[0]);
                PaymentTendered = decimal.Parse(splitParts[1]);
                return;
            }

            // in the case of currency that uses commas instead of decimal points for currency
            if (splitParts.Length == 4)
            {
                AmountOwed = decimal.Parse($"{splitParts[0]}.{splitParts[1]}");
                PaymentTendered = decimal.Parse($"{splitParts[2]}.{splitParts[3]}");
                return;
            }

            throw new Exception("Invalid file format");
        }
    }
}
