using UnityEngine;

public class HpMpUI : MonoBehaviour
{
    public readonly float Max = 500;
    public static HpMpUI instance;
    [SerializeField] RectTransform rectHp, rectMp;
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(instance);
        else instance = this;
    }
    public float Limited(float val) => val < Max ? val < 0 ? 0 : val : Max;
    public void SetHp(float val) => rectHp.sizeDelta = new Vector2(Limited(val), 26);
    public void SetMp(float val) => rectMp.sizeDelta = new Vector2(Limited(val), 26);
}
