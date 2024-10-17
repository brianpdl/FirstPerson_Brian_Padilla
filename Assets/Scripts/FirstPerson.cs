using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h=Input.GetAxisRaw("Horizontal");
        float v=Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;

        //si existe input...
        if(input.magnitude > 0)
        {
          float angulorotacion = Mathf.Atan2(input.x, input.y);
          transform.eulerAngles = new Vector3(0, angulorotacion,0);


        }


        //controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);



    }
}
