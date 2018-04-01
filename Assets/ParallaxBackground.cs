using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

    //Debería ser una variable estática que también cambie la velocidad de las toxinas.
    private float levelSpeed;

    private float _verticalSize;

    private List<GameObject> backgroundParts = new List<GameObject>();
    private List<Vector3> bgPositions = new List<Vector3>();

    public Vector3 offset;
    public float positionY;

	void Start ()
    {
        _verticalSize = Camera.main.orthographicSize;
        InstantiateBackground();
        //backgroundParts.Add(GameObject.Find("BG"));
        //backgroundParts.Add(GameObject.Find("BG (1)"));
    }

	void Update ()
    {
        levelSpeed = VelocityManager.GetGameVelocity();

        backgroundParts[0].transform.position += Vector3.down * levelSpeed * Time.deltaTime;
        backgroundParts[1].transform.position += Vector3.down * levelSpeed * Time.deltaTime;

        if (backgroundParts[0].transform.position.y + backgroundParts[0].GetComponent<SpriteRenderer>().bounds.size.y / 2 <= -_verticalSize)
        {
            backgroundParts[0].transform.position = backgroundParts[1].transform.position + Vector3.up * backgroundParts[1].GetComponent<SpriteRenderer>().bounds.size.y + offset;
        }

        if (backgroundParts[1].transform.position.y + backgroundParts[1].GetComponent<SpriteRenderer>().bounds.size.y / 2 <= -_verticalSize)
        {
            backgroundParts[1].transform.position = backgroundParts[0].transform.position + Vector3.up * backgroundParts[0].GetComponent<SpriteRenderer>().bounds.size.y + offset;
        }

    }

    void InstantiateBackground()
    {
        bgPositions.Add(Vector3.zero);
        bgPositions.Add(new Vector3(0, positionY, 0));
        for (int i = 0; i < 2; i++)
        {
            GameObject bg = Instantiate((GameObject)LoadResources.Instance.resourcesTable.GetValue("Background/BG " + Random.Range(0, 2)));
            bg.transform.position = bgPositions[i];
            backgroundParts.Add(bg);
        }
    }
}
