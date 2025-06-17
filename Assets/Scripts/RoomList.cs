using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Collections;
using TMPro;
public class RoomList : MonoBehaviourPunCallbacks
{
    public static RoomList RLinstance;
    public GameObject roomManagetObj;
    public RoomManager roomManager;
    public Transform roomListParent;
    public GameObject roomListItemPrefab;
    private List<RoomInfo> cachedRoomList = new List<RoomInfo>();

    public void ChangeRoomName(string _roomName)
    {
        roomManager.roomNameToJoin = _roomName;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        RLinstance = this;
    }
    IEnumerator Start()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
        }

        yield return new WaitUntil(() => !PhotonNetwork.IsConnected);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (cachedRoomList.Count <= 0)
        {
            cachedRoomList = roomList;
        }
        else
        {
            foreach (var room in roomList)
            {
                for (int i = 0; i < cachedRoomList.Count; i++)
                {
                    if (cachedRoomList[i].Name == room.Name)
                    {
                        List<RoomInfo> newList = cachedRoomList;
                        if (room.RemovedFromList)
                        {
                            newList.Remove(newList[i]);
                        }
                        else
                        {
                            newList[i] = room;
                        }
                        cachedRoomList = newList;
                    }
                }
            }
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        foreach (Transform roomItem in roomListParent)
        {
            Destroy(roomItem.gameObject);
        }

        foreach (var room in cachedRoomList)
        {
            GameObject roomItem = Instantiate(roomListItemPrefab, roomListParent);
            roomItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = room.Name;
            roomItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = room.PlayerCount + "/6";
            roomItem.GetComponent<RoomItemButton>().roomName = room.Name;
        }
    }

    public void JoinRoomByName(string _name)
    {
        roomManager.roomNameToJoin = _name;
        roomManagetObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
