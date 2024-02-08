using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MediTrackDAL
{
    public class RatingDAL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MediTrackDatabaseConnection"].ConnectionString;


        public static DataTable MedicineRatings(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("GetMedicineRatingInfo", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Add a parameter for the search term
                    adapter.SelectCommand.Parameters.AddWithValue("@medicine_id", Id);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in ProductDataAccess.SearchProducts: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }



        public static DataTable MedicineUpdatedRatingAndFeedback(int Id, int patientId, decimal rating, string feedback)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("GiveRatingAndUpdateAverage", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Add a parameter for the search term
                    adapter.SelectCommand.Parameters.AddWithValue("@rating_id", Id);
                    adapter.SelectCommand.Parameters.AddWithValue("@patient_id", patientId);
                    adapter.SelectCommand.Parameters.AddWithValue("@rating", rating);
                    adapter.SelectCommand.Parameters.AddWithValue("@feedback", feedback);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in ProductDataAccess.SearchProducts: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }



        public static DataTable SearchMedicine(string searchTerm)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("SearchInRatings", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Add a parameter for the search term
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", searchTerm);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in ProductDataAccess.SearchProducts: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }



        public static void GiveRatings(int medicine_id, int patient_id, decimal rating, string feedback, int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GiveRating", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@medicine_id", medicine_id);
                        command.Parameters.AddWithValue("@rating", rating);
                        command.Parameters.AddWithValue("@patient_id", patient_id);
                        command.Parameters.AddWithValue("@feedback", feedback);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }



        public static DataTable SearchMedicineRating(string search)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("SearchInRatings", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Add a parameter for the search term
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", search);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in ProductDataAccess.SearchProducts: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }





        public static void DeleteRating(int ratingId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter("DeleteRatings", connection))
                    {
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        adapter.SelectCommand.Parameters.AddWithValue("@rating_id", ratingId);

                        // Execute the stored procedure
                        adapter.SelectCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in DeleteRating: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }



        public static DataTable GetAllRatings()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetAllRatingProcedure", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in GetAllRatings: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }

            return dataTable;
        }





    }
}
