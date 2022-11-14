using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public float timeToRevivePlayer;

    public int damage = 10;

    private float timeRevivalCounter;
    private bool isPlayerReviving;
    private GameObject player;

    private void Update()
    {
        /*
        if (isPlayerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;

            if (timeRevivalCounter <= 0)
            {
                isPlayerReviving = false;
                player.SetActive(true);
            }
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            /*
            player = other.gameObject;
            player.SetActive(false);
            isPlayerReviving = true;
            timeRevivalCounter = timeToRevivePlayer;
             */
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }
    }
}
