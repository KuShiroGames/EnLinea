using System.Security;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public class StressMeter : MonoBehaviour
{
    [SerializeField] private Image stressBar;
    [SerializeField] private float streesMeter, stressTotal, timerPreventor;
    [SerializeField] private bool theGameStarted;

    public delegate void SMNotify();
    public static event SMNotify playerDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        PressE.TaskNoty += AddStress;
        PressE.NothingNoty += DoingNothing;
        GameStart.gameStart += GameHasStarted;
    }

    void OnDisable()
    {
        PressE.TaskNoty -= AddStress;
        PressE.NothingNoty -= DoingNothing;
        GameStart.gameStart -= GameHasStarted;
    }
    void Start()
    {
        streesMeter = 60;
        stressTotal = 120;
        theGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        stressBar.fillAmount = streesMeter / stressTotal;
        if (theGameStarted == true)
        {
            streesMeter -= Time.deltaTime;
            if (streesMeter > 120 || streesMeter <= 0)
            {
                playerDead.Invoke();
            }
        }

    }

    void AddStress()
    {
        if (timerPreventor < 0.0001)
        {
            timerPreventor += Time.deltaTime;
            streesMeter += 20;
        }

    }
    void DoingNothing()
    {
        timerPreventor = 0;
    }
    void GameHasStarted()
    {
        theGameStarted = true;
    }
}
