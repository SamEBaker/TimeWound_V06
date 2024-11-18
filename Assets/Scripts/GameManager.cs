using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public static class GameData
{
    public static int FinalGold;
}
public class GameManager : MonoBehaviour
{
    public int TotalGold = 0;
    public int totalPlayers = 0;
    public int totalReady = 0;
    public UnityEvent startGame;
    public GameObject startgamebutton;
    public List<GameObject> PlayerUISetUp;
    public bool[] PlayerReady;
    public List<TMP_Text> TextReady;
    public Timer t;
    public GameObject DefaultCam;
    public GameObject ThirdFiller;
    public GameObject WinDisplay;
    public TMP_Text WinText;

    public void Start()
    {
          bool[] PlayerReady = new bool[3];
    }

    public void TotalAddGold(int gold)
    {
        TotalGold += gold;
    }
    public void SpendGold(int gold)
    {
        if(TotalGold != 0)
        {
            TotalGold -= gold;
            //lower door
        }

    }
    public void SetupUI(int index)
    {
        PlayerUISetUp[index - 1].SetActive(true);
    }
    public void AddPlayer()
    {
        if (totalPlayers == 3)
        {
            ThirdFiller.SetActive(false);
        }
        if (totalPlayers == 2)
        {
            ThirdFiller.SetActive(true);
        }
        if (totalPlayers == 0)
        {
            DefaultCam.SetActive(false);
            //enable startgame button for 1st player
            startgamebutton.SetActive(true);
        }
        totalPlayers++;


        //SetupUI(totalPlayers);
    }
    public void ReadyUp(int index)
    {

        PlayerReady[index] = !PlayerReady[index];
        if (PlayerReady[index] == true)
        {
            TextReady[index].text = "READY!";
            totalReady++;
        }
        else if (PlayerReady[index] == false)
        {
            TextReady[index].text = "Ready?";
            totalReady--;
        }

    }

    public void StartGame()
    {
        if (totalReady >= totalPlayers)
        {
            //startGame.Invoke();
            t.IsRunning = true;
            for (int i = 0; i <= 3; i++)
            {
                PlayerUISetUp[i].SetActive(false);
            }
        }

            //start game and timer
            //StartGameMenu.SetActive(false);
            //threeplayerFillerUI.SetActive(true);
            //startGame.Invoke();

    }

    public void EndGame()
    {
        t.IsRunning = false;
        WinDisplay.SetActive(true);
        WinText.text = "You Found " + TotalGold + " Gold!";
        GameData.FinalGold = TotalGold;
    }
    public void EndGameDied()
    {
        t.IsRunning = false;
        WinDisplay.SetActive(true);
        WinText.text = "You all died";
        GameData.FinalGold = TotalGold;
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
