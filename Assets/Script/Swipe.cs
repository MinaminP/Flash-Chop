using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    bool isSwipe = false;
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;
    Vector2 previousPos;
    public float minSwipeVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSwipe();
        } else if (Input.GetMouseButtonUp(0))
        {
            EndSwipe();
        }

        if (isSwipe)
        {
            SwipePosition();
        }

    }

    void StartSwipe()
    {
        isSwipe = true;
        previousPos = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void EndSwipe()
    {
        isSwipe = false;
        circleCollider.enabled = false;
    }

    void SwipePosition()
    {
        Vector2 swipePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = swipePos;
        float velocity = (swipePos - previousPos).magnitude * Time.deltaTime;
        if (velocity > minSwipeVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPos = swipePos;
    }


}
