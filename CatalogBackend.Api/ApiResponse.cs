namespace CatalogBackend.Api
{
  public class ApiResponse<T>
  {
    public Status Status { get; set; }
    public T Data { get; set; }
    public IList<Error> Errors { get; set; } = new List<Error>(); // Initialize Errors

  }

  public class Status
  {
    public int Code { get; set; }
    public string Message { get; set; }
  }

  public class Error
  {
    public string Code { get; set; }
    public string Message { get; set; }
    public string Field { get; set; }
  }
}
