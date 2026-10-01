using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [TextArea(3, 10)] public string promptMessage;

    protected GameObject towerPrefab;
    protected Vector3 buildPosition;


    public void BasicInteract()
    {
        Interact();
    }

    public virtual void BasicInteract(GameObject tower, Vector3 position)
    {
        towerPrefab = tower;
        buildPosition = position;
        Interact();
    }

    protected virtual void Interact()
    {
        // Virtual function
    }

    public virtual bool CanInteract()
    {
        return true;
    }
}
