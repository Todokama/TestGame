using UnityEngine;
using UnityEngine.EventSystems;

public class Chip : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public bool isBlockActive;
    private Cell cell;

    void Start()
    {
        cell = gameObject.GetComponentInParent<Cell>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        this.cell.enabled = true;
        this.isBlockActive = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        this.isBlockActive = false;
    }
   
}
