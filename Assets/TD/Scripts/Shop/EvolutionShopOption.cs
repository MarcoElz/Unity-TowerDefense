using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionShopOption : MonoBehaviour
{
    [SerializeField] Image evolutionImage = default;
    [SerializeField] TMP_Text evolutionNameLabel = default;
    [SerializeField] TMP_Text costLabel = default;
    [SerializeField] Button button = default;

    private Evolution evolution;
    private Shop shop;

    public void Init(Evolution evolution, Shop shop)
    {
        this.evolution = evolution;
        this.shop = shop;

        evolutionImage.sprite = evolution.tower.sprite;
        evolutionNameLabel.text = evolution.tower.name;
        costLabel.text = "Cost: " + evolution.cost;

        button.onClick.AddListener(OptionClicked);
    }

    private void OptionClicked()
    {
        shop.TryBuyEvolutionInCurrentTower(evolution);
    }

}
