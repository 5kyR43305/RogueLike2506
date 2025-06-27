using UnityEngine;

public class TangentMovement : MonoBehaviour, IMoveAble
{
    public float speed = 1f;        // speed
    public float amplitude = 1f;    // high
    public float maxOffset = 5;     // max high
    private float initialY;
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
        initialY = transform.position.y;
    }

    void Update()
    {
        float tanValue = Mathf.Tan(Time.time * speed);

        tanValue = Mathf.Clamp(tanValue, -maxOffset, maxOffset);

        float y = initialY + tanValue * amplitude;

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
