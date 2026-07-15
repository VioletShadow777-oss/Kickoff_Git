using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    [Header("Currency Settings")]
    [SerializeField] private int startingMoney = 0;

    // Current amount of money the player owns
    public int CurrentMoney { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        CurrentMoney = startingMoney;
    }

    /// <summary>
    /// Adds money to the player's balance.
    /// </summary>
    public void AddMoney(int amount)
    {
        if (amount <= 0)
            return;

        CurrentMoney += amount;

        Debug.Log($"Money Added: +{amount} | Total: {CurrentMoney}");

        // Notify UI
        UIManager.Instance.UpdateMoney(CurrentMoney);

        // Save the game after adding money
        SaveManager.Instance.SaveGame();
    }

    /// <summary>
    /// Tries to spend money.
    /// Returns true if successful.
    /// </summary>
    public bool SpendMoney(int amount)
    {
        if (amount <= 0)
            return false;

        if (CurrentMoney < amount)
        {
            Debug.Log("Not enough money.");
            return false;
        }

        CurrentMoney -= amount;

        Debug.Log($"Money Spent: -{amount} | Total: {CurrentMoney}");

        // Notify UI
        UIManager.Instance.UpdateMoney(CurrentMoney);

        // Save the game after spending money
        SaveManager.Instance.SaveGame();

        return true;
    }

    /// <summary>
    /// Returns true if the player can afford the amount.
    /// </summary>
    public bool CanAfford(int amount)
    {
        return CurrentMoney >= amount;
    }

    public void SetMoney(int amount)
    {
        CurrentMoney = amount;

        UIManager.Instance.UpdateMoney(CurrentMoney);
    }
}