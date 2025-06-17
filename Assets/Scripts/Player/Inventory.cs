using Photon.Pun;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public PhotonView playerSetup;
    [SerializeField] private bool haveItem;
    [SerializeField] private GameObject BatItem, PistolItem, BatteryItem;
    [SerializeField] int itemIndexer;

    void Start()
    {
        BatItem.SetActive(false);
        PistolItem.SetActive(false);
        BatteryItem.SetActive(false);
        itemIndexer = 3;
    }
    void Update()
    {
        playerSetup.RPC("SetItemTP", RpcTarget.All, itemIndexer);
        
    }
    void OnEnable()
    {

        Item.BatNotify += HaveBat;
        Item.PistolNotify += HavePistol;
        Item.BatteryNorify += HaveBattery;
        Item.HaveTheItem += truelItem;
        Pistol.dontHavePistol += falseItem;
        Bat.dontHaveBat += falseItem;
        
        
    }
    void OnDisable()
    {
        Item.BatNotify -= HaveBat;
        Item.PistolNotify -= HavePistol;
        Item.BatteryNorify -= HaveBattery;
        Item.HaveTheItem -= truelItem;
        Bat.dontHaveBat -= falseItem;
    }


    void truelItem(){
        haveItem = true;
    }
    void falseItem()
    {
        haveItem = false;
        itemIndexer = 3;
    }
    void HaveBat()
    {
        if (haveItem == false)
        {
            itemIndexer = 0;   
            BatItem.SetActive(true);
        }
        
    }

    void HavePistol()
    {
        if (haveItem == false)
        {
            itemIndexer = 1;
            PistolItem.SetActive(true);
        }
        
    }
    void HaveBattery()
    {
        if (haveItem == false)
        {
            itemIndexer = 2;
            BatteryItem.SetActive(true);
        }
        
    }
}
