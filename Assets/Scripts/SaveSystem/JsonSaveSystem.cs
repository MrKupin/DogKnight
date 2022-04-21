using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "JsonSaveSystem")]
public class JsonSaveSystem : SaveSystem
{
    [SerializeField] private string _mainFolder;
    public override void Save<T>(string fileName, T data)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        string contents = JsonUtility.ToJson(data);
        File.WriteAllText(path, contents);
    }

    public override T Object<T>(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }
        return new T();
    }

    public override void DeleteSave(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
