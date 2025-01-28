using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameovermenu; //reference the Panel which acts as the Game Over overlay

    private void OnEnable()
    {
        Player.OnPlayerDeath += EnableGameOverMenu;     //subscribing to the event that triggers when player got murked
    }

    public void OnDisable()
    {
        Player.OnPlayerDeath -= EnableGameOverMenu; // just to make sure onEnable works properly
    }

    public void EnableGameOverMenu()
    {
       gameovermenu.SetActive(true);
    }



    public void Retry() //restart the game scene, we didn't get the safepoint to work
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BacktoMain() 
    { 
        SceneManager.LoadScene("Main Menu");    //Load Main Menu
    }

    public void QuitGame ()
    {
       Application.Quit();      //yeetusexitus
    }



    // created with the help of this tutorial: https://www.youtube.com/watch?v=9dYDBomQpBQ
}
