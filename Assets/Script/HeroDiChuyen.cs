using UnityEngine;

public class HeroDiChuyen : MonoBehaviour
{
    public float speed = 5f; // toc do di chuyen
    public Rigidbody2D rb; // Rigidbody2D component for physics
    public float traiphai = 0; // bien traiphai de luu vi tri trai phai
    public Animator animator; // Animator component for animations
    public float nhay = 15f; // bien nay de luu toc do nhay


    //kiem tra xem co o mat dat khong
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool isGrounded;

    void Start()
    {
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        dichuyen(); // Goi ham dichuyen de xu ly di chuyen
        capnhatnhay(); // Goi FixedUpdate de xu ly nhay

            animator.SetBool("fly", !isGrounded);

    }
    private void capnhatnhay()
    {
        if (Input.GetButtonDown("Jump")) // Kiem tra nut nhay
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, nhay); // Dat van toc nhay
        }

    }
    private void dichuyen()
    {
        traiphai = Input.GetAxis("Horizontal"); // Lay input ngang tu ban phim
        rb.linearVelocity = new Vector2(traiphai * speed, rb.linearVelocity.y); // Cap nhat van toc theo input ngang
        if (traiphai > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Quay sang phai
        }
        else if (traiphai < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Quay sang trai
        }


        //chi thuc hien animation walk khi dang o mat dat
        if (isGrounded)
        {
            animator.SetFloat("walk", Mathf.Abs(traiphai));
        }
        else
        {

            animator.SetFloat("walk", 0);
        }
    }


}
