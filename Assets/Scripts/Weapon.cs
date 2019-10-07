using System;
using System.Collections;
using System.Collections.Generic;
using SODefinitions;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private WeaponSO weaponInfo;
    [SerializeField] private LineRenderer sight;
    
    private SpriteRenderer _sprite;
    private int _maxAmmo;
    private int _currentAmmo;
    
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        sight = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        _sprite.sprite = weaponInfo.sprite;
        _bulletPrefab = weaponInfo.bulletPrefab;
        _maxAmmo = weaponInfo.maxAmmo;
        _currentAmmo = _maxAmmo;
        sight.enabled = false;
    }

    public GameObject bulletPrefab
    {
        get => _bulletPrefab;
    }

    public Transform shootPoint
    {
        get => _shootPoint;
    }

    public float bulletForce
    {
        get => weaponInfo.bulletForce;
    }

    public int currrentAmmo
    {
        get => _currentAmmo;
    }

    public void reload()
    {
        _currentAmmo = _maxAmmo;
    }

    //TODO: To change it to sprites
    public Color sprite
    {
        get => _sprite.color;
    }

    public void shoot()
    {
        _currentAmmo--;
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        var position = shootPoint.position;
        sight.SetPosition(0, position);
        sight.SetPosition(1, position + shootPoint.up * 100);
    }

    private void OnEnable()
    {
        sight.enabled = true;
    }

    private void OnDisable()
    {
        sight.enabled = false;
    }
}
