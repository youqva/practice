using UnityEngine;

public class platformmovement_left : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float distanceToMove;

    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = Vector3.left;
    }

    void FixedUpdate()
    {
        if (transform.position.x > distanceToMove / 2)
        {
            movement = Vector3.left;
        }
        else if (transform.position.x < -distanceToMove / 2)
        {
            movement = Vector3.right;
        }

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}