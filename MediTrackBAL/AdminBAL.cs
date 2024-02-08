using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediTrackDAL;

namespace MediTrackBAL
{
    public class AdminBAL
    {

        public static DataTable GetMedicines()
        {

            try
            {
                return AdminDAL.GetMedicines();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AdminFunctionality.GetMedicines: {ex.Message}");
                throw;
            }

        }


        public static DataTable GetMedicineCategory()
        {

            try
            {
                return AdminDAL.GetMedicineCategory();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AdminFunctionality.GetMedicineCategory: {ex.Message}");
                throw;
            }

        }



        public static DataTable GetPatientsDetails()
        {

            try
            {
                return AdminDAL.GetPatientsDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AdminFunctionality.GetPatients: {ex.Message}");
                throw;
            }

        }


        public static bool UpdateMedicine(int medicineId, string medicineName = null, string brandName = null, string origin = null, string generation = null, decimal? cost = null, int? categoryId = null, int? medquntity = null)
        {
            try
            {
                return AdminDAL.UpdateMedicine(medicineId, medicineName, brandName, origin, generation, cost, categoryId, medquntity);

            }
            catch (Exception)
            {
               
                return false;
            }
        }









        public static bool AddNewMedicine(string medicineName, string brandName, string origin, string generation, decimal cost,int quantity, int categoryId)
        {

            try
            {
                return AdminDAL.AddNewMedicine(medicineName, brandName, origin, generation, cost, quantity, categoryId);

            }
            catch (Exception)
            {
                
                return false;
            }

        }



        public static bool DeleteMedicine(int medicineId)
        {
            try
            {
                return AdminDAL.DeleteMedicine(medicineId);
            }
            catch (Exception)
            {
                
                return false;
            }

        }




        public static bool DeletePatient(int patientId)
        {
            try
            {
                return AdminDAL.DeletePatient(patientId);
            }
            catch (Exception)
            {
            
                return false;
            }

        }



    }
}
