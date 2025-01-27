using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq.Expressions;

public class SaveSystem : MonoBehaviour
{
    public static void SaveGame (Player player, CamController camera)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(player, camera);

        Debug.Log("Saved Game");

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame ()
    {
        string path = Application.persistentDataPath + "/player.save";
        try
        {
            BinaryFormatter formatter = new BinaryFormatter ();
            FileStream stream = new FileStream (path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            
            stream.Close();

            Debug.Log("Loaded Game");

            return data;
        }
        catch (FileNotFoundException)
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
