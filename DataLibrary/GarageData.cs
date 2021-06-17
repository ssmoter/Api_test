using System.Collections.Generic;
using System.Threading.Tasks;


namespace DataLibrary
{
    public class GarageData : IGarageData
    {
        private readonly ISqlDataAccess _dbGarage;
        public GarageData(ISqlDataAccess dbGarage)
        {
            _dbGarage = dbGarage;
        }

        public Task<List<GarageModel>> GetGarage()
        {
            string sql = "select *" +
                " from dbo.Garaze";

            return _dbGarage.LoadDataList<GarageModel, dynamic>(sql, new { });
        }

        public Task<List<PfotoGModel>> GetPfoto()
        {
            string sql = "select *" +
                " from dbo.PfotoG";
            return _dbGarage.LoadDataList<PfotoGModel, dynamic>(sql, new { });
        }
        public Task InsertGarage(GarageModel garage)
        {
            string sql = @"insert into dbo.Garaze " +
                           " (Title,ReleaseDate,Price)" +
                            "values(@Title, @ReleaseDate, @Price);";
            return _dbGarage.SaveData(sql, garage);
        }
        public Task InsertPfotoG(PfotoGModel pfotoGModel)
        {
            string sql = @"insert into dbo.PfotoG " +
                            "(GarazId,Pfoto_1,Pfoto_2,Pfoto_3,Pfoto_4,Pfoto_5,Pfoto_6)" +
                            " values (@GarazId,@Pfoto_1,@Pfoto_2,@Pfoto_3,@Pfoto_4,@Pfoto_5,@Pfoto_6);";
            return _dbGarage.SaveData(sql, pfotoGModel);
        }

        public Task<List<GarageModel>> GetId()
        {
            string sql = "SELECT Id " +
                "from dbo.Garaze";
            return _dbGarage.LoadDataList<GarageModel, dynamic>(sql, new { });
        }
        public Task<GarageModel> GetCorrectId(int id)
        {
            string sql = "select * " +
                        " from dbo.Garaze" +
                        " where Id=" + id;

            return _dbGarage.LoadDataOne<GarageModel, dynamic>(sql, new { });
        }
        public Task<List<PfotoGModel>> GetCorrectPfoto(int id)
        {
            string sql = "select * " +
                       " from dbo.PfotoG" +
                       " where GarazId=" + id;
            return _dbGarage.LoadDataList<PfotoGModel, dynamic>(sql, new { });
        }

    }
}
