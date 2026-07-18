using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    [Header("Upgrade Data")]
    [SerializeField] private KickForceUpgradeData kickForceData;

    [Header("Upgrade UI")]
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Image buttonImage;

    [SerializeField] private Sprite availableSprite;
    [SerializeField] private Sprite unavailableSprite;

    [Header("Current Upgrade")]
    [SerializeField] private int currentKickForceLevel = 0;

    public int CurrentKickForceLevel => currentKickForceLevel;

    public float CurrentKickForce =>
        kickForceData.levels[currentKickForceLevel].kickForce;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        RefreshUpgradeUI();
    }

    //------------------------------------------------

    public void BuyKickForceUpgrade()
    {
        if (!CanUpgrade())
        {
            SoundManager.instance.CannotUpgradeSound();
            return;
        }

        int price = GetNextUpgrade().price;

        if (!CurrencyManager.Instance.SpendMoney(price))
        {
            SoundManager.instance.CannotUpgradeSound();
            return;
        }

        currentKickForceLevel++;

        RefreshUpgradeUI();

        SaveManager.Instance.SaveGame();

        // Show upgrade Effect
        EffectsManager.Instance.BallUpgradeAndChangeEffect();
        SoundManager.instance.PlayUpgradeSound();
    }

    //------------------------------------------------

    public bool CanUpgrade()
    {
        if (currentKickForceLevel >= kickForceData.levels.Length - 1)
            return false;

        return CurrencyManager.Instance.CanAfford(GetNextUpgrade().price);
    }

    //------------------------------------------------

    public UpgradeLevel GetCurrentUpgrade()
    {
        return kickForceData.levels[currentKickForceLevel];
    }

    //------------------------------------------------

    public UpgradeLevel GetNextUpgrade()
    {
        if (currentKickForceLevel >= kickForceData.levels.Length - 1)
            return null;

        return kickForceData.levels[currentKickForceLevel + 1];
    }

    //------------------------------------------------

    public void RefreshUpgradeUI()
    {
        UIManager.Instance.UpdateUpgradeUI(
            CanUpgrade(),
            GetNextUpgrade()
        );
    }

    //------------------------------------------------

    public void SetCurrentLevel(int level)
    {
        currentKickForceLevel = level;
    }
}