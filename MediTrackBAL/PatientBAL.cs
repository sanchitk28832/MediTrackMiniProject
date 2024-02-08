using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediTrackDAL;

namespace MediTrackBAL
{
    public class PatientBAL
    {
  
     
        public static bool RemoveFromMediCart(int patientId, int medicineid)
        {
            try
            {
                return PatientDAL.RemoveFromMediCart(patientId, medicineid);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MediTrackBAL.RemoveFromMediCart: {ex.Message}");
                throw;
            }
        }
        public static bool AddToMediCart(int patientId, int medicineId, int quantity)
        {
            try
            {
                return PatientDAL.AddToMediCart(patientId, medicineId, quantity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MediTrackBAL.AddToMediCart: {ex.Message}");
                return false;
            }
        }
        public static DataTable GetCartItems(int patientId)
        {
            try
            {
                return PatientDAL.GetCartItems(patientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MediTrackBAL.GetCartItems: {ex.Message}");
                throw;
            }
        }
        public static bool ClearCart(int patientId)
        {
            try
            {
                return PatientDAL.ClearCart(patientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MediTrackBAL.ClearCart: {ex.Message}");
                throw;
            }
        }
        public static bool UpdateCartItemQuantity(int patientId, int medicineId, int newQuantity,string updatechoice)
        {
            try
            {
                return PatientDAL.UpdateCartItemQuantity(patientId, medicineId, newQuantity, updatechoice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MediTrackBAL.UpdateCartItemQuantity: {ex.Message}");
                throw;
            }
        }
        public static bool MedicineExistsForPatient(int patientId, int medicineId)
        {
            return PatientDAL.MedicineExistsForPatient(patientId, medicineId);
        }
        public static bool PasswordCheck(int patientId, string enteredPassword)
        {
            return PatientDAL.ValidatePassword(patientId, enteredPassword);
        }
    }
}
