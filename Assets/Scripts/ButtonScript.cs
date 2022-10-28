using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Application.LoadLevel("SampleScene");
    }

}
