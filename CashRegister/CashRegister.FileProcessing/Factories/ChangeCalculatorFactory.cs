using CashRegister.FileProcessing.Calculators;
using CashRegister.FileProcessing.Calculators.Interfaces;
using CashRegister.FileProcessing.Factories.Interfaces;
using CashRegister.FileProcessing.Models;
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
            var randomizerSettings = _config.GetSection("RandomizerSettings").Get<RandomizerSettings>();
            if (randomizerSettings == null || !randomizerSettings.UseChangeRandomizer)
            {
                return new NormalChangeCalculator();
            }
            else
            {
                return new RandomChangeCalculator(randomizerSettings.RandomDivisor);
            }
        }
    }
}
