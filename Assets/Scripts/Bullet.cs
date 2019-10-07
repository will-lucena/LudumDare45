using System;
using System.Collections;
using System.Collections.Generic;
using SODefinitions;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO bulletInfo;
    private bool _destroyOnFirst;
    private GameObject _hitVfx;

    private void Awake()
    {
        _destroyOnFirst = bulletInfo.destroyOnFirstHit;
        _hitVfx = bulletInfo.vfx;
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GameRoom"))
        {
            Destroy(gameObject);
        }
        else if (!other.gameObject.CompareTag("Player"))
        {
            if (_hitVfx)
            {
                GameObject vfx = Instantiate(_hitVfx, transform.position, Quaternion.identity);
                Destroy(vfx, 5f);
            }

            if (_destroyOnFirst)
            {
                Destroy(gameObject);
            }
        }
    }
}
