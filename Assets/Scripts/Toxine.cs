using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toxine : MonoBehaviour {

    private float _speed;
    private Vector3 spawnPosition;
    private SpriteRenderer sprite;

    private IRotable _iRotable;
	
    void Start()
    {
        transform.position = spawnPosition;
        gameObject.layer = Layers.Toxine;
        _iRotable = new ToxineRotable(0.1f, transform);
    }

	void Update ()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
        _iRotable.Update();
    }

    public void Initialize()
    {
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

    public Toxine SetPosition(float x, float y)
    {
        spawnPosition = new Vector3(x, y);
        return this;
    }

    public Toxine SetSprite(SpriteRenderer s)
    {
        sprite = s;
        sprite.sortingOrder = OrderLayers.Toxine;
        return this;
    }
}
