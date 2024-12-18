using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [Header("Sistema de Combate")]
    [SerializeField] private float danoEnemigo;
    [SerializeField] private Transform attackpoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanable;

    private NavMeshAgent agent;
    private FirstPerson player;


    private Animator anim;
    private bool ventanaAbierta = false;
    private bool puedoDanar = true;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FirstPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        //definir como destino la posicion del player.
        agent.SetDestination(player.transform.position);

        // si la distancia que se queda hacia el objeto cae por debajo del stoppingDistance
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            //me paro ante el 
            agent.isStopped = true;
            anim.SetBool("attacking", false);
            
            
            //activar anim de ataque
            //1.obtener el COMPONENTE ANIMATOR y almacenarlo en una variable
            //2.a traves de esta variable buscar un metodo para ACTIVAR EL BOOL attacking
        }
    }

    //Eventos de animacion

    private void FinAtaque()
    {
        //caundo termina de atacar, vuelve a moverse
        agent.isStopped = false;
        anim.SetBool("attacking", false);
    }

    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    }
    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
    }
}
