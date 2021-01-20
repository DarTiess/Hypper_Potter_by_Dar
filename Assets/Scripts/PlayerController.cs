using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnspeed = 35f;
    private float verticalInput;
    private float horizontalInput;
    public FixedJoystick joystick;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

      
       transform.Rotate(Vector3.right, Time.deltaTime * turnspeed * -verticalInput);
       transform.Rotate(Vector3.up, Time.deltaTime * turnspeed * horizontalInput);
    }
    
    

    public void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.right, Time.deltaTime * turnspeed * -joystick.Vertical);
        transform.Rotate(Vector3.up, Time.deltaTime * turnspeed * joystick.Horizontal);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Base" || collision.gameObject.tag == "Circle")
        {
            speed-=0.5f;
        }
       if (collision.gameObject.tag == "Finish")
        {
            GameController.gamecontroller.GetFinish();
        }
    }
  
}
