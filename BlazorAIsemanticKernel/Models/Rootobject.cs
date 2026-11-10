namespace BlazorAIsemanticKernel.Models
{
    //This class represents the root object for an OpenAI API AI model request,
    //containing the model name and an array of Message objects
    //Where each Message object represents a message in the conversation with a role and content.
    public class Rootobject
    {
        public string model { get; set; }   
        public Message[] messages { get; set; }         
    }
}
