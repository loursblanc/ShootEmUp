using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    [Range(0.001f, 20f)]public float firingRate = 1;
    public float firingRange = 5;
    public Transform[] emmiters;
    private int _current;

    private Collider2D _shipCollider2D;
    // Start is called before the first frame update

    private void Awake()
    {
        _shipCollider2D = transform.parent.GetComponent<Collider2D>();
    }


    private void Start()
    {
        //Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
        _current = (_current >= emmiters.Length - 1) ? 0 : _current + 1;
        //TODO : Use Object Pooling
        Vector3 position = emmiters[_current].TransformPoint(Vector3.up * 0.5f);
        GameObject projectileInstance = (GameObject) Instantiate(projectile, position, emmiters[_current].rotation);
        projectileInstance.GetComponent<Projectile>().range = firingRange;
        Physics2D.IgnoreCollision(_shipCollider2D, projectileInstance.GetComponent<Collider2D>());
    }
}
