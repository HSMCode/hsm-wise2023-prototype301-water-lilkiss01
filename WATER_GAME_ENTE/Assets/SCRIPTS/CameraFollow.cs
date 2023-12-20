using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}