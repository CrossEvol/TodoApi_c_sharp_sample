namespace TodoApi.Data;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Priority Priority { get; set; } = Priority.Medium;
    public bool IsDone { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}

public enum  Priority { 
    High,
    Medium,
    Low
}
