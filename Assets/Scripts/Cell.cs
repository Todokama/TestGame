using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell right;
    public Cell down;
    public Cell left;
    public Cell up;

    public Chip fill;
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && this.transform.childCount == 1 && this.fill.isBlockActive == true) SlideChip(this, this.up);
        if (Input.GetKeyDown(KeyCode.S) && this.transform.childCount == 1 && this.fill.isBlockActive == true) SlideChip(this, this.down);
        if (Input.GetKeyDown(KeyCode.D) && this.transform.childCount == 1 && this.fill.isBlockActive == true) SlideChip(this, this.right);
        if (Input.GetKeyDown(KeyCode.A) && this.transform.childCount == 1 && this.fill.isBlockActive == true) SlideChip(this, this.left);
    }

    void SlideChip(Cell currentCell, Cell nextCell)
    {
        if (nextCell != null && nextCell.fill == null)
        {
            nextCell.enabled = true;
            nextCell.fill = currentCell.fill;
          
            currentCell.fill.transform.SetParent(nextCell.transform);
            nextCell.fill.transform.position = nextCell.transform.position;

            currentCell.enabled = false;
            currentCell.fill = null;
            
        }
    }
}
