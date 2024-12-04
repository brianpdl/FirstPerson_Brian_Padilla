using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;

    private CharacterController controller;

    private Camera cam; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //esto pa bloquear el raton en el cntro y lo oculta.
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        //MoverYRotar();
        AplicarGravedad();

        //if (EnSuelo)
        {
            //movimientoVertical.y = 0;
            Saltar();
        }
        



        //si existe input...


        //controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);



    }

    private void MoverYRotar()
    {
        float h=Input.GetAxisRaw("Horizontal");
        float v=Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;

        transform.eulerAngles = new Vector3(0,cam.transform.eulerAngles.y,0);

        if(input.magnitude > 0)
        {
          float angulorotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
          transform.eulerAngles = new Vector3(0, angulorotacion,0);
           Vector3 movimiento = Quaternion.Euler(0, angulorotacion, 0) * Vector3.forward;
           controller.Move(movimiento*velocidadMovimiento*Time.deltaTime);

        }
    }

    private void AplicarGravedad()
    {
        //moviemientoVertical.y += factorGravedad * Time.deltaTime;
        //controller.Move(movimientovertical * Time.deltaTime);
    }


    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //movimientoVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaSalto);
        }
    }

    private void OnDrawnGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
}
