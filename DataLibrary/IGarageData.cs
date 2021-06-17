using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IGarageData
    {
        Task<List<PfotoGModel>> GetCorrectPfoto(int id);
        Task<List<GarageModel>> GetGarage();
        Task<List<PfotoGModel>> GetPfoto();
        Task InsertGarage(GarageModel garage);
        Task InsertPfotoG(PfotoGModel pfotoGModel);
        Task<List<GarageModel>> GetId();
        Task<GarageModel> GetCorrectId(int id);
    }
}