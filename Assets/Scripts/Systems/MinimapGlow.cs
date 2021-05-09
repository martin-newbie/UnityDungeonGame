using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapGlow : MonoBehaviour
{
    private SpriteRenderer renderer;

    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            renderer.material.color = Color.yellow;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            renderer.material.color = Color.white;
            Debug.Log("exit");
        }
    }
}
