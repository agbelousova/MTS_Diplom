using MTS_Diplom.Models;

namespace MTS_Diplom.Services;

public interface ISectionService
{
    Task<Section> GetSection(string sectionId);
}