using System;
using UnityEngine;
using UnityEngine.UI;

public class PressE : MonoBehaviour
{
    [SerializeField] private Image charging;
    [SerializeField] private float time, totalTime;
    [SerializeField] private bool isCollidingTask, isCollidingPickUp;

    public delegate void PressENotify();
    public static event PressENotify TaskNoty, PickUpNotify, NothingNoty;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCollidingTask = false;
        isCollidingPickUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        charging.fillAmount = time / totalTime;
        if (isCollidingTask == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                time += Time.deltaTime;
                if (time >= totalTime)
                {
                    TaskNoty.Invoke();
                    isCollidingTask = false;
                    
                }
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                time = 0;
                NothingNoty.Invoke();
            }
        }
        if (isCollidingTask == false)
        {
            time = 0;
        }
        if (isCollidingPickUp == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isCollidingPickUp = false;
                PickUpNotify.Invoke();
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Task"))
        {
            isCollidingTask = true;
        }
        if (other.gameObject.CompareTag("PickUp"))
        {
            isCollidingPickUp = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Task"))
        {
            isCollidingTask = false;
        }
        if (other.gameObject.CompareTag("PickUp"))
        {
            isCollidingPickUp = false;
        }
    }
}
