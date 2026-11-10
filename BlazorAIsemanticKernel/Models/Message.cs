namespace BlazorAIsemanticKernel.Models
{
    // This class represents a message in a conversation, with a role (e.g., user, assistant) and content.
    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
