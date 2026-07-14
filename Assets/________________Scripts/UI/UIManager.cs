using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Oscilation UI Settings")]
    [SerializeField] private GameObject _OscilationUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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

}
