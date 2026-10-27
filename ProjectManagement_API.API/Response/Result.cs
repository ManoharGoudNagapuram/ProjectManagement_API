namespace ProjectManagement_API.API.Response
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }
        public T Data {  get; set; }
        public ErrorResult Error { get; set; }
    }

}
