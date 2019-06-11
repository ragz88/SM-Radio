using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSwipe : MonoBehaviour
{

    Vector2 barInitPos, startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, touchTimeInterval;

    public float swipeSpeed = 0.3f;
    public bool useMouse = false;
    public bool useRisidualForce = true;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!useMouse)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchTimeStart = Time.time;
                startPos = new Vector2(Input.GetTouch(0).position.x, 0);
                barInitPos = transform.position;
                body.velocity = Vector2.zero;
            }

            ///////////////////////////////////////////////////////////////////////////
            if (Input.touchCount > 0)
            {
                endPos = new Vector2(Input.mousePosition.x, 0);
                direction = endPos - startPos;

                transform.position = barInitPos + (direction/100);

            }
            ///////////////////////////////////////////////////////////////////////////

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touchTimeFinish = Time.time;
                touchTimeInterval = touchTimeFinish - touchTimeStart;

                endPos = new Vector2(Input.GetTouch(0).position.x, 0);
                direction = endPos - startPos;

                if (useRisidualForce)
                {

                    body.drag = touchTimeInterval * 10;
                    body.angularDrag = touchTimeInterval * 10;

                    /*if (touchTimeInterval * 10 > 10)
                    {
                        body.drag = 10;
                        body.angularDrag = 10;
                    }
                    else*/ if (touchTimeInterval * 10 < 0.2f)
                    {
                        body.drag = 0.2f;
                        body.angularDrag = 0.2f;
                    }

                    body.AddForce(direction / touchTimeInterval * swipeSpeed);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchTimeStart = Time.time;
                startPos = new Vector2(Input.mousePosition.x, 0);
                barInitPos = transform.position;
                body.velocity = Vector2.zero;
            }

            if (Input.GetMouseButton(0))
            {
                endPos = new Vector2(Input.mousePosition.x, 0);
                direction = endPos - startPos;

                transform.position = barInitPos + (direction/100);
            }

            if (Input.GetMouseButtonUp(0))
            {
                touchTimeFinish = Time.time;
                touchTimeInterval = touchTimeFinish - touchTimeStart;

                endPos = new Vector2(Input.mousePosition.x, 0);
                direction = endPos - startPos;

                if (useRisidualForce)
                {
                    body.drag = touchTimeInterval * 10;
                    body.angularDrag = touchTimeInterval * 10;

                    /*if (touchTimeInterval * 10 > 10)
                    {
                        body.drag = 10;
                        body.angularDrag = 10;
                    }
                    else*/ if (touchTimeInterval * 10 < 0.2f)
                    {
                        body.drag = 0.2f;
                        body.angularDrag = 0.2f;
                    }

                    body.AddForce(direction / touchTimeInterval * swipeSpeed);
                }
            }
        }
    }
}
