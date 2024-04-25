public class DormRoom : Residence
{
    public int RoomSize { get; set; }

    public DormRoom(string residenceID, int roomSize) : base(residenceID)
    {
        RoomSize = roomSize;
    }

    public override decimal CalculateMonthlyRent()
    {
        // Implement rent calculation based on room size
        return RoomSize * 100; // Assuming $100 per unit of room size
    }
}
