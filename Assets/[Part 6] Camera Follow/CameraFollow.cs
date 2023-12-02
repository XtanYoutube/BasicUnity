using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] float followSpd, offset;
    [SerializeField] Transform target;
    void Update()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y + offset, -10f);
        transform.position = Vector3.Slerp(transform.position, pos, followSpd * Time.deltaTime);
    }
}
