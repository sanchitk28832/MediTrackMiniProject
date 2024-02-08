using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediTrackDAL
{
    public class AdminDAL
    {

        static readonly string connectionString = ConfigurationManager.ConnectionStrings["MediTrackDatabaseConnection"].ConnectionString;




        public static DataTable GetMedicines()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("GetMedicinesProcedure", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in AdminFunctionality.GetMedicines: {ex.Message}");
                    throw;
                }
            }
        }



        public static DataTable GetMedicineCategory()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("GetMedicineCategoryProcedure", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in AdminFunctionality.GetMedicineCategory: {ex.Message}");
                    throw;
                }
            }
        }




        public static DataTable GetPatientsDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("GetPatientsDetailsProcedure", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in EcommerceBAl.GetProducts: {ex.Message}");
                    throw;
                }
            }
        }






        public static bool UpdateMedicine(int medicineId, string medicineName = null, string brandName = null, string origin = null, string generation = null, decimal? cost = null, int? categoryId = null, int? medquntity = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.UpdateCommand = new SqlCommand("UpdateMedicine", connection);
                    adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;


                    adapter.UpdateCommand.Parameters.AddWithValue("@MedicineId", medicineId);
                    adapter.UpdateCommand.Parameters.AddWithValue("@MedicineName", (object)medicineName ?? DBNull.Value);
                    adapter.UpdateCommand.Parameters.AddWithValue("@BrandName", (object)brandName ?? DBNull.Value);
                    adapter.UpdateCommand.Parameters.AddWithValue("@Origin", (object)origin ?? DBNull.Value);
                    adapter.UpdateCommand.Parameters.AddWithValue("@Generation", (object)generation ?? DBNull.Value);
                    adapter.UpdateCommand.Parameters.AddWithValue("@Cost", (object)cost ?? DBNull.Value);
                    adapter.UpdateCommand.Parameters.AddWithValue("@CategoryId", (object)categoryId ?? DBNull.Value);
                    adapter.UpdateCommand.Parameters.AddWithValue("@MedicineQuantity", (object)medquntity ?? DBNull.Value);

                    int result = adapter.UpdateCommand.ExecuteNonQuery();

                    return result > 0;
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Error in AdminFunctionality UpdateMedicine: {ex.Message}");
                    return false;
                }
            }
        }






        public static bool AddNewMedicine(string medicineName, string brandName, string origin, string generation, decimal cost, int quantity, int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = new SqlCommand("AddNewMedicine", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                    adapter.InsertCommand.Parameters.AddWithValue("@MedicineName", medicineName);
                    adapter.InsertCommand.Parameters.AddWithValue("@BrandName", brandName);
                    adapter.InsertCommand.Parameters.AddWithValue("@Origin", origin);
                    adapter.InsertCommand.Parameters.AddWithValue("@Generation", generation);
                    adapter.InsertCommand.Parameters.AddWithValue("@Cost", cost);
                    adapter.InsertCommand.Parameters.AddWithValue("@MedicineQuantity", quantity);
                    adapter.InsertCommand.Parameters.AddWithValue("@CategoryId", categoryId);


                    connection.InfoMessage += (sender, e) =>
                    {
                        // Handle InfoMessage events if needed
                        Console.WriteLine($"InfoMessage: {e.Message}");
                    };

                    int result = adapter.InsertCommand.ExecuteNonQuery();

                    return result > 0;
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine($"Error in AdminFunctionality.AddNewMedicine: {ex.Message}");
                    return false;
                }
            }
        }





        public static bool DeleteMedicine(int medicineId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand("DeleteMedicineProcedure", connection);
                    adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

                    adapter.DeleteCommand.Parameters.AddWithValue("@MedicineId", medicineId);

                    int result = adapter.DeleteCommand.ExecuteNonQuery();

                    return result > 0;
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Error in deleting the medicine {ex.Message}");
                    return false;
                }
            }
        }




        public static bool DeletePatient(int patientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand("DeletePatientProcedure", connection);
                    adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

                    adapter.DeleteCommand.Parameters.AddWithValue("@PatientId", patientId);

                    int result = adapter.DeleteCommand.ExecuteNonQuery();

                    return result > 0;
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine($"Error in deleting patient {ex.Message}");
                    return false;
                }
            }
        }




    }
}
