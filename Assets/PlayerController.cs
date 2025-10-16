using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public GameObject projectilePrefab;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Vector2 movementInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
        // Get horizontal and vertical input from the keyboard 
        float moveX = Input.GetAxis("Horizontal");
        //Store the input in a Vector2 
        movementInput = new Vector2(moveX, 0).normalized;
    }

    void FixedUpdate()
    {
        // Set the RigidBody2D's velocity directly 
        rb.velocity = movementInput * moveSpeed;
    }

    void Launch()
    {
        //Spawn in a bullet and set it equal to a projectileObject variable
        GameObject projectileObject = 
        Instantiate(projectilePrefab, rb.position + Vector2.up * 0.5f,
        Quaternion.identity);
        //Load the script from the spawned bullet
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        // Call the Launch method from the Projectile script
        projectile.Launch(Vector2.up, 500);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
    }
    
}

