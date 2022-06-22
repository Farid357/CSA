using UnityEngine;

public sealed class LevelNameData
{
    private const string Key = "SceneName";
    private const string KeyLevelIndex = "LevelIndex";
    public void SetName(string name)
    {
        PlayerPrefs.SetString(Key, name);
    }
    public string GetName()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            return PlayerPrefs.GetString(Key);
        }
        return null;
    }
    public void SetLevelIndex(int index)
    {
        PlayerPrefs.SetInt(KeyLevelIndex, index);
    }
    public int GetLevelIndex()
    {
        if(PlayerPrefs.HasKey(KeyLevelIndex))
        {
            return PlayerPrefs.GetInt(KeyLevelIndex);
        }
        return 0;
    }
}
