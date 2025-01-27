using UnityEngine;

public class Camera : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * 0.2f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * 0.2f;
        }
    }
}
