using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum TYPE { RepairKit, ExtraLife};
    public TYPE type;

    private AudioSource audioSrc;
    private Renderer _renderer;
    private Collider2D _collider2d;



    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        _renderer = GetComponent<Renderer>();
        _collider2d = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
            return;

        switch (type)
        {
            case TYPE.RepairKit:
                GameManager.Damage = 0;
                break;
            case TYPE.ExtraLife:
                GameManager.Lives++;
                break;
            default:
                break;
        }

        StartCoroutine(PickUp());
    }

    private IEnumerator PickUp()
    {
        _collider2d.enabled = false;
        _renderer.enabled = false;
        audioSrc.Play();
        yield return new WaitForSeconds(audioSrc.clip.length);
        // TODO : Use Object pooling!
        Destroy(gameObject);
    }
}
