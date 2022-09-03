using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D coll;
    private Animator anim;
    Transform selftranform;
    //[SerializeField] private Transform spawnPoint;
    [SerializeField] private LayerMask jumpableGround;
    private SpriteRenderer sprite;
    private float moveX;
    private float jumpForce = 7f;
    private float moveSpeed = 5f;
    public float hangTime = .2f;
    private float hangCounter;

    public float JumpBufferLength = .5f;
    private float JumpBufferCount;
    //public ParticleSystem footsteps;
    //private ParticleSystem.EmissionModule footEmission;
    //public ParticleSystem ImpactEffect;
    private bool wasOnGround;

    private enum MovementState { idel, jump, runing, falling, hit, die }
   // [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {

        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        selftranform = transform;
        //footEmission = footsteps.emission;
        //SpawnPlayerOnPoint();
    }

    // Update is called once per frame
    private void Update()
    {

        // It's work on unity input Manager 
        moveX = Input.GetAxisRaw("Horizontal"); //if we don't want to slide so then we use raw
        rbody.velocity = new Vector2(moveX * moveSpeed, rbody.velocity.y);
        //manage HangTime
        if (IsGrounded())
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        //manage JumpBuffer
        if (Input.GetButtonDown("Jump"))
        {
            JumpBufferCount = JumpBufferLength;
        }
        else
        {
            JumpBufferCount -= Time.deltaTime;
        }
        //Jump In the air
        if (JumpBufferCount >= 0 && hangCounter > 0f)
        {
            //jumpSoundEffect.Play();
            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
            JumpBufferCount = 0;
            //CreatDust();

        }
        //Small Jump
        if (Input.GetButtonUp("Jump") && rbody.velocity.y > 0)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, rbody.velocity.y * .5f);
        }

/*
        //show footshow Effect
        if (Input.GetAxisRaw("Horizontal") != 0 && IsGrounded())
        {
            footEmission.rateOverTime = 35f;
        }
        else
        {
            footEmission.rateOverTime = 0f;
        }
        //Show Impact Effect
        if (!wasOnGround && IsGrounded())
        {
            ImpactEffect.gameObject.SetActive(true);
            ImpactEffect.Stop();
            ImpactEffect.transform.position = footsteps.transform.position;
            ImpactEffect.Play();

        }
        */
        wasOnGround = IsGrounded();
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (moveX > 0f)
        {
            //move Right
            state = MovementState.runing;
            // sprite.flipX = false;
            selftranform.rotation = new Quaternion(0, 0, 0, 0);
            //CreatDust();
        }
        else if (moveX < 0f)
        {
            //move Left
            state = MovementState.runing;
            //sprite.flipX = true;
            selftranform.rotation = new Quaternion(0, -180, 0, 0);
            //Dust.Play();
        }
        else
        {
            state = MovementState.idel;
        }
        if (rbody.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rbody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    /*
    void SpawnPlayerOnPoint()
    {
        selftranform.position = spawnPoint.position;

    }
    */
    /*
    public void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == TagTracker.killTriggerTag)
        {
            SpawnPlayerOnPoint();
        }
    }
    void CreatDust()
    {
        Dust.Play();
    }

    */
}
