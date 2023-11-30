using System.Collections;
using Unity.Mathematics;
using UnityEngine;
public class HeroAIPart3 : MonoBehaviour
{
    private int direction;
    public float speed, jump;
    private float spdDef;
    private Rigidbody2D rb;
    Animator anim;
    [SerializeField] GameObject objSkill;
    bool skill = true;
    bool run = false;
    Vector3 right, left;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        right = transform.localScale;
        left = new Vector3(-right.x, right.y, right.z);
        spdDef = speed;
    }
    private void Fixed()
    {
        if (transform.position.x < -76) transform.position = new Vector3(-76, transform.position.y, transform.position.z);
        if (transform.position.x > 76) transform.position = new Vector3(76, transform.position.y, transform.position.z);
        if (transform.position.y > 13) transform.position = new Vector3(transform.position.x, 13, transform.position.z);
    }
    IEnumerator Skill(){
        skill = false;
        GameObject obj = Instantiate(objSkill, transform.position, quaternion.identity);
        obj.GetComponent<SkillABC>().Skill(transform.localScale.x > 0 ? true : false);
        Destroy(obj, 1.5f);
        yield return new WaitForSeconds(0.5f);
        skill = true;
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
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            run = !run;
            speed = run ? speed * 10 : spdDef;
            anim.SetInteger("Run", run ? 2 : 1);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if(skill) StartCoroutine(Skill());
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
