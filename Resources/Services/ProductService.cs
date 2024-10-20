using Newtonsoft.Json;
using Resources.Enums;
using Resources.Models;

namespace Resources.Services;

public class ProductService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "file.json");
    private readonly FileService _fileService = new FileService(_filePath);
    private List<Product> _productList = new List<Product>();

    public ResultStatus AddToList(Product product)
    {
        try
        {
            if (_productList.Any(p => p.Title == product.Title))
            return ResultStatus.Exists;

            _productList.Add(product);

            var json = JsonConvert.SerializeObject(_productList, Formatting.Indented);
            var result = _fileService.SaveToFile(json);
            if (result)
                return ResultStatus.Success;

            return ResultStatus.SuccessWithErrors;
        }
        catch
        {
            return ResultStatus.Failed;
        }
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        try
        {
            var content = _fileService.GetFromFile();

            if (!string.IsNullOrEmpty(content))
            _productList = JsonConvert.DeserializeObject<List<Product>>(content)!;

            return _productList;
        }
        catch { }
        return _productList;

    }
}

