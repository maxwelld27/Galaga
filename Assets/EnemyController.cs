using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    public GameObject projectilePrefab;
    private Rigidbody2D enemyRb;

    public float speed = 5f;    
    public float changeTime = 3;
    float timer;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        
        timer = changeTime;

    }

    // Update is called once per frame
    void Update()
    {
        // Start counting down the timer 
        timer -= Time.deltaTime;
        // check when the timer reaches 0
        if(timer < 0)
        {
            // Inverse the current direction 
            direction = -direction;
            // Set timer back to start
            timer = changeTime;

            Launch();
        }

    }

    void FixedUpdate()
    {
        // Store the Rigidbody2D's position
        Vector2 position = enemyRb.position;
        // Get the x position and move it in the current direction
        position.x = position.x + speed * Time.deltaTime * direction;
        // Set current position to the new updated position
        enemyRb.MovePosition(position);
    }

    void Launch()
    {
        //Spawn in a bullet and set it equal to a projectileObject variable
        GameObject projectileObject = Instantiate(projectilePrefab, enemyRb.position + Vector2.down * 0.5f, Quaternion.identity);
        //Load the script from the spawned bullet
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        // Call the Launch method from the Projectile script
        projectile.Launch(Vector2.down, 500);
    }
}


