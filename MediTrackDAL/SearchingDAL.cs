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
    public class SearchingDAL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MediTrackDatabaseConnection"].ConnectionString;
        public static DataTable SearchMedicine(string choice, string searchTerm)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter;
                    switch (choice)
                    {
                        case "1. Medicine Name":
                            adapter = new SqlDataAdapter("SearchByMedName", connection);
                            break;
                        case "2. Brand Name":
                            adapter = new SqlDataAdapter("SearchByBrandName", connection);
                            break;
                        case "3. Generation":
                            adapter = new SqlDataAdapter("SearchByGeneration", connection);
                            break;
                        case "4. Medicine Category":
                            adapter = new SqlDataAdapter("SearchByMedCategory", connection);
                            break;
                        case "5. Medicine Origin":
                            adapter = new SqlDataAdapter("SearchByMedOrigin", connection);
                            break;
                        case "6. Any Term":
                            adapter = new SqlDataAdapter("SearchProcMedicine", connection);
                            break;
                        default:
                            adapter = new SqlDataAdapter("SearchProcMedicine", connection);
                            break;
                    }
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
    }
}
