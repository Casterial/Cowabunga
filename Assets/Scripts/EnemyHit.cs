using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHit : MonoBehaviour
{
     GameObject gameoverScreen;
     GameObject gameUI;
     Text finalScore;
    void Awake()
    {
        gameUI = GameObject.Find("CanvasUI");
        gameoverScreen = GameObject.Find("LosingScreen");
        finalScore = GameObject.Find("NumberSurfed").GetComponent<Text>();

    }


    void Start()
    {
        gameoverScreen.SetActive(false);
    }

    public void endGame()
    {
        gameoverScreen.SetActive(true);
        finalScore.text = GameObject.Find("DistanceTraveled").GetComponent<Text>().text;
        gameUI.SetActive(false);
    }
}
