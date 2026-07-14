using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Oscilation UI Settings")]
    [SerializeField] private GameObject _OscilationUI;

    [Header("Reset UI Settings")]
    [SerializeField] private GameObject _resetUI;

    [Header("Projectile Distance UI")]
    [SerializeField] private TMP_Text _distanceText;

    [Header("Currency UI")]
    [SerializeField] private TMP_Text _moneyText;

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
            _moneyText.text = $"Money: {amount}";
        }
    }
    #endregion


}
