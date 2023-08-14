using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportStartPoint : MonoBehaviour
{
    public Transform StartingPointPlayer;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player") && StartingPointPlayer != null)
        {
            CharacterController characterController = other.gameObject.GetComponent<CharacterController>();
            characterController.enabled = false;
            other.gameObject.transform.position = StartingPointPlayer.position;
            characterController.enabled = true;
        }
        
        
    }
}
