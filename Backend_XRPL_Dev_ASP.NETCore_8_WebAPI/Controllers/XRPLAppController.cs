//using Backend_XRPL_Dev_ASP.NETCore_8_WebAPI.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Data;
//using System.Data.SqlClient;
//using System.Reflection;

//namespace Backend_XRPL_Dev_ASP.NETCore_8_WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class XRPLAppController : ControllerBase
//    {
//        private IConfiguration _configuration;

//        public XRPLAppController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        [HttpGet]
//        [Route("GetAllVehicles")]
//        public JsonResult GetAllVehicles()
//        {
//            string query = "select * from VehicleDataTable";
//            DataTable table = new DataTable();
//            string sqlDataSource = _configuration.GetConnectionString("XRPLAppCon");
//            SqlDataReader myReader;
//            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myReader = myCommand.ExecuteReader();
//                    table.Load(myReader);
//                    myReader.Close();
//                    myCon.Close();
//                }
//            }
//            return new JsonResult(table);
//        }
//        [HttpGet]
//        [Route("GetVehiclesById")]
//        public JsonResult GetVehiclesById(int Id)
//        {
//            string query = "select * from VehicleDataTable where Id = @Id";
//            DataTable table = new DataTable();
//            string sqlDataSource = _configuration.GetConnectionString("XRPLAppCon");
//            SqlDataReader myReader;
//            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myCommand.Parameters.AddWithValue("@Id", Id);
//                    myReader = myCommand.ExecuteReader();
//                    table.Load(myReader);
//                    myReader.Close();
//                    myCon.Close();
//                }
//            }
//            return new JsonResult(table);
//        }

//        [HttpPost]
//        [Route("AddVehicles")]
//        public JsonResult AddVehicles([FromForm] VehicleData vehicleData)
//        {
//            string query = "EXEC dbo.VehicleInsert(@VIN, @Make, @Model, @Year, @MileageTrip, @MileageSum)";
//            DataTable table = new DataTable();
//            string sqlDataSource = _configuration.GetConnectionString("XRPLAppCon");
//            SqlDataReader myReader;

//            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myCommand.Parameters.AddWithValue("@VIN", vehicleData.VIN);
//                    myCommand.Parameters.AddWithValue("@Make", vehicleData.Make);
//                    myCommand.Parameters.AddWithValue("@Model", vehicleData.Model);
//                    myCommand.Parameters.AddWithValue("@Year", vehicleData.Year);
//                    myCommand.Parameters.AddWithValue("@MileageTrip", vehicleData.MileageTrip);
//                    myCommand.Parameters.AddWithValue("@MileageSum", vehicleData.MileageSum);

//                    myReader = myCommand.ExecuteReader();
//                    table.Load(myReader);
//                    myReader.Close();
//                }
//                myCon.Close();
//            }

//            return new JsonResult(table);
//        }

//        [HttpDelete]
//        [Route("RemoveVehicles")]
//        public JsonResult RemoveVehicles(int Id)
//        {
//            string query = "EXEC dbo.VehicleDelete(@Id)";
//            DataTable table = new DataTable();
//            string sqlDataSource = _configuration.GetConnectionString("XRPLAppCon");
//            SqlDataReader myReader;

//            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myCommand.Parameters.AddWithValue("@Id", Id);

//                    myReader = myCommand.ExecuteReader();
//                    table.Load(myReader);
//                    //myReader.Close();
//                }
//                myCon.Close();
//            }

//            return new JsonResult(table);
//        }

//        [HttpPut]
//        [Route("UpdateVehicles")]
//        public JsonResult UpdateVehicles([FromForm] VehicleData vehicleData)
//        {
//            string query = "EXEC dbo.VehicleUpdate(@Id, @VIN, @Make, @Model, @Year, @MileageTrip, @MileageSum)";
//            DataTable table = new DataTable();
//            string sqlDataSource = _configuration.GetConnectionString("XRPLAppCon");
//            SqlDataReader myReader;

//            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myCommand.Parameters.AddWithValue("@Id", vehicleData.Id);
//                    myCommand.Parameters.AddWithValue("@VIN", vehicleData.VIN);
//                    myCommand.Parameters.AddWithValue("@Make", vehicleData.Make);
//                    myCommand.Parameters.AddWithValue("@Model", vehicleData.Model);
//                    myCommand.Parameters.AddWithValue("@Year", vehicleData.Year);
//                    myCommand.Parameters.AddWithValue("@MileageTrip", vehicleData.MileageTrip);
//                    myCommand.Parameters.AddWithValue("@MileageSum", vehicleData.MileageSum);

//                    myReader = myCommand.ExecuteReader();
//                    table.Load(myReader);
//                    myReader.Close();
//                }
//                myCon.Close();
//            }

//            return new JsonResult(table);
//        }

//    }
//}