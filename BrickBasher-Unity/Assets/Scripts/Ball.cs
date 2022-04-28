/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: Rohit Khanolkar  
 * Last Edited: April 28, 2022
 * 
 * Description: Controls the ball and sets up the intial game behaviors. 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    
    [Header("General Settings")]
    public float score;
    public float ballSpeed; //speed of ball
    public GameObject paddle; //reference to paddle 
    public Text scoreTxt; 
    public Text ballTxt;
    private Rigidbody rb; //reference to Rigidbody
    

    [Header("Ball Settings")]
    public int numBalls; //number of lives
    private AudioSource audioSource;
    private bool isInPlay = true;
  


    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }//end Awake()


        // Start is called before the first frame update
    void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()


    // Update is called once per frame
    void Update()
    {
        //UI Updates

        //Check ball in play
        if (isInPlay == false)
        {
            Vector3 pos = transform.position;
            pos.x = paddle.transform.position.x; 
        }

        //spacekey check
        if (Input.GetKeyDown(KeyCode.Space) && isInPlay == false)
        {
            isInPlay = true;
            Move();
        }



    }//end Update()


    private void LateUpdate()
    {
        if (isInPlay == true)
        {
            rb.velocity = ballSpeed * Vector3.up;
        }

    }//end LateUpdate()


    void SetStartingPos()
    {
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddel
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball 
    }//end SetStartingPos()


    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        GameObject otherGo = collision.gameObject;
        if (otherGo.tag == "Brick")
        {
            score += 100;
            Destroy(otherGo);
        }
    }

    void OnTriggerEnter(Collider trig)
    {
        if (trig.tag == "OutBounds")
        {
            numBalls -= 1;
        }
        if (numBalls > 0)
        {
            Invoke("SetStartingPos", 2); 
        }
    }


    void Move()
    {
        
    }


}
