using UnityEngine;

public class Float : MonoBehaviour
{
    public float amplitude = 0.1f; 
    public float speed = 1f; 
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; 
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
