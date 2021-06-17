using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface ISqlDataAccess
    {

        string ConnectionStringName { get; set; }
        public Task<List<T>> LoadDataList<T, U>(string sql, U parameters);
        public Task<T> LoadDataOne<T, U>(string sql, U parameters);
        public Task SaveData<T>(string sql, T parameters);
    }
}