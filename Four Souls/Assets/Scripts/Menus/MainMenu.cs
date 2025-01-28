using UnityEngine;
using UnityEngine.SceneManagement; //get the data sets for scenes
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    // public AudioSource ButtonClick;      didnt work, kept for reference
    public Save_LoadGameData loadData;

    public void PlayGame() //method to start the gameplay  
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the next scene following the active one via scene index number
    }

    public void ShowCredits() //method to show the credits
    {       
        SceneManager.LoadScene("Credits Menu"); //fixed scene name as it isnt likely to be changed
    }

    public void QuitGame() //method to quit the game
    {      
        Application.Quit();
    }
    public void LoadMainMenu() // get back to main menu
    {
        SceneManager.LoadScene("Main Menu"); //fixed scene name as it isnt likely to be changed
    }

    //public void PlayButtonSound() //didnt work, kept for reference
    //{
    //ButtonClick.Play();
    //}
}
