using UnityEngine;

public interface IMoveAble
{
    void Stop();
    void Move();
}

public class MoveManager : MonoBehaviour
{
    [SerializeField] SineVerticalMovement sine;
    [SerializeField] TangentMovement tangent;
    [SerializeField] CosineMovement cosine;

    IMoveAble currentMoveable;

    void Start()
    {
        sine.enabled = false;
        tangent.enabled = false;
        cosine.enabled = false;
        currentMoveable = null;
    }

    void FindMoveable()
    {
        MonoBehaviour[] components = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour comp in components)
        {
            if (comp is IMoveAble)
            {
                comp.enabled = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            FindMoveable();
            tangent.enabled = true;
            currentMoveable = tangent;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            FindMoveable();
            cosine.enabled = true;
            currentMoveable = cosine;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            FindMoveable();
            sine.enabled = true;
            currentMoveable = sine;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            currentMoveable?.Move();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            currentMoveable?.Stop();
        }
    }
}
