using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    GameObject playerRef;
    public float score;
    Vector3 lastPosition;
    public Text ScorePrint;
    
  
    // Use this for initialization
    void Start()
    {
        playerRef = GameObject.Find("Player");
        lastPosition = playerRef.GetComponent<Transform>().transform.position;
        ScorePrint = GameObject.Find("DistanceTraveled").GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score += Vector3.Distance(playerRef.GetComponent<Transform>().transform.position, lastPosition);
        lastPosition = playerRef.GetComponent<Transform>().transform.position;
        //Debug.Log(score); Use to print to console and keep track.
        ScorePrint.text = score.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") || other.CompareTag("Enemy"))
        {
            GetComponent<EnemyHit>().endGame();
        }
    }
}
