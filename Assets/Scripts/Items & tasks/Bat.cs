using Photon.Pun;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public delegate void BNotify();
    public static event BNotify dontHaveBat;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            dontHaveBat.Invoke();
            
        }
    }
}
