using UnityEngine;
using System.Linq;
using Photon.Pun;
using TMPro;
using Photon.Pun.UtilityScripts;

public class GameManager : MonoBehaviour
{
    public GameObject playerHolder, exit;

    [Header("Options")]
    public float refreshRate = 1f;
    [Header("UI")]
    public GameObject[] slots;
    public TextMeshProUGUI[] scoreText, nameText;
    public bool gameDed = false;


    void OnEnable()
    {
        GameStart.gameEnded += RoundEnded;
    }

    void OnDisable()
    {
        GameStart.gameEnded -= RoundEnded;
    }
    void RoundEnded()
    {
        gameDed = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Refresh), 1f, refreshRate);
    }

    public void Refresh()
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);
        }

        var sortedPlayersList = (from player in PhotonNetwork.PlayerList orderby player.GetScore() descending select player).ToList();

        int i = 0;
        foreach (var player in sortedPlayersList)
        {
            slots[i].SetActive(true);
            if (player.NickName == "")
            {
                player.NickName = "Nobody";
            }
            nameText[i].text = player.NickName;
            scoreText[i].text = player.GetScore().ToString();
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gameDed == false)
        {
            playerHolder.SetActive(Input.GetKey(KeyCode.Tab));
        }
        else
        {
            playerHolder.SetActive(true);
            exit.SetActive(true);
        }
        

        
    }

}
