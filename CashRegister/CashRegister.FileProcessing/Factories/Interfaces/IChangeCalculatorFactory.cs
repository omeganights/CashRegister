using CashRegister.FileProcessing.Calculators.Interfaces;

namespace CashRegister.FileProcessing.Factories.Interfaces
{
    public interface IChangeCalculatorFactory
    {
        /// <summary>
        /// Retrieves the appropriate change calculator based on the the RandomizerSettings section in appsettings.json
        /// </summary>
        /// <returns>Implementation of IChangeCalculator</returns>
        IChangeCalculator GetChangeCalculator();
    }
}
