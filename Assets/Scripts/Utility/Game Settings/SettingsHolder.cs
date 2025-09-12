using UnityEngine;

public class SettingsHolder
{
    public SettingsData Data { get; private set; }

    // Initialize settings with default values. //
    public SettingsHolder()
    {
        Data = new SettingsData();
    }

    // When the settings are updated, call this method. //
    public void Apply(SettingsData newData) 
    {
        Data = newData;
    }

    // For reading & writing settings in JSON. //
    public string ToJson() => JsonUtility.ToJson(Data);
    public void FromJson(string json) => Data = JsonUtility.FromJson<SettingsData>(json);
}
