using Application.Dto;
using Domain.Models;
using Newtonsoft.Json;

namespace Application.Services.Implementation
{
    public class FileService : IFileService
    {
        public ProcessedDataDto ProccessedData(string originalFilePath)
        {
            string preview = string.Empty;
            string originalFile = string.Empty;
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "ProcessedFiles"));
            string fileNamePattern = $@"\processeddata{DateTime.Now.Ticks}.json";
            bool directoryExists = Directory.Exists(path);
            bool fileExists = File.Exists(path + fileNamePattern);
            bool originalFileExists = File.Exists(originalFilePath);

            if (originalFileExists)
            {
                originalFile = File.ReadAllText(originalFilePath);
            } 
            else
            {
                throw new Exception("File not found");
            }

            List<Root> RootStructure = JsonConvert.DeserializeObject<List<Root>>(originalFile) 
                ?? throw new Exception("Provided file doesn't match the required structure");

            List<Claims> Claims = new();

            foreach(var claim in RootStructure.SelectMany(x => x.Claims))
            {
                if (claim.Value != "true" && claim.Value != "false")
                {
                    Claims.Add(new(claim.ClaimType, claim.Value));
                }
            }

            preview = "{\"Claims\": " + JsonConvert.SerializeObject(Claims, Formatting.Indented) + "}";

            if (!directoryExists)
            {
                Directory.CreateDirectory(path);
            }

            if (!fileExists)
            {
                File.WriteAllText(path + fileNamePattern, preview);
            }

            return new()
            {
                Preview = preview,
                Download = path + fileNamePattern
            };
        }
    }
}