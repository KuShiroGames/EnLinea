using System.Collections;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Runtime.CompilerServices;
public class PlayerTasks : MonoBehaviour
{
    [SerializeField] private bool taskOneDone, taskTwoDone, taskThreeDone;
    [SerializeField] private int taskOne, taskTwo, taskThree;
    [SerializeField] private TextMeshProUGUI textOne, textTwo, textThree;
    [SerializeField] GameObject Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine;
    [SerializeField] private float timer;
    public delegate void PTNotify();
    public static event PTNotify AllTaskDone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        Task.FDucks += FillDuck;
        Task.MDucks += MoldDucks;
        Task.PDucks += PressedDuck;
        Task.MBoxes += MoveBoxes;
        Task.Invent += Inventory;
        Task.HRmeet += HRMeeting;
        Task.ESheet += ExcelSheet;
        Task.TMolds += TakeMolds;
        Task.PaintD += PaintDucks;
        Task.QACheck += QA;
    }

    void OnDisable()
    {
        Task.FDucks -= FillDuck;
        Task.MDucks -= MoldDucks;
        Task.PDucks -= PressedDuck;
        Task.MBoxes -= MoveBoxes;
        Task.Invent -= Inventory;
        Task.HRmeet -= HRMeeting;
        Task.ESheet -= ExcelSheet;
        Task.TMolds -= TakeMolds;
        Task.PaintD -= PaintDucks;
        Task.QACheck -= QA;
    }
    void Start()
    {
        timer = 0;
        Zero = GameObject.Find("FillDuck");
        One = GameObject.Find("MoveDucks");
        Two = GameObject.Find("PressDucks");
        Three = GameObject.Find("MoveBoxes");
        Four = GameObject.Find("Inventory");
        Five = GameObject.Find("HRmeeting");
        Six = GameObject.Find("Excel");
        Seven = GameObject.Find("TakeTheModls");
        Eight = GameObject.Find("PaintDucks");
        Nine = GameObject.Find("QA");
        taskOneDone = false;
        taskTwoDone = false;
        taskThreeDone = false;
        taskOne = Random.Range(0, 10);
        taskTwo = Random.Range(0, 10);
        while (taskTwo == taskOne)
        {
            taskTwo = Random.Range(0, 10);
        }
        taskThree = Random.Range(0, 10);
        while (taskThree == taskOne || taskThree == taskTwo)
        {
            taskThree = Random.Range(0, 10);
        }
        Zero.SetActive(false);
        One.SetActive(false);
        Two.SetActive(false);
        Three.SetActive(false);
        Four.SetActive(false);
        Five.SetActive(false);
        Six.SetActive(false);
        Seven.SetActive(false);
        Eight.SetActive(false);
        Nine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (taskOne)
        {
            case 0:
                textOne.text = "Task One: Fill the molds of the Ducks";
                if (taskOneDone == false)
                {
                    Zero.SetActive(true);
                }
                break;
            case 1:
                textOne.text = "Task One: Move the Ducks to a Box";
                if (taskOneDone == false)
                {
                    One.SetActive(true);
                }
                break;
            case 2:
                textOne.text = "Task One: Pressshape the Ducks";
                if (taskOneDone == false)
                {
                    Two.SetActive(true);
                }
                break;
            case 3:
                textOne.text = "Task One: Move the Boxes to the Shelf";
                if (taskOneDone == false)
                {
                    Three.SetActive(true);
                }
                break;
            case 4:
                textOne.text = "Task One: Count the Inventory of the shelfs";
                if (taskOneDone == false)
                {
                    Four.SetActive(true);
                }
                break;
            case 5:
                textOne.text = "Task One: Have a meeting with HR";
                if (taskOneDone == false)
                {
                    Five.SetActive(true);
                }
                break;
            case 6:
                textOne.text = "Task One: Make an Excel Sheet";
                if (taskOneDone == false)
                {
                    Six.SetActive(true);
                }
                break;
            case 7:
                textOne.text = "Task One: Take The Molds and put it into the machine";
                if (taskOneDone == false)
                {
                    Seven.SetActive(true);
                }
                break;
            case 8:
                textOne.text = "Task One: Paint the Ducks";
                if (taskOneDone == false)
                {
                    Eight.SetActive(true);
                }
                break;
            case 9:
                textOne.text = "Task One: Quality Check the Ducks";
                if (taskOneDone == false)
                {
                    Nine.SetActive(true);
                }
                break;
        }
        switch (taskTwo)
        {
            case 0:
                textTwo.text = "Task One: Fill the molds of the Ducks";
                if (taskTwoDone == false)
                {
                    Zero.SetActive(true);
                }
                break;
            case 1:
                textTwo.text = "Task One: Move the Ducks to a Box";
                if (taskTwoDone == false)
                {
                    One.SetActive(true);
                }
                break;
            case 2:
                textTwo.text = "Task One: Pressshape the Ducks";
                if (taskTwoDone == false)
                {
                    Two.SetActive(true);
                }
                break;
            case 3:
                textTwo.text = "Task One: Move the Boxes to the Shelf";
                if (taskTwoDone == false)
                {
                    Three.SetActive(true);
                }
                break;
            case 4:
                textTwo.text = "Task One: Count the Inventory of the shelfs";
                if (taskTwoDone == false)
                {
                    Four.SetActive(true);
                }
                break;
            case 5:
                textTwo.text = "Task One: Have a meeting with HR";
                if (taskTwoDone == false)
                {
                    Five.SetActive(true);
                }
                break;
            case 6:
                textTwo.text = "Task One: Make an Excel Sheet";
                if (taskTwoDone == false)
                {
                    Six.SetActive(true);
                }
                break;
            case 7:
                textTwo.text = "Task One: Take The Molds and put it into the machine";
                if (taskTwoDone == false)
                {
                    Seven.SetActive(true);
                }
                break;
            case 8:
                textTwo.text = "Task One: Paint the Ducks";
                if (taskTwoDone == false)
                {
                    Eight.SetActive(true);
                }
                break;
            case 9:
                textTwo.text = "Task One: Quality Check the Ducks";
                if (taskTwoDone == false)
                {
                    Nine.SetActive(true);
                }
                break;
        }
        switch (taskThree)
        {
            case 0:
                textThree.text = "Task One: Fill the molds of the Ducks";
                if (taskThreeDone == false)
                {
                    Zero.SetActive(true);
                }
                break;
            case 1:
                textThree.text = "Task One: Move the Ducks to a Box";
                if (taskThreeDone == false)
                {
                    One.SetActive(true);
                }
                break;
            case 2:
                textThree.text = "Task One: Pressshape the Ducks";
                if (taskThreeDone == false)
                {
                    Two.SetActive(true);
                }
                break;
            case 3:
                textThree.text = "Task One: Move the Boxes to the Shelf";
                if (taskThreeDone == false)
                {
                    Three.SetActive(true);
                }
                break;
            case 4:
                textThree.text = "Task One: Count the Inventory of the shelfs";
                if (taskThreeDone == false)
                {
                    Four.SetActive(true);
                }
                break;
            case 5:
                textThree.text = "Task One: Have a meeting with HR";
                if (taskThreeDone == false)
                {
                    Five.SetActive(true);
                }
                break;
            case 6:
                textThree.text = "Task One: Make an Excel Sheet";
                if (taskThreeDone == false)
                {
                    Six.SetActive(true);
                }
                break;
            case 7:
                textThree.text = "Task One: Take The Molds and put it into the machine";
                if (taskThreeDone == false)
                {
                    Seven.SetActive(true);
                }
                break;
            case 8:
                textThree.text = "Task One: Paint the Ducks";
                if (taskThreeDone == false)
                {
                    Eight.SetActive(true);
                }
                break;
            case 9:
                textThree.text = "Task One: Quality Check the Ducks";
                if (taskThreeDone == false)
                {
                    Nine.SetActive(true);
                }
                break;
        }
        
    }

    void FixedUpdate()
    {
        if (taskOneDone == true && taskTwoDone == true && taskThreeDone == true)
        {
            if (timer < 0.05)
            {
                PhotonNetwork.LocalPlayer.AddScore(10);
                AllTaskDone.Invoke();
                timer += Time.deltaTime;
            }
            
                
            
        }
    }
    void FillDuck()
    {
        if (taskOne == 0)
        {
            taskOneDone = true;
        }
        if (taskTwo == 0)
        {
            taskTwoDone = true;
        }
        if (taskThree == 0)
        {
            taskThreeDone = true;
        }
    }
    void MoldDucks() {
        if (taskOne == 1)
        {
            taskOneDone = true;
        }
        if (taskTwo == 1)
        {
            taskTwoDone = true;
        }
        if (taskThree == 1)
        {
            taskThreeDone = true;
        }
    }
    void PressedDuck() {
        if (taskOne == 2)
        {
            taskOneDone = true;
        }
        if (taskTwo == 2)
        {
            taskTwoDone = true;
        }
        if (taskThree == 2)
        {
            taskThreeDone = true;
        }
    }
    void MoveBoxes() {
        if (taskOne == 3)
        {
            taskOneDone = true;
        }
        if (taskTwo == 3)
        {
            taskTwoDone = true;
        }
        if (taskThree == 3)
        {
            taskThreeDone = true;
        }
    }
    void Inventory() {
        if (taskOne == 4)
        {
            taskOneDone = true;
        }
        if (taskTwo == 4)
        {
            taskTwoDone = true;
        }
        if (taskThree == 4)
        {
            taskThreeDone = true;
        }
    }
    void HRMeeting() {
        if (taskOne == 5)
        {
            taskOneDone = true;
        }
        if (taskTwo == 5)
        {
            taskTwoDone = true;
        }
        if (taskThree == 5)
        {
            taskThreeDone = true;
        }
    }
    void ExcelSheet() {
        if (taskOne == 6)
        {
            taskOneDone = true;
        }
        if (taskTwo == 6)
        {
            taskTwoDone = true;
        }
        if (taskThree ==6)
        {
            taskThreeDone = true;
        }
    }
    void TakeMolds() {
        if (taskOne == 7)
        {
            taskOneDone = true;
        }
        if (taskTwo == 7)
        {
            taskTwoDone = true;
        }
        if (taskThree == 7)
        {
            taskThreeDone = true;
        }
    }
    void PaintDucks() {
        if (taskOne == 8)
        {
            taskOneDone = true;
        }
        if (taskTwo == 8)
        {
            taskTwoDone = true;
        }
        if (taskThree == 8)
        {
            taskThreeDone = true;
        }
    }
    void QA()
    {
        if (taskOne == 9)
        {
            taskOneDone = true;
        }
        if (taskTwo == 9)
        {
            taskTwoDone = true;
        }
        if (taskThree == 9)
        {
            taskThreeDone = true;
        }
    }
}
