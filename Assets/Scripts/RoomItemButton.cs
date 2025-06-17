using UnityEngine;

public class RoomItemButton : MonoBehaviour
{
    public string roomName;
    public void OnButtonPressed()
    {
        RoomList.RLinstance.JoinRoomByName(roomName);
    }
}
