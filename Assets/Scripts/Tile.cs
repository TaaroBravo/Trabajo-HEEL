using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int row;
    public bool occupied;
    public Tile bot;
    public Tile top;
    public Tile left;
    public Tile right;

    public void initialize(Vector3 position, string name, int r)
    {
        transform.position = position;
        this.name = name;
        row = r;
    }
    public void changestate() // Funcion que updatea el color de la tile dependiendo su estado ( ocupada / libre )
    {
        GetComponent<SpriteRenderer>().color = occupied? new Color(0, 0, 255) : new Color(0, 0, 0);
    }
}
