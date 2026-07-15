using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private string _savePath;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _savePath = Application.persistentDataPath + "save.json";
    }

    private void Start()
    {
        LoadGame();
    }

    // Save
    public void SaveGame()
    {
        SaveData data = new SaveData();

        // Currency
        data.money = CurrencyManager.Instance.CurrentMoney;

        // Future systems
        // data.kickForceLevel = UpgradeManager.Instance.KickForceLevel;
        // data.selectedBallSkin = SkinManager.Instance.SelectedSkin;
        // data.highestDistance = DistanceManager.Instance.HighestDistance;

        string _json = JsonUtility.ToJson(data, true);

        File.WriteAllText(_savePath, _json);

        Debug.Log("Game Saved\n" + _savePath);
    }

    // Load
    public void LoadGame()
    {
        if(!File.Exists(_savePath))
        {
            Debug.Log("No save file found.");
            return;
        }

        string _json = File.ReadAllText(_savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(_json);

        // Currency
        CurrencyManager.Instance.SetMoney(data.money);

        // Future systems
        // UpgradeManager.Instance.SetKickForceLevel(data.kickForceLevel);
        // SkinManager.Instance.SetSelectedSkin(data.selectedBallSkin);
        // DistanceManager.Instance.SetHighestDistance(data.highestDistance);

        Debug.Log("Game Loaded\n" + _savePath);
    }
}
