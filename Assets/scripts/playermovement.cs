using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class playermovement : MonoBehaviour
{
    public Rigidbody rb;

    public GameManager gm;

    public float crouchingScale = 0.5f;
    private bool isCrouching;
    private bool isImmortal;
    private Vector3 standingScaleVector;
    private Vector3 crouchingScaleVector;
    public Score scores;
    public int coins = 0;
    public TextMeshProUGUI coinsText;
    public AudioClip coinSound;
    private AudioSource audioSource;


    public float runSpeed = 500f;
    public float strafeSpeed = 500f;
    public float jumpForce = 15f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;
    protected bool canJump = true;


    private void Start()
    {
        Time.timeScale = 1;
        standingScaleVector = transform.localScale;
        crouchingScaleVector = new Vector3(crouchingScale, crouchingScale, crouchingScale);
        //boxCollider = GetComponent<BoxCollider>();
        isCrouching = false;
        isImmortal = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            if (isImmortal)
            {
                Destroy(collision.gameObject);
            }
            else
            {

                Time.timeScale = 0;
                int lastRunScore = int.Parse(scores.scoreText.text.ToString());
                PlayerPrefs.SetInt("lastRunScore", lastRunScore);
                //Debug.Log("Game over!");
                gm.EndGame();
            }
            
        }

        if (collision.collider.tag == "ground")
        {
            canJump = true;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "coin") {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(collider.gameObject);
            coins++;
            coinsText.text = coins.ToString();
            //Debug.Log("количество очков: " + coins);
        }

        /*if (collider.gameObject.tag == "bonus")
        {
            Destroy(collider.gameObject);
            StartCoroutine(Bonus());
        }*/
    }
    void Update()
    {

        if (coins >= 5 && Input.GetKey("e"))
        {
            StartCoroutine(Bonus());
            coins = coins - 5;
            coinsText.text = coins.ToString();
            //Debug.Log("количество очков: " + coins);
        }
        if (Input.GetKey("d"))
            strafeRight = true;
        else strafeRight = false;

        if (Input.GetKey("a"))
            strafeLeft = true;
        else strafeLeft = false;

        if (Input.GetKeyDown("space") && canJump)
        {
            doJump = true;
            canJump = false;
        }

        if (transform.position.y < -1f)
        {
            Time.timeScale = 0;
            int lastRunScore = int.Parse(scores.scoreText.text.ToString());
            PlayerPrefs.SetInt("lastRunScore", lastRunScore);
            //Debug.Log("Game over!");
            gm.EndGame();
        }

        if (Input.GetKey("s") && !isCrouching)
        {
            isCrouching = true;
            transform.localScale = crouchingScaleVector;
        }

        else if (!Input.GetKey("s") && isCrouching) { 
            isCrouching = false;
            transform.localScale = standingScaleVector;
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce(0, 0, runSpeed * Time.deltaTime);

        rb.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);

        if (strafeRight)
            rb.MovePosition(transform.position + Vector3.right * strafeSpeed * Time.deltaTime + Vector3.forward * runSpeed * Time.deltaTime);
        //rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (strafeLeft)
            rb.MovePosition(transform.position + Vector3.left * strafeSpeed * Time.deltaTime + Vector3.forward * runSpeed * Time.deltaTime);
        // rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        /*Vector3 movement = Vector3.forward * runSpeed;

        if (strafeRight)
            movement += Vector3.right * strafeSpeed;
        if (strafeLeft)
            movement += Vector3.left * strafeSpeed;

        rb.MovePosition(Vector3.ClampMagnitude(transform.position + movement * Time.deltaTime, runSpeed));*/

        if (doJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doJump = false;
        }

    }



    private IEnumerator Bonus()
    {
        isImmortal = true;

        Renderer renderer = GetComponent<Renderer>();

        Color originalColor = renderer.material.color;

        renderer.material.color = Color.white;
        

        yield return new WaitForSeconds(5);

        renderer.material.color = originalColor;

        isImmortal = false;
    }
}
