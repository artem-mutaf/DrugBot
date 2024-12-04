namespace Insfrastructure.Dal.Models;

public class DBSettings
{
    public string ConnectionString { get; set; }
    
    public int CommandTimeout { get; set; }
}