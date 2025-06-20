using UnityEngine;
using Photon.Pun;

public class GameStart : MonoBehaviour
{
    public delegate void GMSinstance();
    public static event GMSinstance gameStart, gameEnded;
    public PhotonView photonView;
    public GameObject startCanvas, door;
    public bool isInGame = false;

        void OnEnable()
    {
        PlayerTasks.AllTaskDone += TaskDone;   
    }
    void OnDisable()
    {
        PlayerTasks.AllTaskDone -= TaskDone;  
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isInGame == false)
        {
            startCanvas.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.GetComponent<PhotonView>().RPC("TheGameStart", RpcTarget.AllBuffered);
                gameObject.GetComponent<PhotonView>().RPC("DeactivateDoor", RpcTarget.AllBuffered);
                isInGame = true;
            }
        }
        else
        {
            startCanvas.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        startCanvas.SetActive(false);
    }

    void TaskDone()
    {
        gameObject.GetComponent<PhotonView>().RPC("GameEnded", RpcTarget.All);
    }
    [PunRPC]
    public void TheGameStart()
    {
        gameStart.Invoke();
    }
    [PunRPC]
    public void GameEnded()
    {
        gameEnded.Invoke();
    }
    [PunRPC]
    public void DeactivateDoor()
    {
        door.SetActive(false);
    }
}
