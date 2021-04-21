using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamage : MonoBehaviour
{
    public float vulnerability = 1;
    //private float _damage;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    public float Damage
    {
        get
        {
            return GameManager.Damage;
        }

        set
        {
            GameManager.Damage = value;
        }
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    // public void ApplyDamage(float damage)
    //{
    //   Damage += damage;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float damage = collision.relativeVelocity.magnitude * vulnerability;
        //if (collision.gameObject.tag == "Asteroid")
        if (collision.collider.sharedMaterial)
        {
            damage *= (1 / collision.collider.sharedMaterial.bounciness) * (1 / _collider2D.sharedMaterial.bounciness) * _collider2D.sharedMaterial.friction;
        }
        if (collision.rigidbody)
        {
            damage *= (collision.rigidbody.mass / _rigidbody2D.mass);
        }
        Damage += damage;
    }
    
}

