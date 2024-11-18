using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuToPlay : MonoBehaviour
{
    public GameObject howtoPlayScreen;
    [SerializeField]
    private float WaitTime;

    public void Onplay()
    { 
        howtoPlayScreen.SetActive(true);
    }
    public void ToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
 