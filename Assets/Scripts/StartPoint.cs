using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private Vector2 facingDirection;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.transform.position = transform.position;

        playerController.lastDirection = facingDirection;
    }

 
}

