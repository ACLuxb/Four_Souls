using UnityEngine;
using UnityEngine.SceneManagement; //get the data sets for scenes

public class MainMenu : MonoBehaviour
{
    public void PlayGame() //method to start the gameplay  
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the next scene following the active one via scene index number
    }

    public void ShowCredits() //method to show the credits
    {
        SceneManager.LoadScene("Credits Menu"); //Load the scene with the credits
    }

    public void QuitGame() //method to quit the game
    {
       Application.Quit();
    }


}
