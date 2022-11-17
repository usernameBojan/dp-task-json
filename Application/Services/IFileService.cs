using Application.Dto;

namespace Application.Services
{
    public interface IFileService
    {
        ProcessedDataDto ProccessedData(string originalFilePath);
    }
}