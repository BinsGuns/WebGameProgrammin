using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class EnemyCombatSystem : MonoBehaviour
{
    [SerializeField] private float _attackOneDamage;
    [SerializeField] private float _attackDelay;
    private bool _attackingPlayer = true;
    private EnemyController _enemyController;
    private NavMeshAgent _navMeshAgent;
    private PlayerInput PlayerInput;
   
    private BoxCollider _collider;
  

    // Start is called before the first frame update
    void Start()
    {
        _enemyController = GetComponent<EnemyController>();
        _enemyController.EnemyDeadAnimation += EnemyDead;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<BoxCollider>();
        PlayerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
    }

    private void EnemyDead()
    {
        _navMeshAgent.isStopped = true;
        _attackingPlayer = false;
        _collider.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            Time.timeScale = 0;
            PlayerInput.gameObject.SetActive(false);
            GameObject.FindWithTag("UIHUD").transform.GetChild(0).gameObject.SetActive(true);
        }
      
    }

   
    
}
