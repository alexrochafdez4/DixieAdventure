using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour // esto maneja el daño infligido al jugador cuando entra en contacto con un objeto que tenga este script adjunto. como las rocas y los pinchos.
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            collision.transform.GetComponent<PlayerRespawn>().PlayerHitted();
        }
        
    }

}
