namespace BlazorAIsemanticKernel.Models
{

    // Used to store the apiResponse as a Deserialized  JSON string
    // Summary = response.summary;
    // Query = response.query;
    public class AIQuery
    {
        public string summary { get; set; } 
        public string query { get; set; }   
    }
}
