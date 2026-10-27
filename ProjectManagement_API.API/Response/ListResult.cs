namespace ProjectManagement_API.API.Response
{
    public class ListResult<T> where T : class
    {
        public bool Success { get; set; }
        public List<T> Data { get; set; }
        public ErrorResult Error { get; set; }
    }
}
