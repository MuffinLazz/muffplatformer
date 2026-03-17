using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded = true;
    private Rigidbody2D rb;

    public float speed = 500;
    public float vspeed = 200;

    public int coinsCollected = 0;
    public int Stars = 0;
    public int Health = 10;
    
    public TMP_Text coinsCollectedText;
    public TMP_Text HealthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HealthText.text = HealthText.ToString();
        coinsCollectedText.text = coinsCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
            rb.AddForce(Vector2.up * vspeed);
            isGrounded = false;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("You are going right!");

            rb.AddForce(Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("You are going left(based)!");
            rb.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("You are going down noooow!");
            rb.AddForce(Vector2.down * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sun")
        {
            coinsCollected++;
            coinsCollectedText.text = coinsCollected.ToString();
        }

        if (other.gameObject.name == "Stars")
        {
            Stars = Stars + (1);
        }

        if (other.gameObject.name == "Enemy")
        {
            Health = Health - (10);
            HealthText.text = Health.ToString();
        }

        {
            if (Health == 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }



}












