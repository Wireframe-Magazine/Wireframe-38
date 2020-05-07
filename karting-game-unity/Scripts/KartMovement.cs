using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMovement : MonoBehaviour
{
    private float speed;
    private float drag = 3;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }
    private void FixedUpdate()
     {
         transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
     }
    // Update is called once per frame
    void Update()
    {
        float rot = Input.GetAxis("Horizontal") * 10;
        gameObject.transform.Rotate(0.0f, 0.0f, rot* speed * Time.deltaTime, Space.Self);
        float acc = Input.GetAxis("Vertical") * 10;
        speed += acc * Time.deltaTime;
        if(speed > 18){
            speed = 18;
        }
        if(speed > 0){
            speed -= drag * Time.deltaTime;
        }
        if(speed < 0){
            speed += drag * Time.deltaTime;
        }
    }
}
