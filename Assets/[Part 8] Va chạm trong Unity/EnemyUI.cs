using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    readonly float Max = 500;
    float hp;
    [SerializeField] RectTransform rectHp;
    void Start()
    {
        hp = Max;
    }
    public void SetHp(float val)
    {
        hp -= val;
        rectHp.sizeDelta = new Vector2(hp < Max ? val < 0 ? 0 : hp : Max, 26);
        if (hp <= 0) Destroy(gameObject);
    }
}
