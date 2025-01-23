public class BaseEntity
{
    private string? _id;

    protected BaseEntity(string? id)
    {
        _id = id;
    }

    public string Id
    {
        get
        {
            if (string.IsNullOrEmpty(_id))
            {
                _id = Guid.NewGuid().ToString();
            }
            return _id;
        }
        set { _id = value; }
    }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
