using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private int numOfPlace;
    // Start is called before the first frame update
    void Start()
    {
        numOfPlace = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
   private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy" || collision.gameObject.tag == "Player")
        {
            numOfPlace++;
            if(collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
           
             if (collision.gameObject.tag == "Player")
             {
                  GameController.gamecontroller.PlayerPlace(numOfPlace);
             } 
            
           
        }
       
    }
}
