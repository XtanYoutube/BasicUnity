using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAI : MonoBehaviour
{
    private int direction;

    public float speed, jump;
    private Rigidbody2D rb;

    private RectTransform rect;
    Vector3 right, left;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rect = GetComponent<RectTransform>();
        right = rect.localScale;
        left = new Vector3(-right.x, right.y, right.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            rect.localScale = right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
            rect.localScale = left;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 2;
        }

        if (direction != 0)
        {
            if (direction != 2)
                transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
            else
                rb.velocity = new Vector2(rb.velocity.x, jump);
            direction = 0;
        }
    }
}
