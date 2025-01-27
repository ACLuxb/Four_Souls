using UnityEngine;

public class Save_LoadGameData : MonoBehaviour
{
    private void Start()
    {
        
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.LoadGameData();

        CamController camera = GameObject.Find("Main Camera").GetComponent<CamController>();
        camera.LoadGameData();

    }

    public void SaveGameData()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        CamController camera = GameObject.Find("Main Camera").GetComponent<CamController>();
        
        SaveSystem.SaveGame(player, camera);
    }
}
