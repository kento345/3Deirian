using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 offset;

    void Start()
    {
        //カメラとターゲットの間の距離
        offset = gameObject.transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        //カメラをターゲトに2点間距離を足した位置に固定
        gameObject.transform.position = target.transform.position + offset;
    }
}
