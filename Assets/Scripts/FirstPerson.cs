using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;
    void Start()
    {
        //esto pa bloquear el raton en el cntro y lo oculta.
        Cursor.lockState = CursorLockMode.Locked;

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
           Vector3 movimiento = Quaternion.Euler(0, angulorotacion, 0) * Vector3.forward;
           controller.Move(movimiento*velocidadMovimiento*Time.deltaTime);

        }


        //controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);



    }
}
