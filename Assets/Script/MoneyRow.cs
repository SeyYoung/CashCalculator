using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyRow : MonoBehaviour
{
    [SerializeField] private int denomination;

    private TMP_InputField countInput;
    private Button minusButton;
    private Button plusButton;

    public event Action AmountChanged;

    public int Count
    {
        get
        {
            if (int.TryParse(countInput.text, out int count))
            {
                return Mathf.Max(0, count);
            }

            return 0;
        }
    }

    public long Subtotal => (long)denomination * Count;

    private void Awake()
    {
        countInput = transform.Find("CountInput").GetComponent<TMP_InputField>();
        minusButton = transform.Find("MinusButton").GetComponent<Button>();
        plusButton = transform.Find("PlusButton").GetComponent<Button>();

        minusButton.onClick.AddListener(Decrease);
        plusButton.onClick.AddListener(Increase);
        countInput.onValueChanged.AddListener(OnInputChanged);

        SetCount(0);
    }

    private void Increase()
    {
        SetCount(Count + 1);
        AmountChanged?.Invoke();
    }

    private void Decrease()
    {
        SetCount(Mathf.Max(0, Count - 1));
        AmountChanged?.Invoke();
    }

    private void OnInputChanged(string value)
    {
        if (int.TryParse(value, out int count) && count < 0)
        {
            SetCount(0);
        }

        AmountChanged?.Invoke();
    }

    private void SetCount(int count)
    {
        countInput.SetTextWithoutNotify(count.ToString());
    }

    public void ResetCount()
    {
        SetCount(0);
    }
}