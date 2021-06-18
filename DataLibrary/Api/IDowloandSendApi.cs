using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IDowloandSendApi
    {
        Task<GarageModel> DowloandCorrectGarageModel(int id);
        Task<List<GarageModel>> DowloandGarageModel();
        string UploadGarageModel(GarageModel garage);
        string DeleteGarageModel(int id);
        string PutGarageModel(int ID, GarageModel garage);
    }
}