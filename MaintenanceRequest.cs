
using System.Collections.Generic; // This may already be present
using System.Linq; // This may already be present

public class MaintenanceRequest
{
    public string Description { get; set; }

    public MaintenanceRequest(string description)
    {
        Description = description;
    }
}
