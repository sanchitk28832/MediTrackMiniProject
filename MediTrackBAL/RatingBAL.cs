using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediTrackDAL;

namespace MediTrackBAL
{
    public class RatingBAL
    {

        public static void GiveRatings(int medicine_id, int patient_id, decimal rating, string feedback, int userId)
        {
                RatingDAL.GiveRatings(medicine_id,patient_id, rating, feedback, userId);
        }


        public static DataTable MedicineRatings(int Id)
        {
            return RatingDAL.MedicineRatings(Id);
        }

        public static DataTable MedicineUpdatedRatingAndFeedback(int Id, int patientId, decimal rating, string feedback)
        {
            return RatingDAL.MedicineUpdatedRatingAndFeedback(Id, patientId, rating, feedback);
        }


        public static void DeleteRating(int ratingId)
        {
            RatingDAL.DeleteRating(ratingId);
        }
      
            public static DataTable GetAllRatings()
            {
                return RatingDAL.GetAllRatings();
            }
        

        public static DataTable SearchMedicine(string searchTerm)
        {
            try
            {
                return RatingDAL.SearchMedicine(searchTerm);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ProductBusinessLogic.SearchProducts: {ex.Message}");
                throw;
            }
        }

        public static DataTable SearchMedicineRating(string search)
        {
            try
            {
                return RatingDAL.SearchMedicine(search);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ProductBusinessLogic.SearchProducts: {ex.Message}");
                throw;
            }
        }












 






    }
}
