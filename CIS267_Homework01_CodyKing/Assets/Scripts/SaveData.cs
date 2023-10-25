using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using UnityEditor.Build.Player;

public static class SaveData
{
    public static void saveScore(int score)
    {
        if (score > loadScore())
        {
            string path = Application.persistentDataPath + "/hiddenPlayerScore.sc";

            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Create);

            bf.Serialize(stream, score);

            stream.Close();
        }
    }

    public static int loadScore()
    {
        string path = Application.persistentDataPath + "/hiddenPlayerScore.sc";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            int score = (int)bf.Deserialize(stream);

            stream.Close();

            return score;
        }
        else
        {
            Debug.LogError("File missing in " + path);
            return -99;
        }
    }
}
