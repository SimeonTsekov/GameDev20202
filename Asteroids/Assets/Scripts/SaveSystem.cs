using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem  
{

    public static void SavePlayer(GameStateController controller)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "player.bin");

        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(controller);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveSettings(SettingsController controller)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "settings.bin");

        FileStream stream = new FileStream(path, FileMode.Create);
        SettingsData data = new SettingsData(controller);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.bin");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return playerData;
        }
        else
        {
            return null;
        }
    }

    public static SettingsData LoadSettings()
    {
        string path = Path.Combine(Application.persistentDataPath, "settings.bin");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SettingsData settingsData = formatter.Deserialize(stream) as SettingsData;
            stream.Close();

            return settingsData;
        }
        else
        {
            return null;
        }
    }

    public static void RazeData()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.bin");
        if (File.Exists(path))
        {
            File.Delete(path);
            Application.Quit();
        }
    }
}
