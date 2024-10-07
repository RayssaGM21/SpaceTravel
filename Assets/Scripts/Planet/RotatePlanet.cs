using UnityEngine;

public class Rotate2DSprite : MonoBehaviour
{
    public float rotationSpeed = 0.6f;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
