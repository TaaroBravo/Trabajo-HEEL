using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrainsController : MonoBehaviour {

    private static ContrainsController _instance;
    public static ContrainsController Instance
    {
        get
        {
            return _instance;
        }
    }

    public static float verticalSize;
    public static float horizontalSize;

    float buffer = 1f;

	void Start ()
    {
        _instance = this;
        verticalSize = Camera.main.orthographicSize;
        horizontalSize = Screen.width * verticalSize / Screen.height;
    }

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        if (!onScreen)
            OutOfScreen();
    }

    public void OutOfScreen()
    {
        if (transform.position.y > verticalSize + buffer)
        {
            if (gameObject.layer == Layers.Toxine)
            {
                ToxineManager.Instance.ReturnToxineToPool(GetComponent<Toxine>());
            }
        }
    }
}
