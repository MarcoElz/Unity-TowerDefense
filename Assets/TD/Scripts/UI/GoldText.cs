using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldText : MonoBehaviour
{
    [SerializeField] Inventory inventory = default;
    [SerializeField] TMP_Text goldLabel = default;

    private void OnEnable()
    {
        inventory.onGoldAmountChanged += UpdateGoldLabel;
    }

    private void OnDisable()
    {
        inventory.onGoldAmountChanged -= UpdateGoldLabel;
    }

    private void UpdateGoldLabel(int goldAmount)
    {
        goldLabel.text = "Gold: " + goldAmount.ToString("D3");
    }

}
