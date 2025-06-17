using Photon.Pun;
using UnityEngine;

public class Distance : MonoBehaviour
{
   [SerializeField] Transform player;
    [SerializeField] GameObject playerObj;
    [SerializeField] float meter;
    public bool isClose;

    void Start()
    {
        isClose = false;
        
    }

    void Update()
    {
        playerObj = GameObject.Find("PlayerObj(Clone)");
        player = playerObj.transform;
        if (Vector3.Distance(player.position, transform.position) <= meter)
        {
            isClose = true;
        }
     
    }
}
