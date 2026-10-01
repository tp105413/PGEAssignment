using UnityEngine;

public enum ItemType { trophy, gloves }

public class BonusItem : Interactable
{
    public int cost;
    public ItemType itemType;


    protected override void Interact()
    {
        switch (itemType)
        {
            case ItemType.trophy:
                if(GameManager.Instance.sunCount >= cost)
                {
                    GameManager.Instance.SpendSun(cost);
                    GameManager.Instance.Win();
                }
                break;
            case ItemType.gloves:
                if (GameManager.Instance.sunCount >= cost)
                {
                    GameManager.Instance.SpendSun(cost);
                    GameManager.Instance.knockback = 1000f;
                }
                break;
        }
    }

    public override bool CanInteract()
    {
        // Check if player is not holding item
        return !GameManager.Instance.isHoldingItem;
    }
}
