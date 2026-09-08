using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CashCalculatorManager : MonoBehaviour
{
    [SerializeField] private TMP_Text totalText;
    [SerializeField] private TMP_Text limitText;
    [SerializeField] private Button resetButton;
    [SerializeField] private long limitAmount = 300000;

    private MoneyRow[] moneyRows;

    private void Start()
    {
        moneyRows = FindObjectsByType<MoneyRow>(FindObjectsSortMode.None);

        foreach (MoneyRow row in moneyRows)
        {
            row.AmountChanged += UpdateTotal;
        }

        resetButton.onClick.AddListener(ResetAll);

        UpdateTotal();
    }

    private void UpdateTotal()
    {
        long total = 0;

        foreach (MoneyRow row in moneyRows)
        {
            total += row.Subtotal;
        }

        totalText.text = $"Total : {total:N0} KRW";

        if (total >= limitAmount)
        {
            long excess = total - limitAmount;

            limitText.gameObject.SetActive(true);
            limitText.text =
                $"Over 300,000 KRW!  Excess : {excess:N0} KRW";
        }
        else
        {
            limitText.gameObject.SetActive(false);
        }
    }

    private void ResetAll()
    {
        foreach (MoneyRow row in moneyRows)
        {
            row.ResetCount();
        }

        UpdateTotal();
    }

    private void OnDestroy()
    {
        if (moneyRows != null)
        {
            foreach (MoneyRow row in moneyRows)
            {
                row.AmountChanged -= UpdateTotal;
            }
        }

        if (resetButton != null)
        {
            resetButton.onClick.RemoveListener(ResetAll);
        }
    }
}