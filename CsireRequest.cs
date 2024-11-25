namespace MyApplication;

public enum RequestStatus
{
    PendingSend,    // oczekujący na wysłanie
    SendPendingResponse,
    Completed,
}


public class CsireRequest
{
    public int Id { get; set; }

    public string ProcessNumber { get; set; } = "";
    public string Description { get; set; } = "";

    public RequestStatus Status { get; set; }

    public string CreatedBy { get; set; } = "";
    public DateTime CreatedOnUtc { get; set; }

    public string MessageId { get; set; } = "";
    public string Message { get; set; } = "";
    public DateTime? SentOnUtc { get; set; }

    public string? ResultCode { get; set; }
    public string? ResultDescription { get; set; }
    public DateTime? AnsweredOnUtc { get; set; }

    public bool? ResultSuccess => ResultCode?.StartsWith("CA");

    public string? AcknowledgedBy { get; set; }
    public DateTime? AcknowledgedOn { get; set; }


    public CsireRequest()
    {
    }
}
