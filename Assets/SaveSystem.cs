using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveCat(CatManager catManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string savePath = Application.persistentDataPath + "/CatManager.meow";
        FileStream stream = new FileStream(savePath, FileMode.Create);

        CatData catData = new CatData(catManager);

        formatter.Serialize(stream, catData);

        stream.Close();
    }
    public static void DeleteCat()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/CatManager.meow";

        File.Delete(savePath);
    }
    public static CatData LoadCat()
    {
        string savePath = Application.persistentDataPath + "/CatManager.meow";

        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);

            CatData catData = formatter.Deserialize(stream) as CatData;
            stream.Close();

            return catData;
        }
        else
        {
            Debug.LogError("Save file not found at " + savePath);
            return null;
        }
    }
}
