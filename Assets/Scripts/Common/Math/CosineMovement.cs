using UnityEngine;

public class CosineMovement : MonoBehaviour, IMoveAble
{
    public float speed = 1f;        // speed
    public float amplitude = 1f;    // left and right
    private float initialX;
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
        initialX = transform.position.x;
    }


    void Update()
    {
        float x = initialX + Mathf.Cos(Time.time * speed) * amplitude;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
