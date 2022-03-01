using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CharaControler : MonoBehaviour
{
    public float run = 20f;
    public float topSpeed = 5f;
    public float jumpForce = 0.5f;
    public float jumpBonus = 0.5f;
    private Rigidbody rb;
    private Collider collider;
    public bool feetOnGround;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float castDistance = collider.bounds.extents.y + 0.1f;
        feetOnGround = Physics.Raycast(transform.position, Vector3.down, castDistance);

        // Speed Run
        float axis = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", rb.velocity.magnitude);
        rb.AddForce(Vector3.right * axis * run, ForceMode.Force);

        // Turbo
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(Vector3.right * axis * 2 * run, ForceMode.Force);
        }

        // Jump Check
        _animator.SetBool("Jumping", !feetOnGround);
        if (Input.GetKey(KeyCode.Space) && feetOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.AddForce(Vector3.up * jumpBonus, ForceMode.Impulse);
        }

        if (Mathf.Abs(rb.velocity.x) > topSpeed)
        {
            float newX = topSpeed * Mathf.Sign(rb.velocity.x);
            rb.velocity = new Vector3(newX, rb.velocity.y, rb.velocity.z);
        }

        if (Mathf.Abs(axis) < 0.1f)
        {
            float newX = rb.velocity.x * (1f - Time.deltaTime * 15f);
            rb.velocity = new Vector3(newX, rb.velocity.y, rb.velocity.z);
        }

        //Debug.Log(rb.velocity.magnitude);
    }
}