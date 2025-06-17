using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletSpeed = 10f;
    public delegate void PNotify();
    public static event PNotify dontHavePistol;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Fire();
            gameObject.SetActive(false);
            dontHavePistol.Invoke();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = bullet.AddComponent<Rigidbody>();
        }

        rb.AddForce(bulletSpawn.right * bulletSpeed, ForceMode.Impulse);
    }
}
