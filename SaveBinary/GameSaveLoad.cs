using UnityEngine;
using System.IO; //to work with files
using System.Runtime.Serialization.Formatters.Binary; //

public static class GameSaveLoad
{
    public static void Save(int nMatch, ExamplePlayer player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game" + nMatch + ".fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static GameData Load(int nMatch)
    {
        string path = Application.persistentDataPath + "/game" + nMatch + ".fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }    
}
