using UnityEngine;
using Photon.Pun;
public class bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);

    }
}
