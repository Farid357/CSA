using UnityEngine;

public sealed class PointStatesData : MonoBehaviour
{
    private const string Key = "StatesData";

    public void Save(PointStates pointStates)
    {
        PlayerPrefs.SetString(Key, pointStates.ToString());
    }
    public string Load()
    {
        if(PlayerPrefs.HasKey(Key))
        {
            return PlayerPrefs.GetString(Key);
        }
        return null;
    }
    
}
