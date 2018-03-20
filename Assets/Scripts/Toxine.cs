using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toxine : MonoBehaviour {

    private float _speed;
    private Vector3 spawnPosition;
    private SpriteRenderer sprite;

    private IRotable _iRotable;
    private Transform downCollider;
	
    void Start()
    {
        float x = Random.Range(downCollider.position.x - downCollider.GetComponent<Collider2D>().bounds.extents.x, downCollider.position.x + downCollider.GetComponent<Collider2D>().bounds.extents.x);
        float y = Random.Range(downCollider.position.y - downCollider.GetComponent<Collider2D>().bounds.extents.y, downCollider.position.y + downCollider.GetComponent<Collider2D>().bounds.extents.y);
        spawnPosition = new Vector2(x, y);
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

    public Toxine SetPosition()
    {
        transform.position = spawnPosition;
        return this;
    }

    public Toxine SetCollider(Transform trans)
    {
        downCollider = trans;
        return this;
    }

    public Toxine SetSprite(SpriteRenderer s)
    {
        sprite = s;
        sprite.sortingOrder = OrderLayers.Toxine;
        return this;
    }
}
