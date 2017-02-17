using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController cc;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");// * Time.deltaTime * 200.0f;
        float z = Input.GetAxis("Vertical");// * Time.deltaTime * 15.0f;

        Vector3 dir = new Vector3(-z, 0, x).normalized;


        // transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);

        cc.SimpleMove(dir * speed);
        transform.LookAt(transform.position + dir);
    }
}