using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void Save(){
        BinaryFormatter formatter=new BinaryFormatter();
        string path=Application.persistentDataPath+"/gamedata";
        FileStream stream=new FileStream(path,FileMode.Create);

        PlayerData data=new PlayerData();
        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static PlayerData Load(){
        string path=Application.persistentDataPath+"/gamedata";
        if(File.Exists(path)){
            BinaryFormatter formatter=new BinaryFormatter();
            FileStream stream=new FileStream(path,FileMode.Open);

            PlayerData data=formatter.Deserialize(stream) as PlayerData;
            return data;
        }
        else{
            Debug.LogError("There is no Save file"+path);
            return null;
        }
    }
}
