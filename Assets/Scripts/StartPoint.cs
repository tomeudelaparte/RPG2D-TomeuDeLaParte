using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartPoint : MonoBehaviour
{
    public string uuid; // UUID = Universal Unique Identifier

    [SerializeField] private Vector2 facingDirection;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        if (!playerController.nextUuid.Equals(uuid))
        {
            return;
        }

        playerController.transform.position = transform.position;
        playerController.lastDirection = facingDirection;

        GameObject confiner = GameObject.Find("Camera Confiner");

        if (confiner != null)
        {
            GameObject.FindObjectOfType<CinemachineConfiner2D>().m_BoundingShape2D = confiner.GetComponent<PolygonCollider2D>();
        }
    }
}