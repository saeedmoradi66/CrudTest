namespace Project1.Domain.Common
{
    public class Response<T>
    {
        public Response()
        {
            Succeeded = true;
        }
        public Response(string message)
        {
            Succeeded = true;
            Messages = message;
        }
        public Response(T? data)
        {
            Succeeded = true;
            Data = data;
        }
        public Response(T? data, List<string>? errorList = null)
        {
            Succeeded = false;
            Data = data;
            ErrorList = errorList;
        }
        public Response(T? data, bool succeeded)
        {
            Succeeded = succeeded;
            Data = data;
        }

        public T? Data { get; set; }
        public bool Succeeded { get; set; }
        public string? Messages { get; set; }
        public List<string>? ErrorList { get; set; }
    }


}
