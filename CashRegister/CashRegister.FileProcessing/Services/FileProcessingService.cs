using CashRegister.FileProcessing.Factories.Interfaces;
using CashRegister.FileProcessing.Models;
using CashRegister.FileProcessing.Services.Interfaces;

namespace CashRegister.FileProcessing.Services
{
    public class FileProcessingService : IFileProcessingService
    {
        private IChangeCalculatorFactory _changeCalculatorFactory;
        public FileProcessingService(IChangeCalculatorFactory changeCalculatorFactory)
        {
            _changeCalculatorFactory = changeCalculatorFactory;
        }

        public string ProcessFile(Stream fileStream)
        {
            var returnVal = string.Empty;
            var txInfos = new List<TransactionInfo>();
            var sr = new StreamReader(fileStream);
            while (!sr.EndOfStream)
            {
                var txInfo = new TransactionInfo();
                var txFromFile = sr.ReadLine();
                if (txFromFile != null)
                {
                    txInfo.ParseInput(txFromFile);
                    txInfos.Add(txInfo);
                }
            }

            var calc = _changeCalculatorFactory.GetChangeCalculator();
            foreach (var txInfo in txInfos)
            {
                var changeTotals = calc.CalculateChange(txInfo);
                returnVal += $"{changeTotals.PrintTotals()}{Environment.NewLine}";
            }

            return returnVal;
        }
    }
}
