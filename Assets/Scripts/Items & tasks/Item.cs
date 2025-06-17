using UnityEngine;
using Photon.Pun;

public class Item : Distance
{
    public enum ItemsPlayer { Bat, Pistol, Battery }
    public ItemsPlayer itemsPlayer;
    public int numItem;
    public bool isDeavtivated;
    public PhotonView pv;

    public delegate void ItemsNotify();
    public static event ItemsNotify BatNotify, PistolNotify, BatteryNorify, HaveTheItem;
    void OnEnable()
    {
        PressE.PickUpNotify += PickingUp;
    }

    void OnDisable()
    {
        PressE.PickUpNotify -= PickingUp;
    }

    void Start()
    {
        gameObject.GetComponent<PhotonView>().RPC("SetItem", RpcTarget.All, Random.Range(0, 3));
        switch (numItem)
        {
            case 0:
                itemsPlayer = ItemsPlayer.Bat;
                break;
            case 1:
                itemsPlayer = ItemsPlayer.Battery;
                break;
            case 2:
                itemsPlayer = ItemsPlayer.Pistol;
                break;

        }
    }


    void PickingUp()
    {
        switch (itemsPlayer)
        {
            case ItemsPlayer.Bat:
                if (isClose == true)
                {
                    gameObject.GetComponent<PhotonView>().RPC("Deactivate", RpcTarget.All);
                    BatNotify.Invoke();
                    HaveTheItem.Invoke();
                }

                break;
            case ItemsPlayer.Pistol:
                if (isClose == true)
                {
                    gameObject.GetComponent<PhotonView>().RPC("Deactivate", RpcTarget.All);
                    PistolNotify.Invoke();
                    HaveTheItem.Invoke();
                }

                break;
            case ItemsPlayer.Battery:
                if (isClose == true)
                {
                    gameObject.GetComponent<PhotonView>().RPC("Deactivate", RpcTarget.All);
                    BatteryNorify.Invoke();
                    HaveTheItem.Invoke();
                }

                break;
        }

    }
    [PunRPC]
    public void SetItem(int _index)
    {
        numItem = _index;
    }
    [PunRPC]
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
