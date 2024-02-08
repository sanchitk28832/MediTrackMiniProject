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
    public class LoginRegDAL
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MediTrackDatabaseConnection"].ConnectionString;
        

        public static bool RegisterPatient(string patientName, string patientEmail, double patientPhone, string regPassword, int patientAge)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("RegisterPatientProc", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@name", patientName);
                    adapter.SelectCommand.Parameters.AddWithValue("@email", patientEmail);
                    adapter.SelectCommand.Parameters.AddWithValue("@phone", patientPhone);
                    adapter.SelectCommand.Parameters.AddWithValue("@Password", regPassword);
                    adapter.SelectCommand.Parameters.AddWithValue("@age", patientAge);


                    int result = adapter.SelectCommand.ExecuteNonQuery();

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in UserDataAccess.RegisterUser: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }
        public static bool ValidateLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("ValidateLoginProc", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@Username", username);
                    adapter.SelectCommand.Parameters.AddWithValue("@Password", password);

                    SqlParameter resultParameter = new SqlParameter("@Result", SqlDbType.Int);
                    resultParameter.Direction = ParameterDirection.Output;
                    adapter.SelectCommand.Parameters.Add(resultParameter);

                    adapter.SelectCommand.ExecuteNonQuery();

                    int result = (int)resultParameter.Value;

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in Dal.ValidateLogin: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }
        public static int GetPatientId(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("GetPatientIdProc", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.SelectCommand.Parameters.AddWithValue("@Username", username);
                    adapter.SelectCommand.Parameters.AddWithValue("@Password", password);

                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        int patientId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["patient_id"]);
                        if (patientId > 0)
                        {
                            Console.WriteLine($"Patient with Name '{dataSet.Tables[0].Rows[0]["patient_name"]}' logged in successfully! (PatientID: {dataSet.Tables[0].Rows[0]["patient_id"]})\n");
                        }
                        return patientId;
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in UserDataAccess.GetUserId: {ex.Message}");
                    throw;
                }
            }
        }

        //Admin Login
        public static bool ValidateAdmin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("ValidateAdminProc", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@Username", username);
                    adapter.SelectCommand.Parameters.AddWithValue("@Password", password);

                    SqlParameter resultParameter = new SqlParameter("@Result", SqlDbType.Int);
                    resultParameter.Direction = ParameterDirection.Output;
                    adapter.SelectCommand.Parameters.Add(resultParameter);

                    adapter.SelectCommand.ExecuteNonQuery();

                    int result = (int)resultParameter.Value;

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in Dal.ValidateLogin: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }
        public static int GetAdminId(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("GetAdminIdProc", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    adapter.SelectCommand.Parameters.AddWithValue("@Username", username);
                    adapter.SelectCommand.Parameters.AddWithValue("@Password", password);

                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        int adminId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["admin_id"]);
                        if (adminId > 0)
                        {
                            Console.WriteLine($"Admin with Name '{dataSet.Tables[0].Rows[0]["admin_name"]}' logged in successfully! (AdminID: {dataSet.Tables[0].Rows[0]["admin_id"]})\n");
                        }
                        return adminId;
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in UserDataAccess.GetUserId: {ex.Message}");
                    throw;
                }
            }
        }






        //-----------------------------------------------------------------------


        public static bool forgotPassword(string forgEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("forgPasswordProc", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@forgEmail", forgEmail);

                    SqlParameter resultParameter = new SqlParameter("@Result", SqlDbType.Int);
                    resultParameter.Direction = ParameterDirection.Output;
                    adapter.SelectCommand.Parameters.Add(resultParameter);

                    adapter.SelectCommand.ExecuteNonQuery();

                    int result = (int)resultParameter.Value;

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in Dal.ValidateLogin: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }


        public static bool changePassword(string forgEmail, string forgPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("changePasswordProc", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@forgEmail", forgEmail);
                    adapter.SelectCommand.Parameters.AddWithValue("@forgPassword", forgPassword);

                    SqlParameter resultParameter = new SqlParameter("@Result", SqlDbType.Int);
                    resultParameter.Direction = ParameterDirection.Output;
                    adapter.SelectCommand.Parameters.Add(resultParameter);

                    adapter.SelectCommand.ExecuteNonQuery();

                    int result = (int)resultParameter.Value;

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in Dal.ValidateLogin: {ex.Message}");
                    throw; // Re-throw the exception for the caller to handle
                }
            }
        }
































    }
}
