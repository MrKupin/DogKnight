using UnityEngine;

public abstract class SaveSystem : ScriptableObject
{
    public abstract void Save<T>(string fileName, T data);
    public abstract T Object<T>(string fileName) where T : new();
    public abstract void DeleteSave(string fileName);
}
