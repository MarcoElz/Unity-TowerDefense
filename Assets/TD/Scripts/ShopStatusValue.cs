using UnityEngine;

public enum ShopStatus { None, Buying }

[CreateAssetMenu(fileName = "Shop Status", menuName = "Game/Shop Status", order = 1)]
public class ShopStatusValue : ScriptableObject
{
    public ShopStatus Status { get; private set; }

    private void Awake()
    {
        Status = ShopStatus.None;
    }

    public void SetStatus(ShopStatus status)
    {
        Status = status;
    }
}
