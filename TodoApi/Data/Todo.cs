namespace TodoApi.Data;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Priority priority { get; set; } = Priority.Medium;
    public bool IsDone { get; set; }

    public DateTime createTime { get; set; }
    public DateTime updateTime { get; set; }
}

public enum  Priority { 
    High,
    Medium,
    Low
}
