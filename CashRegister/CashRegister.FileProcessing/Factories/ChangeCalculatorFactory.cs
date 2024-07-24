using CashRegister.FileProcessing.Calculators;
using CashRegister.FileProcessing.Calculators.Interfaces;
using CashRegister.FileProcessing.Factories.Interfaces;
using Microsoft.Extensions.Options;

namespace CashRegister.FileProcessing.Factories
{
    public class ChangeCalculatorFactory : IChangeCalculatorFactory
    {
        private IConfiguration _config;
        public ChangeCalculatorFactory(IConfiguration config)
        {
            _config = config;
        }
        public IChangeCalculator GetChangeCalculator()
        {
            var calcSettings = _config.GetSection("CalculatorSettings").Get<CalculatorSettings>();
            if (calcSettings == null)
            {
                return new NormalChangeCalculator();
            }

            switch(calcSettings.CalculatorType)
            {
                case (int)ImplementedCalculatorType.Normal:
                    return new NormalChangeCalculator();
                case (int)ImplementedCalculatorType.RandomizedByOwed:
                    return new RandomChangeCalculator(calcSettings.RandomDivisor);
                default:
                    return new NormalChangeCalculator();
            }
        }
    }
}
