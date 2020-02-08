using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("escape"))
        {
            QuitGame();
        }

        /*if (Input.GetButtonDown("space"))
        {
            StartGame();
        }*/
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public GameObject aboutScreen;
    public GameObject mainMenu;
    
    public void ShowAboutScreen()
    {
        aboutScreen.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    public void HideAboutScreen()
    {
        aboutScreen.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Application closed");
        Application.Quit();
    }
}
