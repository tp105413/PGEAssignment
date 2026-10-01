using UnityEngine;

public class BuildZone : Interactable
{
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
        //Vector3 direction = buildPosition - Vector3.zero;
        //direction.y = 0;

        //float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        //float snapped = Mathf.Round(angle / 45f) * 45f;

        //Quaternion rotation = Quaternion.Euler(0, snapped, 0);

        // Place tower
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
