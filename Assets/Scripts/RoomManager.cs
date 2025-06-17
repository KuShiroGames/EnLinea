using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager RMinsance;
    public GameObject player;
    [Space]
    public Transform spawnPoint;
    [Space]
    private string namePlayer = "unnamed";
    public GameObject nameUI;
    public GameObject joinUI;
    public GameObject cam;
    public string roomNameToJoin = "test";

    void Awake()
    {
        RMinsance = this;
    }

    public void ChangeName(string _name)
    {
        namePlayer = _name;
    }

    public void JoinRoomButton()
    {
        nameUI.SetActive(false);
        joinUI.SetActive(true);
        Debug.Log("conecting. . . ");
        PhotonNetwork.JoinOrCreateRoom(roomNameToJoin, new RoomOptions { MaxPlayers = 6}, null);
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        cam.SetActive(false);
        _player.GetComponent<SetPlayer>().IsLocalPlayer();
        _player.GetComponent<PhotonView>().RPC("SetName", RpcTarget.AllBuffered, namePlayer);
        PhotonNetwork.LocalPlayer.NickName = namePlayer;
    }

}
