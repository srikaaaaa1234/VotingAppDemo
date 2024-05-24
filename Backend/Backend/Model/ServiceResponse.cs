namespace Backend.Model
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Status { get; set; } = true;
        public string Message { get; set; } = null;
    }
}
