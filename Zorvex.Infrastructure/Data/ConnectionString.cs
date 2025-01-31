

namespace Zorvex.Infrastructure.Data;
public class ConnectionString
{
    public string Value { get; }

    public ConnectionString(string value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
}