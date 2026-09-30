using UnityEngine;
using UnityEngine.Timeline;

public abstract class Interactable : MonoBehaviour
{
    [Multiline(3)] public string promptMessage;

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

    }

    public virtual bool CanInteract()
    {
        return true;
    }
}
