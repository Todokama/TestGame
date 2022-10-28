using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] fillPrefabs;
    [SerializeField] Transform[] allCells;
    private static int countOfOneColor = 5;

    void Start()
    {
        for (int i = 0; i < countOfOneColor; i++)
            for (int countOfPref = 0; countOfPref < fillPrefabs.Length; countOfPref++)
                SpawnFill(countOfPref);        
    }


    private void Update()
    {
        if (CheckRow("red", 0) && CheckRow("white", 2) && CheckRow("blue", 4)) {
            EndGame();
        };
    }

    public void SpawnFill(int prefNumber)
    {
        int whichSpawn = Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].childCount != 0)
        {
            SpawnFill(prefNumber);
            return;
        }

        GameObject tempFill = Instantiate(fillPrefabs[prefNumber], allCells[whichSpawn]);
        Chip tempChipComp = tempFill.GetComponent<Chip>();
        allCells[whichSpawn].GetComponent<Cell>().fill = tempChipComp;

        if (CheckRow("red", 0) || CheckRow("white", 2) || CheckRow("blue", 4)){
            Destroy(tempFill);
            SpawnFill(prefNumber);
        }
    }
    
    bool CheckRow(string prefabTag, int numberofColumn)
    {
        int y = 0;
        for(int i =0; i < 5; i++)
        {
            GameObject cell = GameObject.Find("c" + numberofColumn + i);
            if (cell.transform.childCount == 1)
                if (cell.GetComponent<Cell>().fill != null && cell.GetComponent<Cell>().fill.tag == prefabTag)
                    y++;         
        }
        if (y == 5) return true;
        else return false;
    }

    public void EndGame()
    {
        foreach(Transform cell in allCells)
        {
            if (cell.childCount == 1)
            {
                Transform child = cell.GetChild(0);
                child.GetComponent<Button>().enabled = false;
            }
        }
        GameObject winPanel = GameObject.FindGameObjectWithTag("GameOver");
        for(int i = 0; i<winPanel.transform.childCount; i++)
        {
            Transform child = winPanel.transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
    }

   
}
