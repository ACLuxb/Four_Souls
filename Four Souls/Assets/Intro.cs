using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public void MainMenu() 
        {
        SceneManager.LoadSceneAsync(1);
        }
}
