﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxineManager : MonoBehaviour {

    public Toxine toxinePrefab;
    public Transform downCollider;
    public int numberToxines;
    private Pool<Toxine> _toxinePool;

    private static ToxineManager _instance;
    public static ToxineManager Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
        _toxinePool = new Pool<Toxine>(numberToxines, BulletFactory, Toxine.InitializeBullet, Toxine.DisposeBullet, true);
        for (int i = numberToxines; i > 0; i--)
        {
            _toxinePool.GetObjectFromPool().SetSpeed(1f).SetPosition(Random.Range(downCollider.position.x - downCollider.GetComponent<Collider2D>().bounds.extents.x, downCollider.position.x + downCollider.GetComponent<Collider2D>().bounds.extents.x), Random.Range(downCollider.position.y - downCollider.GetComponent<Collider2D>().bounds.extents.y, downCollider.position.y + downCollider.GetComponent<Collider2D>().bounds.extents.y)).SetSprite(toxinePrefab.GetComponent<SpriteRenderer>());
        }
    }

    private Toxine BulletFactory()
    {
        return Instantiate<Toxine>(toxinePrefab);
    }

    public void ReturnBulletToPool(Toxine toxine)
    {
        _toxinePool.DisablePoolObject(toxine);
    }
}