using Backend_XRPL_Dev_ASP.NETCore_8_WebAPI.Models;
using System.Data.SqlClient;
using System.Data;

namespace Backend_XRPL_Dev_ASP.NETCore_8_WebAPI
{

    public class VehicleData
    {
        public int? Id { get; set; }
        public string? VIN { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public int? MileageTrip { get; set; }
        public int? MileageSum { get; set; }
    }

    public class VehicleDataAddDTO
    {
        public string? VIN { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public int? MileageTrip { get; set; }
        public int? MileageSum { get; set; }
    }
    public class VehicleDataRepository
    {
        private readonly string _connectionString;

        public VehicleDataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("XRPLAppCon");
        }

        //Create(Insert)
        public void AddVehicle(VehicleDataAddDTO vehicle)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("dbo.VehicleInsert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@VIN", vehicle.VIN);
                    command.Parameters.AddWithValue("@Make", vehicle.Make);
                    command.Parameters.AddWithValue("@Model", vehicle.Model);
                    command.Parameters.AddWithValue("@Year", vehicle.Year);
                    command.Parameters.AddWithValue("@MileageTrip", vehicle.MileageTrip);
                    command.Parameters.AddWithValue("@MileageSum", vehicle.MileageSum);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Read (Select)
        public IEnumerable<VehicleData> GetAllVehicles()
        {
            List<VehicleData> vehicles = new List<VehicleData>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM VehicleDataTable", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vehicles.Add(new VehicleData
                            {
                                Id = (int)reader["Id"],
                                VIN = reader["VIN"].ToString(),
                                Make = reader["Make"].ToString(),
                                Model = reader["Model"].ToString(),
                                Year = (int)reader["Year"],
                                MileageTrip = (int)reader["MileageTrip"],
                                MileageSum = (int)reader["MileageSum"]
                            });
                        }
                    }
                }
            }

            return vehicles;
        }

        // Read (Select) by Id
        public VehicleData GetVehicleById(int id)
        {
            VehicleData vehicle = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("dbo.VehicleGet", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the @Id parameter
                    SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.Int);
                    parameterId.Value = id;
                    command.Parameters.Add(parameterId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            vehicle = new VehicleData
                            {
                                Id = (int)reader["Id"],
                                VIN = reader["VIN"].ToString(),
                                Make = reader["Make"].ToString(),
                                Model = reader["Model"].ToString(),
                                Year = reader["Year"] as int?, // Handle nullable int
                                MileageTrip = reader["MileageTrip"] as int?, // Handle nullable int
                                MileageSum = reader["MileageSum"] as int? // Handle nullable int
                            };
                        }
                    }
                }
            }

            return vehicle;
        }


        // Update
        public void UpdateVehicle(int id, VehicleDataAddDTO updatedVehicle)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("dbo.VehicleUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@VIN", updatedVehicle.VIN);
                    command.Parameters.AddWithValue("@Make", updatedVehicle.Make);
                    command.Parameters.AddWithValue("@Model", updatedVehicle.Model);
                    command.Parameters.AddWithValue("@Year", updatedVehicle.Year);
                    command.Parameters.AddWithValue("@MileageTrip", updatedVehicle.MileageTrip);
                    command.Parameters.AddWithValue("@MileageSum", updatedVehicle.MileageSum);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete
        public void DeleteVehicle(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("dbo.VehicleDelete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
