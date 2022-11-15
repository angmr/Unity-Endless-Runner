using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    Rigidbody rb;
    ParticleSystem ps;
    MeshRenderer meshRend;
    AudioManager audioManager;
    float horizontalInput;
    int plrSpeed = 15;
    float plrHeight;
    [SerializeField] float jumpForce = 1000f;
    [SerializeField] LayerMask groundMask;
    public bool alive = true;
    bool player0nPlatform = true;
    public bool plrOnGround = true;
    float fowardPlrSpeed;
    

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("soundtrack");
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ps = gameObject.GetComponent<ParticleSystem>();
        meshRend = gameObject.GetComponent<MeshRenderer>();
        plrHeight = gameObject.GetComponent<Collider>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fowardPlrSpeed = rb.velocity.magnitude;

        if (Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            Cursor.visible = true;
            SceneManager.LoadScene("Main Menu");
        }

        if (transform.position.y < 1){
            player0nPlatform = false;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    void FixedUpdate()
    {
        plrOnGround = Physics.Raycast(transform.position, Vector3.down, plrHeight/2+1f, groundMask);

        if (!alive) return;
        if (!player0nPlatform){
            rb.AddTorque(50,0,20);
            Die();
        }

        if (!plrOnGround){
            rb.drag = fowardPlrSpeed/70;
            rb.useGravity = true;
        }

        if (plrOnGround){
            rb.drag = 0;
            rb.useGravity = false;
        }

        rb.AddForce(0, 0, 200*Time.deltaTime);
        Vector3 horizontalMove = transform.right*horizontalInput*plrSpeed*Time.fixedDeltaTime;
        rb.MovePosition(rb.position + horizontalMove);
    }

    public void Die()
    {
        alive = false;
        if (player0nPlatform){
            ps.Play();
            meshRend.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            audioManager.Play("crash");
            audioManager.Stop("soundtrack");
        }else{
            audioManager.Play("fall");
        }
       
        // restart the game
        Invoke("Restart", 4);
        // fade out current scene

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        if (plrOnGround){
            rb.AddForce(Vector3.up*jumpForce);
            audioManager.Play("jump");
            plrOnGround = false;
        }
    }
}
