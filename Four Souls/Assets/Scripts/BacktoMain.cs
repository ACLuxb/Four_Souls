using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMain : MonoBehaviour
{
   public void LoadMainMenu ()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
