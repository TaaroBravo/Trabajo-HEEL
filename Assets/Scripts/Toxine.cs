using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toxine : MonoBehaviour {

    private float _speed;
    private Vector3 spawnPosition;
    private SpriteRenderer sprite;

	void Update ()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
    }

    public void Initialize()
    {
        transform.position = spawnPosition;
        gameObject.layer = Layers.Toxine;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public static void InitializeBullet(Toxine toxineObj)
    {
        toxineObj.gameObject.SetActive(true);
        toxineObj.Initialize();
    }

    public static void DisposeBullet(Toxine toxineObj)
    {
        toxineObj.gameObject.SetActive(false);
    }

    public Toxine SetSpeed(float s)
    {
        _speed = s;
        return this;
    }

    public Toxine SetPosition()
    {
        transform.position = spawnPosition;
        return this;
    }

    public Toxine SetSprite(SpriteRenderer s)
    {
        sprite = s;
        sprite.sortingOrder = OrderLayers.Toxine;
        return this;
    }
}
