using UnityEngine;

public class buttonmanager : MonoBehaviour
{
    public GameObject menu, lobbys;

    public void ChangeToLobby()
    {
        menu.SetActive(false);
        lobbys.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
