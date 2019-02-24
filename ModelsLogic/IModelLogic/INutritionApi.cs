using System.Threading.Tasks;

namespace ModelsLogic.IModelLogic
{
    public interface INutritionApi
    {
        Task WriteInformationAboutFoodInDb(string query, int userId);
    }
}