using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour //es parecido al de las rocas, permite que el bat cause daño al jugador cuando colisiona con él.
                                      //Al colisionar con el jugador, se llama a la función PlayerHitted() del script PlayerRespawn, que maneja la lógica de pérdida de vidas, animaciones, etc.
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
