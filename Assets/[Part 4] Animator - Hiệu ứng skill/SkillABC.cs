using UnityEngine;
public class SkillABC : MonoBehaviour
{
    [SerializeField] float speed;
    public void Skill(bool direction)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction ? speed : -speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) other.GetComponent<EnemyUI>().SetHp(100);
    }
}
