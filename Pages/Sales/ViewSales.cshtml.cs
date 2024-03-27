using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Waste_Management_App.Model;


namespace Waste_Management_App.Pages.Sales
{
    public class ViewSalesModel : PageModel
    {
        public String errorMessage = "";
        public List<Sale> listOfSales = new List<Sale>();
        
        public void OnGet()
        {

            try
            {
                String connectionString = "Data Source= ARMINGTON;Initial Catalog=database;Integrated Security=True;Encrypt=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM sales";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Sale newSale = new Sale();
                                newSale.id                       = "" + reader.GetInt32(0);
                                newSale.company_name             = reader.GetString(1);
                                newSale.company_contact          = reader.GetString(2);
                                newSale.glass_bottle_weight      = reader.GetDouble(3);
                                newSale.glass_bottle_price       = reader.GetDouble(4);
                                newSale.metal_weight             = reader.GetDouble(5);
                                newSale.metal_price              = reader.GetDouble(6);
                                newSale.cardboard_weight         = reader.GetDouble(7);
                                newSale.cardboard_price          = reader.GetDouble(8);
                                newSale.aluminium_can_weight     = reader.GetDouble(9);
                                newSale.aluminium_can_price      = reader.GetDouble(10);
                                newSale.paper_weight             = reader.GetDouble(11);
                                newSale.paper_price              = reader.GetDouble(12);
                                newSale.date                     = reader.GetDateTime(13);
                                newSale.plastic_weight           = reader.GetDouble(14);
                                newSale.plastic_price            = reader.GetDouble(15);
                                newSale.sales_total              = reader.GetDouble(16);
    
                                listOfSales.Add(newSale);

                            }
                           

                        }

                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Exception: " + ex.ToString();
            }

        }
    }
}
