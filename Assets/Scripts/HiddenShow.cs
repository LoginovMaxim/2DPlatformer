using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenShow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
            GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
            GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, 1f);
    }
}
