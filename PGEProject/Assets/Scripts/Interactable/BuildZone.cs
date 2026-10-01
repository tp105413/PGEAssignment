using UnityEngine;

public class BuildZone : Interactable
{
    protected override void Interact()
    {
        Instantiate(towerPrefab, buildPosition, transform.rotation);
        GameManager.Instance.isHoldingItem = false;
        UIManager.Instance.itemHolded.SetActive(false);
    }

    public override bool CanInteract()
    {
        // Check if player is holding item
        return GameManager.Instance.isHoldingItem;
    }
}
