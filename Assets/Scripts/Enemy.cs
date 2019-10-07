using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Action<float> updateScore;
    private AIDestinationSetter _iaScript;

    [SerializeField] private float scoreValue;
    [SerializeField] private float _damage;
    [SerializeField] private float _hitInterval;

    public float damage
    {
        get => _damage;
    }

    public float hitInterval
    {
        get => _hitInterval;
    }
    
    private void Start()
    {
        _iaScript = GetComponent<AIDestinationSetter>();
        _iaScript.target = FindObjectOfType<Player>().transform;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            updateScore?.Invoke(scoreValue);
            Destroy(gameObject);
        }
    }
}
