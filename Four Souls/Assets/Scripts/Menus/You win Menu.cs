using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.IO;
using UnityEngine.UI;


public class YouWin : MonoBehaviour
{

    public GameObject youwinmenu; //reference the Panel which acts as the You Win overlay

    public static event Action OnBossDeath;

  //  public void Update() 
    //{ 
      //  Enemy boss= GameObject.Find("boss").GetComponent<Enemy>(); //get the boss' current health
        
       // if ( boss.health <=0 )
      //  {
        //    OnBossDeath!.Invoke(); //event starts of boss is dead
      //  }
    //}

    private void OnEnable()
    {
        OnBossDeath += EnableYouWinMenu;     //subscribing to the event that triggers when player got murked
    }

    public void OnDisable()
    {
        Player.OnPlayerDeath -= EnableYouWinMenu; // just to make sure onEnable works properly
    }

    public void EnableYouWinMenu()
    {
       youwinmenu.SetActive(true);
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
