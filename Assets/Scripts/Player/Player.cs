using NUnit.Framework.Constraints;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PlayerVarious")]
    Vector3 playerV3;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private Camera playerCam;
    [SerializeField] private bool canJump = false, isJumping = false, isKnockout = false, isDead = false, gameEnd = false;
    [SerializeField] private GameObject pressE, youDead;
    [Header("PlayerStats")]
    [SerializeField] private float playerSpeed = 5f, force = 100f, knockTime;

    void OnEnable()
    {
        PressE.PickUpNotify += PressEDeactivateItem;
        PressE.TaskNoty += PressEDeactivate;
        StressMeter.playerDead += IsDead;
        GameStart.gameEnded += GameEnd;
    }
    void OnDisable()
    {
        PressE.PickUpNotify -= PressEDeactivateItem;
        PressE.TaskNoty -= PressEDeactivate;
        StressMeter.playerDead -= IsDead;
        GameStart.gameEnded -= GameEnd;
    }

    void PressEDeactivate()
    {
        pressE.SetActive(false);
        
    }
    void PressEDeactivateItem()
    {
       pressE.SetActive(false);
    }
    void GameEnd() {
        gameEnd = true;
    }
    void Start()
    {
        playerCollider = GetComponent<Collider>();
        playerRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        pressE.SetActive(false);
    }

    void Update()
    {
        if (gameEnd == false)
        {
            if (isDead == false)
            {
                youDead.SetActive(false);
                if (isKnockout == false)
                {
                    playerV3 = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                    transform.Translate(playerSpeed * playerV3.normalized * Time.deltaTime);
                    if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
                    {
                        isJumping = true;
                    }
                    if (canJump == false)
                    {
                        isJumping = false;
                    }
                    knockTime = 0;
                }
                if (isKnockout == true)
                {
                    knockTime += Time.deltaTime;
                    if (knockTime >= 5)
                    {
                        isKnockout = false;
                    }
                }
            }
            if (isDead == true)
            {
                youDead.SetActive(true);
            }

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
       

    }


    private void LateUpdate()
    {
        if (isKnockout == false)
        {
            transform.Rotate(0, Input.GetAxisRaw("Mouse X"), 0);
            playerCam.transform.Rotate(-Input.GetAxisRaw("Mouse Y"), 0, 0);
        }

    }
    private void FixedUpdate()
    {
        canJump = Physics.Raycast(transform.position, Vector3.down, 1.5f);
        if (isJumping == true)
        {
            playerRB.linearVelocity = Vector3.up * force;
            canJump = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Task"))
        {
            pressE.SetActive(true);
        }
        if (other.gameObject.CompareTag("PickUp"))
        {
            pressE.SetActive(true);
        }
        if (other.gameObject.CompareTag("Bat") && isKnockout == false)
        {
            gameObject.GetComponent<PhotonView>().RPC("IsKnockOut", RpcTarget.All, true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet") && isKnockout == false)
        {
            gameObject.GetComponent<PhotonView>().RPC("IsKnockOut", RpcTarget.All, true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Task"))
        {
            pressE.SetActive(false);
        }
        if (other.gameObject.CompareTag("PickUp"))
        {
            pressE.SetActive(false);
        }
    }

    void IsDead()
    {
        isDead = true;
    }

    [PunRPC]
    public void IsKnockOut(bool _isKnock)
    {
        isKnockout = _isKnock;
    }
}
