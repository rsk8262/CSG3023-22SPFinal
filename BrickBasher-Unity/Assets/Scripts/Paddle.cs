/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: Rohit Khanolkar  
 * Last Edited: April 28, 2022
 * 
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10; //speed of paddle


    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;

        pos.x += xAxis * speed * Time.deltaTime;

        transform.position = pos;

    }//end Update()
}
