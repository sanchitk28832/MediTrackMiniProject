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
    public class PatientDAL
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MediTrackDatabaseConnection"].ConnectionString;
       
      
        public static bool AddToMediCart(int patientId, int medicineId, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // Set the InsertCommand property with the SqlCommand instance
                    adapter.InsertCommand = new SqlCommand("AddToCartProc", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                    adapter.InsertCommand.Parameters.AddWithValue("@PatientId", patientId);
                    adapter.InsertCommand.Parameters.AddWithValue("@MedicineId", medicineId);
                    adapter.InsertCommand.Parameters.AddWithValue("@Quantity", quantity);

                    int result = adapter.InsertCommand.ExecuteNonQuery();

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in MediTrackDAL.AddToCart: {ex.Message}");
                    return false;
                }
            }
        }
        public static DataTable GetCartItems(int patientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("GetCartItemsProc", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.SelectCommand.Parameters.AddWithValue("@PatientId", patientId);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in MediTrackDAL.GetCartItems: {ex.Message}");
                    throw;
                }
            }
        }
        public static bool RemoveFromMediCart(int patientId, int medicineid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand("RemoveFromCartProc", connection);
                    adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

                    adapter.DeleteCommand.Parameters.AddWithValue("@Patient_id", patientId);
                    adapter.DeleteCommand.Parameters.AddWithValue("@Medicine_id", medicineid);

                    int result = adapter.DeleteCommand.ExecuteNonQuery();

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in ShoppingCartDataAccess.RemoveFromCart: {ex.Message}");
                    throw;
                }
            }
        }
        public static bool ClearCart(int patientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("ClearCartProc", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.SelectCommand.Parameters.AddWithValue("@Patient_id", patientId);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                    return dataTable.Rows.Count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in .ClearCart: {ex.Message}");
                    throw;
                }
            }
        }



        public static bool UpdateCartItemQuantity(int patientId, int medicineId, int newQuantity, string updatechoice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
                    {
                        Console.WriteLine($"{e.Message}");
                    };
                    connection.Open();

                    // Set up the SqlDataAdapter with the UpdateCommand
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    if (updatechoice == "1.Add Medicine Quantity")
                    {
                        adapter.UpdateCommand = new SqlCommand("UpdateCartQuantityByAddingQuantity", connection);
                        adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        adapter.UpdateCommand.Parameters.AddWithValue("@MedicineId", medicineId);
                        adapter.UpdateCommand.Parameters.AddWithValue("@UpdateQuantity", newQuantity);
                        adapter.UpdateCommand.Parameters.AddWithValue("@PatientId", patientId);
                    }
                    else if (updatechoice == "2.Subtract Medicine Quantity")
                    {
                        adapter.UpdateCommand = new SqlCommand("UpdateCartQuantityByReducingQuantity", connection);
                        adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        adapter.UpdateCommand.Parameters.AddWithValue("@MedicineId", medicineId);
                        adapter.UpdateCommand.Parameters.AddWithValue("@UpdateQuantity", -newQuantity);
                        adapter.UpdateCommand.Parameters.AddWithValue("@PatientId", patientId);

                    }
                    else if (updatechoice == "3.Replace Medicine Quantity")
                    {
                        adapter.UpdateCommand = new SqlCommand("UpdateReplaceCartQuantity", connection);
                        adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        adapter.UpdateCommand.Parameters.AddWithValue("@MedicineId", medicineId);
                        adapter.UpdateCommand.Parameters.AddWithValue("@UpdateQuantity", newQuantity);
                        adapter.UpdateCommand.Parameters.AddWithValue("@PatientId", patientId);

                    }



                    // Execute the update command
                    int rowsUpdated = adapter.UpdateCommand.ExecuteNonQuery();

                    return rowsUpdated > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in UpdateCartItemQuantity: {ex.Message}");
                    throw;
                }
            }
        }


        public static bool MedicineExistsForPatient(int patientId, int medicineId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CheckMedicineExistsForPatient", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    command.Parameters.AddWithValue("@MedicineId", medicineId);

                    // Output parameter
                    SqlParameter existsParameter = new SqlParameter("@Exists", SqlDbType.Bit);
                    existsParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(existsParameter);

                    command.ExecuteNonQuery();

                    // Retrieve the output parameter value
                    return Convert.ToBoolean(existsParameter.Value);
                }
            }
        }

        public static bool ValidatePassword(int patientId, string enteredPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("ValidatePasswordSP", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Patient_Id", patientId);
                command.Parameters.AddWithValue("@Password", enteredPassword);

                SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.Int);
                resultParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(resultParam);

                connection.Open();
                command.ExecuteNonQuery();

                int result = Convert.ToInt32(resultParam.Value);

                return result > 0;
            }
        }

    }
}
