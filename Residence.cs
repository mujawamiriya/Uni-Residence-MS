public abstract class Residence
{
    public string ResidenceID { get; set; }
    public bool IsOccupied { get; set; }

    public Residence(string residenceID)
    {
        ResidenceID = residenceID;
        IsOccupied = false;
    }

    public abstract decimal CalculateMonthlyRent();
}
