using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // kecepatan gerakan sama kekuatan pas lompatnya
    public float moveSpeed, jumpForce;
    // reference ke rigidbodynya
    private Rigidbody2D rb;
    // dia lagi bergerak kekanan gak? lagi lompat gak?
    [SerializeField] private bool isFacingRight, isJumping;
    // lagi ditanah kah?
    [SerializeField] private bool isGrounded = false;
    // reference ke animatornya
    private Animator anim;
    private string walkParam = "isWalking";
    private string jumpParam = "isJumping";
    private string landingParam = "isLanding";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // karna cuma lompat doang
        Jump();
    }

    private void Movement()
    {
        // ambil arah nya
        // positif = kanan
        // negatif = kiri
        // 0 = berhenti / gak jalan
        float direction = Input.GetAxisRaw("Horizontal");
        // getaxisraw = dia langsung 1 / -1
        // getaxis = dia kaya ada percepatannya dari 0 ke 0.1 ke 0.2 dst sampai 1
        //           gak langsung

        // kalau jalan, play animasi jalan
        if (direction != 0) anim.SetBool(walkParam, true);
        else anim.SetBool(walkParam, false);

        // tentukan hadap kiri atau kanan
        if (direction < 0 && isFacingRight) // kekiri
        {
            isFacingRight = false;
            // kenapa -180? karna dia menghadap kekiri
            // kenapa gak flipX di sprite renderer? karna kita punya bullet
            // kalau cuma flip, maka rotation bulletnya gak akan bener
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (direction > 0 && !isFacingRight) // kekanan
        {
            isFacingRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // teken tombol spasi
        {
            // bikin isgrounded nya false
            isGrounded = false;
            // naek karna vector2.up, y = 1 ; x = 0
            // maka naik di y nya doang
            rb.velocity = Vector2.up * jumpForce;
        }

        if (!isGrounded && !isJumping)
        {
            // kalau lagi nggak di tanah sama lagi gak lompat
            anim.SetTrigger(jumpParam);
            isJumping = true;
        }
        else if (isGrounded && isJumping)
        {
            anim.SetTrigger(landingParam);
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        // disini biar movement nya gak aneh
        Movement();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground")) // kalau nyentuh tanah
        {
            isGrounded = true; // maka isgrounded
        }
        else if (collision.collider.CompareTag("goal"))
        {
            if (GoalManager.singleton.canEnter) Debug.Log("Congratulation you win the game");
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("holywater"))
        {
            GoalManager.singleton.CollectHolyWater();
            Destroy(other.gameObject);
        }
    }
}
