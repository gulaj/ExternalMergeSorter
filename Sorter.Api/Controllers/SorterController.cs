using Microsoft.AspNetCore.Mvc;
using Sorter.Core;
using System.Diagnostics;

namespace Sorter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SorterController : ControllerBase
    {
        private readonly IFileService _fileService;

        public SorterController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost(Name = "SortFile")]
        public async Task<double> SortFileAsync(string fileName = "text.txt")
        {

            var comparer = new DataRecordComparer();
            var command = new ExternalMergeSorter(new ExternalMergeSorterOptions
            {
                Sort = new ExternalMergeSortSortOptions
                {
                    Comparer = comparer
                }
            });
            var sourceFile = _fileService.GetSourceFile(fileName);
            var targetFile = _fileService.GetTargetStream(fileName);
            var stopwatch = Stopwatch.StartNew();
            await command.Sort(sourceFile, targetFile, CancellationToken.None);

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalSeconds;
        }
    }
}