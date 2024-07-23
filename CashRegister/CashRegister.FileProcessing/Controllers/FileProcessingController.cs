using CashRegister.FileProcessing.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.FileProcessing.Controllers
{
    [Route("api/processfile")]
    [ApiController]
    public class FileProcessingController : ControllerBase
    {
        private readonly IFileProcessingService _fileProcessingService;
        public FileProcessingController(IFileProcessingService fileProcessingService) 
        { 
            _fileProcessingService = fileProcessingService;
        }

        [HttpPost]
        public string ProcessFile(Stream fileStream)
        {
            return _fileProcessingService.ProcessFile(fileStream);
        }
    }
}
