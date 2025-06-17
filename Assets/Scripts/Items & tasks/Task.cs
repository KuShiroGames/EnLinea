using System.Collections;
using UnityEngine;

public class Task : Distance
{
    public enum PlayTasks {FillDuck,MoveDucks,PressDucks,MoveBoxes,Inventory,HRmeeting,ExcelSheet,TakeTheMolds,PaintDucks,QualityCheck}
    public PlayTasks playTasks;
    public delegate void PlayTaskNotify();
    public static event PlayTaskNotify FDucks,MDucks,PDucks,MBoxes,Invent,HRmeet,ESheet,TMolds,PaintD,QACheck;
    
    void OnEnable()
    {
        PressE.TaskNoty += DoTask;
    }

    void OnDisable()
    {
        PressE.TaskNoty -= DoTask;
    }

    void DoTask()
    {
        switch (playTasks)
        {
            case PlayTasks.FillDuck:
            if(isClose == true)
            {
                FDucks.Invoke();
                gameObject.SetActive(false);
            }
            break;
            case PlayTasks.MoveDucks:
            if(isClose == true)
            {
                MDucks.Invoke();
                gameObject.SetActive(false);
            }
            break;
            case PlayTasks.PressDucks:
            if(isClose == true)
            {
                PDucks.Invoke();
                gameObject.SetActive(false);
            }
            break;
            case PlayTasks.MoveBoxes:
            if(isClose == true)
            {
                MBoxes.Invoke();
                gameObject.SetActive(false);
            }
            break;
            case PlayTasks.Inventory:
            if(isClose == true)
            {
                Invent.Invoke();
                gameObject.SetActive(false);
            }
            break;
            case PlayTasks.HRmeeting:
            if(isClose == true)
            {
                HRmeet.Invoke();
                gameObject.SetActive(false);
            }
            break;
            case PlayTasks.ExcelSheet:
            if(isClose == true)
            {
                ESheet.Invoke();
                gameObject.SetActive(false);
            }
            break;
            case PlayTasks.TakeTheMolds:
            if(isClose == true)
            {
                TMolds.Invoke();
                gameObject.SetActive(false);
            }
            break;
            case PlayTasks.PaintDucks:
            if(isClose == true)
            {
                PaintD.Invoke();
                gameObject.SetActive(false);
            }
            break;
            case PlayTasks.QualityCheck:
            if(isClose == true)
            {
                QACheck.Invoke();
                gameObject.SetActive(false);
            }
            break;
        }
        
    }
}
