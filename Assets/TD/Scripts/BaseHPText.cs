using TMPro;
using UnityEngine;

public class BaseHPText : MonoBehaviour
{
    [SerializeField] PlayerBase playerBase = default;
    [SerializeField] TMP_Text playerBaseHpLabel = default;

    private void OnEnable() => playerBase.onHPChanged += ChangeText;

    private void OnDisable() => playerBase.onHPChanged -= ChangeText;

    private void ChangeText(int value)
    {
        playerBaseHpLabel.text = "HP: " + value.ToString();
    }
}
