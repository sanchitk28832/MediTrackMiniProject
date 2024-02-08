using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediTrackDAL;


namespace MediTrackBAL
{
    public class LoginRegBAL
    {



        public static bool RegisterPatient(string patientName, string patientEmail, double patientPhone, string regPassword, int patientAge)
        {
            try
            {
                return LoginRegDAL.RegisterPatient(patientName, patientEmail, patientPhone, regPassword, patientAge);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserBusinessLogic.RegisterUser: {ex.Message}");
                throw;
            }
        }
        public static bool ValidateLogin(string email, string password)
        {
            try
            {
                return LoginRegDAL.ValidateLogin(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserBusinessLogic.ValidateLogin: {ex.Message}");
                throw;
            }
        }
        public static int GetPatientId(string email, string password)
        {
            try
            {
                return LoginRegDAL.GetPatientId(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserBusinessLogic.GetUserId: {ex.Message}");
                throw;
            }
        }
        //Ading Login Register
  
        public static bool ValidateAdmin(string email, string password)
        {
            try
            {
                return LoginRegDAL.ValidateAdmin(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserBusinessLogic.ValidateLogin: {ex.Message}");
                throw;
            }
        }
        public static int GetAdminId(string email, string password)
        {
            try
            {
                return LoginRegDAL.GetAdminId(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserBusinessLogic.GetUserId: {ex.Message}");
                throw;
            }
        }










        //-----------------------------------------------------------------------
        public static bool forgotPassword(string forgEmail)
        {
            try
            {
                return LoginRegDAL.forgotPassword(forgEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserBusinessLogic.ValidateLogin: {ex.Message}");
                throw;
            }
        }
        public static bool changePassword(string forgEmail, string forgPassword)
        {
            try
            {
                return LoginRegDAL.changePassword(forgEmail, forgPassword);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserBusinessLogic.ValidateLogin: {ex.Message}");
                throw;
            }
        }










    }
}
