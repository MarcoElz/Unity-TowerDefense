using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTowerButton : MonoBehaviour
{
    [SerializeField] Evolution data = default;
    [SerializeField] Button button = default;
    [SerializeField] Shop shop = default;

    private void Start()
    {
        button.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        shop.TryBuyNewTower(data);
    }
}
