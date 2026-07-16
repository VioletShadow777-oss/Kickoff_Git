using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Oscilation UI Settings")]
    [SerializeField] private GameObject _OscilationUI;

    [Header("Reset UI Settings")]
    [SerializeField] private GameObject _resetUI;

    [Header("UI to hide while projectile is in motion")]
    [SerializeField] private GameObject[] _hiddens;

    [Header("Projectile Distance UI")]
    [SerializeField] private TMP_Text _distanceText;

    [Header("Currency UI")]
    [SerializeField] private TMP_Text _moneyText;

    [Header("Upgrade Settings")]
    [SerializeField] private Image upgradeButtonImage;

    [SerializeField] private TMP_Text priceText;

    [SerializeField] private Sprite availableSprite;

    [SerializeField] private Sprite unavailableSprite;

    [Header("Menu UI Settings")]
    [SerializeField] private Animator _menuAnimator;
    private bool _isMenuAppeared = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _resetUI.SetActive(false);
    }

    public void HideUIWhileProjectileInMotion()
    {
        foreach (var ui in _hiddens)
        {
            if (ui != null)
                ui.SetActive(false);
        }
    }
    public void ShowUIAfterProjectileStopped()
    {
        foreach (var ui in _hiddens)
        {
            if (ui != null)
                ui.SetActive(true);
        }
    }

    #region Oscilation UI Methods
    public void ShowOscilationUI()
    {
        if (_OscilationUI != null)
        {
            _OscilationUI.SetActive(true);
        }
    }
    public void HideOscilationUI()
    {
        if (_OscilationUI != null)
        {
            _OscilationUI.SetActive(false);
        }
    }
    #endregion

    #region Projectile Distance UI Methods
    public void ShowDistanceText(float distance)
    {
        if (_distanceText != null)
        {
            _distanceText.text = $"{distance:F0} m";
        }
    }
    #endregion

    #region Reset UI Methods
    public void ShowResetUI()
    {
        if (_resetUI != null)
        {
            _resetUI.SetActive(true);
        }
    }
    public void HideResetUI()
    {
        if (_resetUI != null)
        {
            _resetUI.SetActive(false);
        }
    }
    #endregion

    #region Currency UI Methods
    public void UpdateMoney(int amount)
    {
        if (_moneyText != null)
        {
            _moneyText.text = amount.ToString();
        }
    }
    #endregion

    #region Upgrade UI Methods
    public void UpdateUpgradeUI(bool canUpgrade, UpgradeLevel nextUpgrade)
    {
        if (nextUpgrade == null)
        {
            priceText.text = "MAX";

            upgradeButtonImage.sprite = unavailableSprite;

            return;
        }

        priceText.text = nextUpgrade.price.ToString();

        upgradeButtonImage.sprite =
            canUpgrade ? availableSprite
                       : unavailableSprite;
    }
    #endregion

    #region Menu UI Methods
    public void ToggleMenu()
    {
        if(_isMenuAppeared == false)
        {
            _menuAnimator.SetBool("menu_b", true);
            _isMenuAppeared = true;
        }
        else
        {
            _menuAnimator.SetBool("menu_b", false);
            _isMenuAppeared = false;
        }
    }
    #endregion

}
