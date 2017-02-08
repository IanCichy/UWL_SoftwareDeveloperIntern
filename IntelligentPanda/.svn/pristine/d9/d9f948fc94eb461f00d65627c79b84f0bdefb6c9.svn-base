using System.Drawing;

/// <summary>
/// Contains the room number, coordinates, width, height, and status of a room.
/// This information is used to generate the buttons for RoomControl.ascx
/// </summary>
public class Room
{
    private string roomNumber, leftCoord, topCoord, width, height;
    private Color status;

    public Room(string roomNumber, string leftCoord, string topCoord, string width, string height, Color status)
    {
        this.width = width;
        this.height = height;
        this.roomNumber = roomNumber;
        this.leftCoord = leftCoord;
        this.topCoord = topCoord;
        this.status = status;
    }

    public string getWidth()
    {
        return width;
    }

    public string getHeight()
    {
        return height;
    }

    public string getRoom()
    {
        return roomNumber;
    }

    public string getLeftCoord()
    {
        return leftCoord + "px";
    }

    public string getTopCoord()
    {
        return topCoord + "px";
    }

    public Color getStatus()
    {
        return status;
    }
}