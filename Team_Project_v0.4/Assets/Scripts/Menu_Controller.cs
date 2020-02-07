using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        loadGame();
    }

    // Update is called once per frame
    void Update()
    {
        loadGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /////////////////////////////////
    //        Menu Navigator       //
    /////////////////////////////////

    // Menu Screens
    public GameObject startScreen;
    public GameObject aboutScreen;
    public GameObject quitScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    void loadGame()
    {
        startScreen.gameObject.SetActive(true);
        aboutScreen.gameObject.SetActive(false);
        quitScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
    }

    void aboutMenu()
    {
        startScreen.gameObject.SetActive(false);
        aboutScreen.gameObject.SetActive(true);
        quitScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
    }

    void quitGame()
    {
        startScreen.gameObject.SetActive(false);
        aboutScreen.gameObject.SetActive(false);
        quitScreen.gameObject.SetActive(true);
        winScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
    }

    void winGame()
    {
        startScreen.gameObject.SetActive(false);
        aboutScreen.gameObject.SetActive(false);
        quitScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(true);
        loseScreen.gameObject.SetActive(false);
    }

    void loseGame()
    {
        startScreen.gameObject.SetActive(false);
        aboutScreen.gameObject.SetActive(false);
        quitScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(true);
    }
}
