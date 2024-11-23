namespace Backend.Application.Common.Responses;

public class ImportMessage
{
    public string? Message { set; get; }
    public int SucccesCount { set; get; }
    public int FaildCount { set; get; }
    public bool IsSucceed { set; get; }

}
