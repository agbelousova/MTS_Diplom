using MTS_Diplom.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NLog;

namespace MTS_Diplom.Tests.API;

public class GetTest : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Section _section = null;

    [Test]
    [Order(1)]
    [Category("Positive")]
    public void GetSectionTest()
    {
        // Загрузка JSON-схемы из файла
        string sectionJson = File.ReadAllText(@"Resources/Section.json");
        _logger.Info(sectionJson);
       
        // Создем экземпляр JSON-схемы
        var _section = JsonConvert.DeserializeObject<Section>(sectionJson);
        _logger.Info(_section.Id);
        _logger.Info(_section);
        
        _logger.Info(SectionService?.GetSection(_section.Id.ToString()).Result.ToString());
    }
}