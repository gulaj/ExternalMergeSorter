using Microsoft.AspNetCore.Mvc;
using Sorter.Core;
using System.Diagnostics;

namespace Generator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenratorController : ControllerBase

    {
        private readonly IDictionaryService _dictionaryService;
        private readonly IFileService _fileService;

        public GenratorController(IDictionaryService dictionaryService, IFileService fileService)
        {
            _dictionaryService = dictionaryService;
            _fileService = fileService;
        }



        [HttpPost(Name = "GenerateDocument")]
        public async Task<double> GenerateDocumentAsync(double fileSieze, string fileName = "text.txt")
        {
            var stopwatch = Stopwatch.StartNew();
            
            var words = await _dictionaryService.GetAllWords();

            _fileService.GenerateFile(fileSieze, fileName, words);

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalSeconds;
        }
    }
}