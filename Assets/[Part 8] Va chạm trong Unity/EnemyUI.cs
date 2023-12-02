using UnityEngine;
public class EnemyUI : MonoBehaviour
{
    readonly float Max = 500;
    float hp;
    [SerializeField] RectTransform rectHp;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    void Start()
    {
        hp = Max;  
    }
    public void SetHp(float val){
        hp -= val;
        rectHp.sizeDelta = new Vector2(hp < Max ? hp < 0 ? 0 : hp : Max, 26);
        audioSource.clip = audioClip;
        audioSource.Play();
        if (hp <= 0) Destroy(gameObject);
    }
}
