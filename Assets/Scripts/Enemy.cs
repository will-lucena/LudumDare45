using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AIDestinationSetter _iaScript;

    private void Start()
    {
        _iaScript = GetComponent<AIDestinationSetter>();
        _iaScript.target = FindObjectOfType<Player>().transform;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
