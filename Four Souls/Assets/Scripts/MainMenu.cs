using UnityEngine;
using UnityEngine.SceneManagement; //get the data sets for scenes

public class MainMenu : MonoBehaviour
{
    //Button Sound Effect

    public AudioSource PlayAudio;

    
    public void PlayGame() //method to start the gameplay  
    {
        PlayAudio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the next scene following the active one via scene index number
    }

    public void ShowCredits() //method to show the credits
    {
        PlayAudio.Play();
        SceneManager.LoadScene("Credits Menu"); //fixed scene name as it isnt likely to be changed
    }

    public void QuitGame() //method to quit the game
    {
        PlayAudio.Play();

        Application.Quit();
    }
    public void LoadMainMenu() // get back to main menu
    {
        PlayAudio.Play();
        SceneManager.LoadScene("Main Menu"); //fixed scene name as it isnt likely to be changed
    }

    
}
