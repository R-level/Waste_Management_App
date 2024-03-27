using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Waste_Management_App.Model;


namespace Waste_Management_App.Pages.Collections
{
    public class ViewCollectionsModel : PageModel
    {
        public List<Collection> listOfCollections = new List<Collection>();
       public String errorMessage = "";
        
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source= ARMINGTON;Initial Catalog=database;Integrated Security=True;Encrypt=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    string sql = "SELECT * FROM collections";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                Collection newCollection = new Collection();

                               newCollection.id = "" + reader.GetInt32(0);
                                    newCollection.name = reader.GetString(1);
                                    newCollection.surname = reader.GetString(2);
                                    newCollection.contact_number = reader.GetString(3);
                                    newCollection.business_name = reader.GetString(4);
                                    newCollection.waste_type = reader.GetString(5);
                                    newCollection.collection_type = reader.GetString(6);
                                    newCollection.weight = reader.GetDouble(7);
                                    newCollection.date = reader.GetDateTime(8);
                                
                                
                                listOfCollections.Add(newCollection);
                               
                            }
                            reader.Close();
                            
                        }

                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                errorMessage= "Exception: " + ex.ToString();
            }

        }
    }



}
