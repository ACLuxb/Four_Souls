using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu; //reference the Panel which acts as the Pause Menu overlay
    public bool isPaused;   //create bool to check if game is paused
    public Save_LoadGameData saveGameData;

   void Start ()            
    {
        
        pauseMenu.SetActive(false);     //set the panel to inactive at the start
    }

    void Update()           
    {
        if (Input.GetKeyDown(KeyCode.Escape))       //do this if esc key is pressed    
        {
            if (isPaused)
            {
                ResumeGame();       //if game was paused resume game
            }

            else
            {
                PauseGame();        //if game was running pause game
            }
        }
    }

    public void PauseGame ()
    {
        pauseMenu.SetActive(true);  //shows the panel
        Time.timeScale = 0f;        //stop time ingame
        isPaused = true;            //correct the bool to show that the game is paused

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); //closes the panel
        Time.timeScale = 1f;        //resume ingame time normally
        isPaused = false;           //correct the bool to show that the game is NOT paused

    }

    public void BacktoMain() 
    { 
        Time.timeScale = 1f;                    //resume ingame time normally
        //Save_LoadGameData save = GameObject.Find("GameSystem").GetComponent<Save_LoadGameData>();
        //save.SaveGameData();
        SceneManager.LoadScene("Main Menu");    //Load Main Menu
    }

    public void QuitGame ()
    {
       Application.Quit();      //yeet 
    }



    // created with the help of this tutorial: https://www.youtube.com/watch?v=9dYDBomQpBQ
}
