using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SODefinitions;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Controls _controls;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _rotation;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationOffset;
    [SerializeField] private int magazines;
    [SerializeField] private Vector2 gunSlot;
    [SerializeField] private int maxWeaponsLenght;
    [SerializeField] private float throwForce;
    
    [SerializeField] private List<Weapon> weapons;

    [SerializeField] private Weapon _activeWeapon;
    private bool _canPick;
    private GameObject collectableWeapon;

    private void OnEnable()
    {
        _controls.PlayerControl.Enable();
    }

    private void OnDisable()
    {
        _controls.PlayerControl.Disable();
    }

    private void Awake()
    {
        weapons = new List<Weapon>(maxWeaponsLenght);
        _controls = new Controls();
        _rb = GetComponent<Rigidbody2D>();
        _controls.PlayerControl.Move.performed += ctx => move(ctx.ReadValue<Vector2>());
        _controls.PlayerControl.Move.canceled += ctx => move(ctx.ReadValue<Vector2>());
        _controls.PlayerControl.Aim.performed += ctx => aim(ctx.ReadValue<Vector2>());
        _controls.PlayerControl.Shoot.performed += _ => shooting();
        _controls.PlayerControl.Reload.performed += _ => reload();
        _controls.PlayerControl.ChangeWeapon.performed += _ => changeWeapon(_getFirstUnselectedSlot());
        _controls.PlayerControl.ChangeToMainWeapon.performed += _ => changeWeapon(0);
        _controls.PlayerControl.ChangeToSecondaryWeapon.performed += _ => changeWeapon(1);
        _controls.PlayerControl.CollectWeapon.performed += _ => pickWeapon();
    }

    private int _getFirstFreeSlot()
    {
        return weapons.FindIndex(item =>
        {
            if (item)
            {
                return item.name != _activeWeapon.name;
            }
            return item == null;
        });
    }

    private int _getFirstUnselectedSlot()
    {
        return weapons.FindIndex(item =>
        {
            if (item)
            {
                return item.name != _activeWeapon.name;
            }

            return false;
        });
    }

    private bool collectedWeapon(Weapon target)
    {
        return weapons.Find(item => { return item.name == target.name; });
    }
    private void move(Vector2 input)
    {
        _movement = input;
    }

    private void aim(Vector2 input)
    {
        _rotation = input;
    }

    private void shooting()
    {
        if (_activeWeapon)
        {
            GameObject bullet = Instantiate(_activeWeapon.bulletPrefab, _activeWeapon.shootPoint.position, _activeWeapon.shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_activeWeapon.shootPoint.up * _activeWeapon.bulletForce, ForceMode2D.Impulse);
        }
    }

    private void reload()
    {
        magazines--;
        _activeWeapon.reload();
    }

    private void changeWeapon(int slot)
    {
        if (weapons.Count > 1 && weapons[slot])
        {
            _activeWeapon.gameObject.SetActive(false);
            _activeWeapon = weapons[slot].GetComponent<Weapon>();
            activateWeapon(weapons[slot].gameObject);
        }
    }

    private void pickWeapon()
    {
        if (_canPick && !collectedWeapon(collectableWeapon.GetComponent<Weapon>()))
        {
            collectableWeapon.GetComponent<Collider2D>().enabled = false;
            int unselectedSlot = _getFirstFreeSlot();
            if (weapons.Count == maxWeaponsLenght)
            {
                var go = transform.GetChild(unselectedSlot);
                go.gameObject.SetActive(true);
                weapons.RemoveAt(unselectedSlot);
                go.SetParent(null);
                var position = transform.position;
                go.position = new Vector2(position.x, position.y + throwForce);
                go.GetComponent<Collider2D>().enabled = true;
            } 
            collectableWeapon.SetActive(false);
            weapons.Add(collectableWeapon.GetComponent<Weapon>());
            activateWeapon(collectableWeapon.gameObject);
            
            if (_activeWeapon == null)
            {
                _activeWeapon = weapons[0];
            }
            _canPick = false;
        }
    }

    private void activateWeapon(GameObject go)
    {
        go.SetActive(true);
        go.transform.SetParent(transform);
        go.transform.localPosition = gunSlot;
        go.transform.localRotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + Time.fixedDeltaTime * movementSpeed * _movement);
        Vector2 direction = _rotation - _rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationOffset;
        _rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _canPick = other.CompareTag("Weapon") ;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _canPick = !other.gameObject.CompareTag("Weapon");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_canPick)
        {
            collectableWeapon = other.gameObject;
        }
    }
}
