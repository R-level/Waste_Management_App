using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using Waste_Management_App.Model;


namespace Waste_Management_App.Pages.Sales
{
    public class AddSalesModel : PageModel
    {
        Sale sales = new Sale();
        public string errorMessage = "";
        public void OnGet()
        {

        }
        public void OnPost()
        {

            sales.company_name = Request.Form["Company_name"];
            sales.company_contact = Request.Form["Company_contact"];
            sales.glass_bottle_weight = double.Parse(Request.Form["Glass_bottle_weight"]);
            sales.glass_bottle_price = double.Parse(Request.Form["Glass_bottle_price"]);
            sales.metal_weight = double.Parse(Request.Form["Metal_weight"]);
            sales.metal_price = double.Parse(Request.Form["Metal_price"]);
            sales.cardboard_weight = double.Parse(Request.Form["Cardboard_weight"]);
            sales.cardboard_price = double.Parse(Request.Form["Cardboard_price"]);
            sales.aluminium_can_weight = double.Parse(Request.Form["Aluminium_Cans_weight"]);
            sales.aluminium_can_price = double.Parse(Request.Form["Aluminium_can_price"]);
            sales.plastic_weight = double.Parse(Request.Form["Plastic_weight"]);
            sales.plastic_price = double.Parse(Request.Form["Plastic_price"]);
            sales.paper_weight = double.Parse(Request.Form["Paper_weight"]);
            sales.paper_price = double.Parse(Request.Form["Paper_price"]);
            
           
            sales.sales_total = (sales.glass_bottle_weight * sales.glass_bottle_price) + (sales.metal_weight * sales.metal_price) + (sales.cardboard_weight * sales.cardboard_price) + (sales.aluminium_can_price * sales.aluminium_can_weight) + (sales.plastic_price * sales.plastic_weight) + (sales.paper_weight * sales.plastic_price); 


            //Save the new Waste to the database
            try
            {
                string connectionString = "Data Source=ARMINGTON;Initial Catalog=database;Integrated Security=True;Encrypt=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO sales " +
                            "(company_name,company_contact,glass_bottle_weight,glass_bottle_price," +
                            "metal_weight,metal_price,cardboard_weight,cardboard_price,aluminium_can_weight,aluminium_can_price," +
                            "plastic_weight,plastic_price,paper_weight,paper_price,sales_total) VALUES" +
                              "(@company_name,@company_contact,@glass_bottle_weight,@glass_bottle_price," +
                              "@metal_weight,@metal_price,@cardboard_weight,@cardboard_price,@aluminium_can_weight," +
                              "@aluminium_can_price,@plastic_weight,@plastic_price,@paper_weight,@paper_price,@sales_total)";



                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@company_name", sales.company_name);
                        command.Parameters.AddWithValue("@company_contact", sales.company_contact);
                        command.Parameters.AddWithValue("@glass_bottle_weight", sales.glass_bottle_weight);
                        command.Parameters.AddWithValue("@glass_bottle_price", sales.glass_bottle_price);
                        command.Parameters.AddWithValue("@metal_weight", sales.metal_weight);
                        command.Parameters.AddWithValue("@metal_price", sales.metal_price);
                        command.Parameters.AddWithValue("@cardboard_weight", sales.cardboard_weight);
                        command.Parameters.AddWithValue("@cardboard_price", sales.cardboard_price);
                        command.Parameters.AddWithValue("@aluminium_can_weight", sales.aluminium_can_weight);
                        command.Parameters.AddWithValue("@aluminium_can_price", sales.aluminium_can_price);
                        command.Parameters.AddWithValue("@plastic_weight", sales.plastic_weight);
                        command.Parameters.AddWithValue("@plastic_price", sales.plastic_price);
                        command.Parameters.AddWithValue("@paper_weight", sales.paper_weight);
                        command.Parameters.AddWithValue("@paper_price", sales.paper_price);
                        command.Parameters.AddWithValue("@sales_total", sales.sales_total);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }

   
}
