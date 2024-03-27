using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Net.Security;
using Waste_Management_App.Model;

namespace Waste_Management_App.Pages
{
    public class AddWasteModel : PageModel
    {
        public Collection newCollection = new Collection();
        public String errorMessage = "";
        public void OnGet()
        {
        }

        public void OnPost() {
            newCollection.name = Request.Form["name"];
            newCollection.surname = Request.Form["surname"];
            newCollection.contact_number = Request.Form["contact_number"];
            newCollection.business_name = Request.Form["business_name"];
            newCollection.waste_type = Request.Form["waste_type"];
            newCollection.collection_type = Request.Form["CollectionType"];
            newCollection.weight = Double.Parse(Request.Form["weight"]);

            if (newCollection.collection_type == "Donation" && newCollection.business_name.Length == 0) {
                errorMessage = "Please enter a Business Name if this is a donation.";
                return;
            }
            
            if(newCollection.name.Length==0|| newCollection.surname.Length==0||
                newCollection.contact_number.Length==0||newCollection.waste_type.Length==0
                ||newCollection.collection_type.Length == 0 ||newCollection.weight<=0) {
                errorMessage = "Please complete all fields";
                return;
            }
            //Save the new Waste to the database
            try
            {
                String connectionString = "Data Source=ARMINGTON;Initial Catalog=database;Integrated Security=True;Encrypt=False";
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                connection.Open();
                    String sql = "INSERT INTO collections " +
                            "(name,surname,contact_number,business_name,waste_type,collection_type,weight) VALUES" +
                            "(@name,@surname,@contact_number,@business_name,@waste_type,@collection_type,@weight)";
                using(SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("@name",newCollection.name);
                        command.Parameters.AddWithValue("@surname", newCollection.surname);
                        command.Parameters.AddWithValue("@contact_number", newCollection.contact_number);
                        command.Parameters.AddWithValue("@business_name", newCollection.business_name);
                        command.Parameters.AddWithValue("@waste_type", newCollection.waste_type);
                        command.Parameters.AddWithValue("@collection_type", newCollection.collection_type);
                        command.Parameters.AddWithValue("@weight", newCollection.weight);

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

            //newCollection.name = "";
            //newCollection.surname = "";
            //newCollection.contact_number = "";
            //newCollection.business_name = "";
            //newCollection.waste_type = "";
            //newCollection.collection_type = "";
            //newCollection.weight = "";

            Response.Redirect("/Home");
        }
    }
}
