using UnityEngine;

public class CatThrow : MonoBehaviour
{   
    public float Power = 5f;

    LineRenderer lr;

    Rigidbody2D rb;

    Vector2 DragStartPos;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();

    }

    void Update()
    {
        Vector2 Vec2PointInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(Vec2PointInWorld);

        if(Input.GetMouseButtonDown(0)){
            DragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0)){
            Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (DragEndPos - DragStartPos) * Power;

            Vector2[] trajectory = Plot(rb, (Vector2)transform.position, -_velocity, 500);
            lr.positionCount = trajectory.Length;

            Vector3[] position = new Vector3[trajectory.Length];
            for (int i = 0; i < trajectory.Length; i++)
            {
                position[i] = trajectory[i];
            }
            lr.SetPositions(position);
        }

        if(Input.GetMouseButtonUp(0)){
            Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (DragEndPos - DragStartPos) * Power;
            
            rb.velocity = -_velocity;
        }
        
    }

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps){
        Vector2[] results = new Vector2[steps];

        float TimeStep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * TimeStep * TimeStep;

        float drag = 1f - TimeStep * rigidbody.drag;
        Vector2 moveStep = velocity * TimeStep;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;

    }
}
