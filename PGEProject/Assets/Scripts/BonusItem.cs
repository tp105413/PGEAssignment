using UnityEngine;

public enum ItemType { trophy, gloves }

public class BonusItem : Interactable
{
    public int cost;
    public ItemType itemType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                    // Add up player knockback to 10000
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
