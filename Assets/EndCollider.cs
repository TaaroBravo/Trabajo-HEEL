using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.Toxine)
        {
            ToxineManager.Instance.ReturnToxineToPool(collision.GetComponent<Toxine>());
        }
    }
}
