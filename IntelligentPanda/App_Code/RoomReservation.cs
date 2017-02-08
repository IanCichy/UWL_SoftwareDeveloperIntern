/// <summary>
/// Summary description for RoomReservation
/// </summary>
public class RoomReservation
{
    public string hall { get; set; }

    public string room { get; set; }

    public int beds;

    // Gender is in {'m', 'f', ' '} where 'm' signifies male, 'f' signifies female, and ' ' signifies a gender neutral room
    public char gender;

    public RoomReservation(string hall, string room, int beds, char gender)
    {
        this.hall = hall;
        this.room = room;
        this.beds = beds;
        this.gender = gender;
    }
}