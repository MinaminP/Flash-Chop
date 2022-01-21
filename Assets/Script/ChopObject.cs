using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopObject : MonoBehaviour
{
    public bool isTapObject;
    public int tapsToDestroy;
    public int addScore;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (isTapObject)
        {
            rb.AddForce(transform.right * -3, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tapsToDestroy == 0)
        {
            Score.score += addScore;
            Destroy(this.gameObject);
        }

        if (Timer.timeRunning == false)
        {
            Destroy(this.gameObject);
        }
    }

    void OnMouseDown()
    {
        if (isTapObject)
        {
            tapsToDestroy--;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTapObject)
        {
            if(collision.tag == "Swipe")
            {
                tapsToDestroy--;
            }
        }
    }
}
