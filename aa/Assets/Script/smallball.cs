using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallball : MonoBehaviour
{
    LineRenderer line;
    bool itsstop = false;
    Rigidbody2D rigi;
    Transform circle;
    manager manager;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        rigi = GetComponent<Rigidbody2D>();
        circle = GameObject.Find("Circle").transform;

        manager = GameObject.FindObjectOfType<manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (itsstop == true)
        {
            line.SetPosition(0, circle.position);
            line.SetPosition(1, transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "circle")
        {
            rigi.velocity = Vector2.zero;

            Vector2 newPos = transform.position;

            newPos.y = (circle.transform.position.y - circle.GetComponent<CircleCollider2D>().bounds.size.y) * 1.5f;

            transform.position = newPos;

            transform.SetParent(circle.transform);

            itsstop = true;

            manager.ballspositionupdate();
        }
        else if (collision.gameObject.tag == "smallball")
        {
            manager.youlost();
        }
    }
}
