using UnityEngine;
using System.Collections;

public class CanvasPlay : MonoBehaviour
{

    public void PlayButton()
    {
        Application.LoadLevel(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
