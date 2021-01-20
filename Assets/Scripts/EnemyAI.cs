using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speedOfMove=13f;
    public float turnMax=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         StartCoroutine(Move());
    }
   
    IEnumerator Move()
    {
        float speed = Random.Range(10, speedOfMove);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        StartCoroutine(MakeTurn());
        yield return new WaitForSeconds(0.5f);

       
    }

    IEnumerator MakeTurn()
    {
        float turn = Random.Range(-turnMax, turnMax);
        transform.Rotate(Vector3.right, Time.deltaTime * turn);

        yield return new WaitForSeconds(0.3f);
        transform.Rotate(Vector3.right, Time.deltaTime * -turn);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.Rotate(Vector3.up, Time.deltaTime * 5f);
        }
        if (collision.gameObject.tag == "CubeUpper")
        {
            transform.Rotate(Vector3.up, Time.deltaTime * -5f);
        }
        if (collision.gameObject.tag == "Base")
        {
            speedOfMove--;
        }
    }

}
