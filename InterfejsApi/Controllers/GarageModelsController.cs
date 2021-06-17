using DataLibrary;
using DataLibrary.Api;
using InterfejsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InterfejsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageModelsController : ControllerBase
    {
        private readonly GarageContext _context;
        private const string ConnectionStringName = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseGarage;Connect Timeout=30;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private GarageDataApi _GarageDataApi;
        SqlDataAccessApi sqlDataAccessApi;

        public GarageModelsController(GarageContext context)
        {
            _context = context;
        }

        // GET: api/GarageModels
        [HttpGet]
        public async Task<IEnumerable<GarageModel>> GetGaramodels()
        {
            //SqlConnection sqlConnection = new
            //    SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseGarage;Connect Timeout=30;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //IList<GarageModel> garage = (IList<GarageModel>)await sqlConnection.QueryAsync<GarageModel>("select * from dbo.Garaze");

            sqlDataAccessApi = new();                                       //obiekt z komendami od Dappera
            sqlDataAccessApi.ConnectionStringName = ConnectionStringName;   //przypisanie adresu bazy danych
            _GarageDataApi = new(sqlDataAccessApi);                         //obkiekt z komendami SQL 

            _context.GarageModels = await _GarageDataApi.GetGarageApi();

            return _context.GarageModels;
        }

        // GET: api/GarageModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GarageModel>> GetGarageModel(int id)
        {
            sqlDataAccessApi = new();
            sqlDataAccessApi.ConnectionStringName = ConnectionStringName;
            _GarageDataApi = new(sqlDataAccessApi);

            _context.GarageModels = await _GarageDataApi.GetGarageApiID();

            foreach (var item in _context.GarageModels)
            {
                if (item.Id == id)
                {
                    _context.GarageModel = await _GarageDataApi.GetCorrectIdApi(id);
                    return _context.GarageModel;
                }
            }
            return NotFound();
        }

        // PUT: api/GarageModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarageModel(int id, GarageModel garageModel)
        {

            sqlDataAccessApi = new();
            sqlDataAccessApi.ConnectionStringName = ConnectionStringName;
            _GarageDataApi = new(sqlDataAccessApi);

            IReadOnlyList<GarageModel> GarageModels = await _GarageDataApi.GetGarageApiID();

            foreach (var item in GarageModels)
            {
                if (item.Id == id)
                {
                    _context.GarageModel = await _GarageDataApi.GetCorrectIdApi(id);

                    #region przypisywanie wartości które zostały zmienione 
                    if (_context.GarageModel.Title != garageModel.Title) _context.GarageModel.Title = garageModel.Title;
                    _context.GarageModel.ReleaseDate = garageModel.ReleaseDate;
                    //Dopisać pozostałe parametry
                    #endregion

                    await _GarageDataApi.UpdateGarageApi(_context.GarageModel);
                    return NoContent();
                }
            }

            return NotFound();
        }

        // POST: api/GarageModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GarageModel>> PostGarageModel(GarageModel garage)
        {
            sqlDataAccessApi = new();
            sqlDataAccessApi.ConnectionStringName = ConnectionStringName;
            _GarageDataApi = new(sqlDataAccessApi);

            //_context.GarageModel = JsonConvert.DeserializeObject<GarageModel>(Json);

            await _GarageDataApi.InsertGarage(garage);
            return NoContent();
        }

        // DELETE: api/GarageModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarageModel(int id)
        {
            sqlDataAccessApi = new();
            sqlDataAccessApi.ConnectionStringName = ConnectionStringName;
            _GarageDataApi = new(sqlDataAccessApi);

            IReadOnlyList<GarageModel> garageModel = await _GarageDataApi.GetGarageApiID();

            foreach (var item in garageModel)
            {
                if (item.Id == id)
                {
                    await _GarageDataApi.DeleteGarageApi(item);
                    return NoContent();
                }
            }
            return NotFound();
        }
    }
}
