using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
birds gravity, bird still but things/obstacles coming ahead, on click fly-jump and then again come down, colliders with obstacles or with ground - gameover
*/

public class Player : MonoBehaviour
{
    public float i = 0;

    public FloatVariable timer;
    
    public CircleCollider2D playerCollider;

    public BoolVariable playerAlive;

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    bool didFlap = false;
    public Vector3 flapVelocity;
    public float maxSpeed = 5f;
    public float forwardSpeed = 1f;

    public AudioSource playerAudioSource;
    public AudioClip playerFlap;
    public AudioClip playerCrash;
    public AudioClip playerLight;

    // Start is called before the first frame update
    void Awake()
    {

        playerAlive.value = true;
        timer.SetValue(0);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        if(Input.GetMouseButton(1)){

            

            i++;

            if(i > 0)
            {

                timer.SetValue(i);

                if(i > 5)
                {
                    Debug.Log("Collider Enabled!");
                    playerCollider.enabled = true;
                }

            }
        }
        }
        if(Input.GetMouseButtonDown(1))
        {

            playerCollider.enabled = false;

            i = 0;
        }

        if(Input.GetMouseButtonUp(1))
        {
            i = 0;
            playerCollider.enabled = true;
        }

    }

    private void FixedUpdate() 
    {
        if(playerAlive.value)
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        velocity.x = forwardSpeed;
        velocity = velocity + gravity;
        if(didFlap==true)
        {
           playerAudioSource.PlayOneShot(playerFlap); 

           didFlap = false;

           if(velocity.y<0)
           {
               velocity.y = 0;
           }

           velocity += flapVelocity; 
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity*Time.fixedDeltaTime;

        float angle = 0;
        if(velocity.y<0)
        {
          angle = Mathf.Lerp(0,-45,-velocity.y/maxSpeed);
        }
        

        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
       
       if(collision.transform.tag != "Sky")
        {
            playerAudioSource.PlayOneShot(playerCrash);

            playerAlive.value = false;
            
            Debug.Log("GAME OVER");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.tag == "Light")
        {
            playerAudioSource.PlayOneShot(playerLight);
        }
    }

    
}
