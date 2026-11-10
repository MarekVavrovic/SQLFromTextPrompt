using Microsoft.Data.SqlClient;

namespace BlazorAIsemanticKernel.Models
{
    
    public static class DataService
    {
        
        public static List<List<string>> GetDataTable(string sqlQuery)
        {
            // This method executes the provided SQL query and returns the results as a list of rows, where each row is a list of string values.
            
            var rows = new List<List<string>>();          
            
            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=SongListBase;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();                                               

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))   
                {

                    using (SqlDataReader reader = command.ExecuteReader())         
                    {
                        int count = 0;
                        bool headersAdded = false;

                        while (reader.Read())                                       // Read each row from the SqlDataReader ojbect reader
                        {
                            count++;
                            
                            var cols = new List<string>();                          // Create a list to hold the column values for the current row
                            var headerCols = new List<string>();                    // Create a list to hold the column names (headers)

                            // Add column headers only once, before adding the first row of data
                            if (!headersAdded)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    headerCols.Add(reader.GetName(i).ToString());
                                }
                                rows.Add(headerCols);                               
                                headersAdded = true;                                
                            }

                            // Loop through each column in the current row and add its value to the cols list
                            for (int i = 0; i <= reader.FieldCount - 1; i++)
                            {
                                try
                                {
                                    cols.Add(reader.GetValue(i).ToString());
                                }
                                catch (Exception ex)
                                {
                                    cols.Add("DataTypeConversionError");
                                }
                            }

                            rows.Add(cols);                                         // Add the current row (cols) to the list of rows
                        }
                    }
                }

            }

            return rows;                                                            // Return the list of rows, where each row is a list of string values
        }
    }
}
