using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimento_inimigo : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;

    public Transform _player;

    public bool _checkMove;


    // Start is called before the first frame update
    void Start()
    {

        _agent = GetComponent<NavMeshAgent>();
        _checkMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_checkMove)
        {
         _agent.SetDestination(_player.position);
        }
        else
        {
            _agent.velocity = new Vector3(0, 0, 0);
        }
    }
}
