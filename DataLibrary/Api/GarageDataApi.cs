using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Api
{
    public class GarageDataApi
    {
        public SqlDataAccessApi _sqlData;
        public GarageDataApi(SqlDataAccessApi sqlData)
        {
            _sqlData = sqlData;
        }

        public Task<List<GarageModel>> GetGarageApi()   //Wszystkie elementy z bazy danych
        {
            string sql = "select *" +
                " from dbo.Garaze";
            return _sqlData.LoadDataList<GarageModel>(sql);
        }

        public Task<GarageModel> GetCorrectIdApi(int id)    //konkretny obiekt 
        {
            string sql = "select * " +
                        " from dbo.Garaze" +
                        " where Id=" + id;
            return _sqlData.LoadData<GarageModel>(sql);
        }

        public Task InsertGarage(GarageModel garage)    //dodanie nowego obiektu do bazy danych
                                                        // dopisać resztę parametrów //
        {
            string sql = @"insert into dbo.Garaze " +
                           " (Title,ReleaseDate,Price)" +
                            "values(@Title, @ReleaseDate, @Price);";
            return _sqlData.SaveData(sql, garage);
        }
        public Task<List<GarageModel>> GetGarageApiID()     //pobranie wszystkich ID
        {
            string sql = "SELECT Id " +
                "from dbo.Garaze";
            return _sqlData.LoadDataList<GarageModel>(sql);
        }

        public Task DeleteGarageApi(GarageModel garage)     //Usuwanie obiektów
        {
            string sql = @"DELETE FROM dbo.Garaze " +
                "WHERE Id = @Id";
            return _sqlData.SaveData(sql, garage);
        }

        public Task UpdateGarageApi(GarageModel garage)     //aktualizacja istniejacych obiektów
                                                            //dopisać resztę elementów
        {
            string sql = @"UPDATE dbo.Garaze " +
                "SET Title=@Title,ReleaseDate=@ReleaseDate " +
                "WHERE Id=@Id";

            return _sqlData.SaveData(sql, garage);
        }
    }
}