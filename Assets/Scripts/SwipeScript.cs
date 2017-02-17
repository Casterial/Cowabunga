using UnityEngine;
using System.Collections;

public class SwipeScript : MonoBehaviour
{
    private Touch initialTouch = new Touch();
    private float distance = 0;
    private bool hasSwiped = false;

    void FixedUpdate()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                initialTouch = t;
            }
            else if (t.phase == TouchPhase.Moved && !hasSwiped)
            {
                float deltaX = initialTouch.position.x - t.position.x;
                float deltaY = initialTouch.position.y - t.position.y;
                distance = Mathf.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);

                if (distance > 100f)
                {
                    if (swipedSideways && deltaX > 0) //swiped left
                    {
                        this.transform.Rotate(new Vector3(0, -15f, 0));
                    }
                    else if (swipedSideways && deltaX <= 0) //swiped right
                    {
                        this.transform.Rotate(new Vector3(0, 15f, 0));
                    }
                    else if (!swipedSideways && deltaY > 0) //swiped down
                    {
                        this.transform.Rotate(new Vector3(0, 180f, 0));
                    }
                    else if (!swipedSideways && deltaY <= 0)  //swiped up
                    {
                        this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 0, this.GetComponent<Rigidbody>().velocity.z);
                        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100f, 0));
                    }

                    hasSwiped = true;
                }

            }
            else if (t.phase == TouchPhase.Ended)
            {
                initialTouch = new Touch();
                hasSwiped = false;
            }
        }
    }
}