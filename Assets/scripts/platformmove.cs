using UnityEngine;

public class platformmove : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public float distanceToMove;

    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = Vector3.right;
    }

    void FixedUpdate()
    {
        if (transform.position.x < -distanceToMove / 2)
        {
            movement = Vector3.right;
        }
        else if (transform.position.x > distanceToMove / 2)
        {
            movement = Vector3.left;
        }

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}