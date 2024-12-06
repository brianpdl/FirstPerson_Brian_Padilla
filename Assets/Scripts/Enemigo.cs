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

    private bool ventanaAbierta;
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
        agent.SetDestination(player.transform.position);
    }
}
