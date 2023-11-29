using UnityEngine;
public class HeroAIPart2 : MonoBehaviour
{
    private int direction;
    public float speed, jump;
    private Rigidbody2D rb;
    Vector3 right, left;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        right = transform.localScale;
        left = new Vector3(-right.x, right.y, right.z);
    }
    private void Fixed()
    {
        if (transform.position.x < -76) transform.position = new Vector3(-76, transform.position.y, transform.position.z);
        if (transform.position.x > 76) transform.position = new Vector3(76, transform.position.y, transform.position.z);
        if (transform.position.y > 13) transform.position = new Vector3(transform.position.x, 13, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        Fixed();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            transform.localScale = right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
            transform.localScale = left;
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
