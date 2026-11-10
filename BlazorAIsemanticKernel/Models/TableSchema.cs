namespace BlazorAIsemanticKernel.Models
{
    public class TableSchema
    {
        //used in the GenerateSchema.razor page to hold the table name and columns
        public string TableName { get; set; }
        public List<string> Columns { get; set; }   
    }
}
