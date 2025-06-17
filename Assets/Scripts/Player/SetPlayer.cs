using UnityEngine;
using Photon.Pun;
using TMPro;
public class SetPlayer : MonoBehaviour
{
    public Player player;
    public PlayerTasks playerTasks;
    public Inventory inventory;
    public PressE pressE;
    public StressMeter stressMeter;
    public GameObject cam, canvas;

    public string playerName;
    public TextMeshPro nameDisplay;
    public Transform TPHolder;

    public void IsLocalPlayer()
    {
        player.enabled = true;
        playerTasks.enabled = true;
        inventory.enabled = true;
        pressE.enabled = true;
        stressMeter.enabled = true;
        cam.SetActive(true);
        canvas.SetActive(true);
        TPHolder.gameObject.SetActive(false);

    }

    [PunRPC]
    public void SetItemTP(int _itemIndex)
    {
        foreach (Transform _item in TPHolder)
        {
            _item.gameObject.SetActive(false);
        }
        TPHolder.GetChild(_itemIndex).gameObject.SetActive(true);
    }

    [PunRPC]
    public void SetName(string _name)
    {
        playerName = _name;
        nameDisplay.text = playerName;
    }
}
