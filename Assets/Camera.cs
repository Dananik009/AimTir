using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float upSpeed;
    void Update()
    {
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * upSpeed, 0));
    }
}