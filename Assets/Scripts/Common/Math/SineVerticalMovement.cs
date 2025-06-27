using UnityEngine;

public class SineVerticalMovement : MonoBehaviour, IMoveAble
{
    public float speed = 1f;
    public float amplitude = 1f;
    private float startY;
    bool isMove = false;

    public void Stop()
    {
        isMove = false;
    }

    public void Move()
    {
        isMove = true;
    }

    void Start()
    {
        startY = transform.position.y;
    }

 
    void Update()
    {
        float y = startY + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
