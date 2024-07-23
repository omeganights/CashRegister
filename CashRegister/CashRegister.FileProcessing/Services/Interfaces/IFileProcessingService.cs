namespace CashRegister.FileProcessing.Services.Interfaces
{
    public interface IFileProcessingService
    {
        /// <summary>
        /// Processes a flat file with currency pairs, format "amountOwed,paymentTendered"
        /// </summary>
        /// <param name="fileStream">File in stream format</param>
        /// <returns>Human readable string denoting change due for every line in the file</returns>
        string ProcessFile(Stream fileStream);
    }
}
