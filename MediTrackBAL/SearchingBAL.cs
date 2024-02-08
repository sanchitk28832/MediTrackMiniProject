using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediTrackDAL;

namespace MediTrackBAL
{
    public class SearchingBAL
    {
        public static DataTable SearchMedicine(string choice, string searchTerm)
        {
            try
            {
                return SearchingDAL.SearchMedicine(choice, searchTerm);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ProductBusinessLogic.SearchProducts: {ex.Message}");
                throw;
            }
        }
    }
}
