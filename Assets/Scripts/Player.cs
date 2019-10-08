using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SODefinitions;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public Action<int> updateMagazinesHud;
    public Action<int> updateAmmoHud;
    public Action<int> updateSelectedWeapon;
    [FormerlySerializedAs("updatedWeaponBag")] public Action<Color> updateWeaponBag;
    public Action<int> updateAmountOfWeapons;
    public Action deathPerAmmo;
    public Action deathPerHealth;
    public Action<float> updateHealthValue;

    private Controls _controls;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _rotation;
    private bool _canPick;
    private GameObject collectableWeapon;
    private float _lastHitTaken;
    
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationOffset;
    [SerializeField] private int magazines;
    [SerializeField] private Vector2 gunSlot;
    [SerializeField] private int maxWeaponsLenght;
    [SerializeField] private float throwForce;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Weapon _activeWeapon;

    
    private void OnEnable()
    {
        subscription();
        _controls.PlayerControl.Enable();
    }

    private void OnDisable()
    {
        _controls.PlayerControl.Disable();
        unsubscription();
    }

    private void subscription()
    {
        _controls.PlayerControl.Move.performed += ctx => move(ctx.ReadValue<Vector2>());
        _controls.PlayerControl.Move.canceled += ctx => move(ctx.ReadValue<Vector2>());
        _controls.PlayerControl.Aim.performed += ctx => aim(Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));
        _controls.PlayerControl.Shoot.performed += _ => shooting();
        _controls.PlayerControl.Reload.performed += _ => reload();
        _controls.PlayerControl.ChangeWeapon.performed += _ => changeWeapon(_getFirstUnselectedSlot());
        _controls.PlayerControl.ChangeToMainWeapon.performed += _ => changeWeapon(0);
        _controls.PlayerControl.ChangeToSecondaryWeapon.performed += _ => changeWeapon(1);
        _controls.PlayerControl.CollectWeapon.performed += _ => pickWeapon();
    }
    
    private void unsubscription()
    {
        _controls.PlayerControl.Move.performed -= ctx => move(ctx.ReadValue<Vector2>());
        _controls.PlayerControl.Move.canceled -= ctx => move(ctx.ReadValue<Vector2>());
        _controls.PlayerControl.Aim.performed -= ctx => aim(Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));
        _controls.PlayerControl.Shoot.performed -= _ => shooting();
        _controls.PlayerControl.Reload.performed -= _ => reload();
        _controls.PlayerControl.ChangeWeapon.performed -= _ => changeWeapon(_getFirstUnselectedSlot());
        _controls.PlayerControl.ChangeToMainWeapon.performed -= _ => changeWeapon(0);
        _controls.PlayerControl.ChangeToSecondaryWeapon.performed -= _ => changeWeapon(1);
        _controls.PlayerControl.CollectWeapon.performed -= _ => pickWeapon();
    }

    private void Awake()
    {
        weapons = new List<Weapon>(maxWeaponsLenght);
        _controls = new Controls();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (_activeWeapon)
        {
            updateAmmoHud?.Invoke(_activeWeapon.currrentAmmo);
        }
        updateMagazinesHud?.Invoke(magazines);
        currentHealth = maxHealth;
    }

    private void takeHit(float value)
    {
        currentHealth -= value;
        updateHealthValue?.Invoke(currentHealth);

        if (currentHealth < 0)
        {
            deathPerHealth?.Invoke();
            enabled = false;
        }
    }
    
    private int totalAmmoLeft()
    {
        int total = 0;

        total = weapons.Sum(item => item.currrentAmmo);
        total += (magazines * _activeWeapon.maxAmmo);
        return total;
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
            if (_activeWeapon.currrentAmmo > 0)
            {
                _activeWeapon.shoot();
                updateAmmoHud?.Invoke(_activeWeapon.currrentAmmo);
            }
            else
            {
                if (totalAmmoLeft() == 0)
                {
                    deathPerAmmo?.Invoke();
                    enabled = false;
                }
            }
        } 
    }

    private void reload()
    {
        if (magazines > 0)
        {
            magazines--;
            _activeWeapon.reload();
            updateMagazinesHud?.Invoke(magazines);
            updateAmmoHud?.Invoke(_activeWeapon.currrentAmmo);
        }
    }

    private void changeWeapon(int slot)
    {
        if (weapons.Count > 1 && weapons[slot])
        {
            _activeWeapon.gameObject.SetActive(false);
            _activeWeapon = weapons[slot].GetComponent<Weapon>();
            activateWeapon(weapons[slot].gameObject);
            updateAmmoHud?.Invoke(_activeWeapon.currrentAmmo);
            updateSelectedWeapon?.Invoke(slot);
        }
    }

    private void pickWeapon()
    {
        if (_canPick)
        {
            if (!collectableWeapon.GetComponent<Weapon>())
            {
                magazines++;
                updateMagazinesHud?.Invoke(magazines);
                Destroy(collectableWeapon);
            }
            if (!collectedWeapon(collectableWeapon.GetComponent<Weapon>()))
            {
                collectableWeapon.GetComponent<Collider2D>().enabled = false;
                int unselectedSlot = _getFirstFreeSlot();
                if (weapons.Count == maxWeaponsLenght)
                {
                    var go = transform.GetChild(unselectedSlot);
                    go.gameObject.SetActive(false);
                    weapons.RemoveAt(unselectedSlot);
                    go.SetParent(null);
                    var position = transform.position;
                    go.position = new Vector2(position.x, position.y + throwForce);
                    go.GetComponent<Collider2D>().enabled = true;
                } 
                collectableWeapon.SetActive(false);
                weapons.Add(collectableWeapon.GetComponent<Weapon>());
                updateAmountOfWeapons?.Invoke(weapons.Count);
                activateWeapon(collectableWeapon.gameObject);
                updateWeaponBag?.Invoke(collectableWeapon.GetComponent<Weapon>().sprite);
            
                if (_activeWeapon == null)
                {
                    _activeWeapon = weapons[0];
                    updateAmmoHud?.Invoke(_activeWeapon.currrentAmmo);
                }
                else
                {
                    collectableWeapon.SetActive(false);
                }
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
        float angle;
#if UNITY_EDITOR || UNITY_STANDALONE
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationOffset;
#else
        angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg - rotationOffset;
#endif
        
        _rb.rotation = angle;

        _lastHitTaken += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _canPick = other.CompareTag("Weapon") || other.CompareTag("Magazine");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _canPick = !other.gameObject.CompareTag("Weapon") || !other.CompareTag("Magazine");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_canPick)
        {
            collectableWeapon = other.gameObject;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            takeHit(other.gameObject.GetComponent<Enemy>().damage);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyScript = other.gameObject.GetComponent<Enemy>();

            if (_lastHitTaken > enemyScript.hitInterval)
            {
                takeHit(enemyScript.damage);
                _lastHitTaken = 0;
            }
        }
    }
}
