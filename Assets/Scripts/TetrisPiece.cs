using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPiece : MonoBehaviour {

    public List<Tile> occupiedtiles = new List<Tile>(); // el indice 0 es la PivotTile para girar
    public bool canrotate;
    // Builder
    public TetrisPiece(Tuple<List<Tile>, bool> data)
    {
        occupiedtiles = data.Item1;
        for (int i = 0; i < occupiedtiles.Count; i++)
        {
            occupiedtiles[i].occupied = true;
        }
        canrotate = data.Item2;
    }
    // Gira la pieza
    public void Turn(string dir)
    {
        int requiredchecks = 0;
        for (int i = 1; i < occupiedtiles.Count; i++) // Se fija que el movimiento sea posible
        {
            if (CheckToTurn(occupiedtiles[i], occupiedtiles[0], dir) && canrotate)
            {
                if (!CheckToTurn(occupiedtiles[i], occupiedtiles[0], dir).occupied ||
                    CheckToTurn(occupiedtiles[i], occupiedtiles[0], dir).occupied &&
                    occupiedtiles.Contains(CheckToTurn(occupiedtiles[i], occupiedtiles[0], dir)))
                    requiredchecks++;
            }
        }
        if (requiredchecks == occupiedtiles.Count - 1) // Si es posible mueve la pieza
        {
            for (int i = 1; i < occupiedtiles.Count; i++)
            {
                occupiedtiles[i].occupied = false;
            }
            for (int i = 1; i < occupiedtiles.Count; i++)
            {
                occupiedtiles[i] = CheckToTurn(occupiedtiles[i], occupiedtiles[0], dir);
                occupiedtiles[i].occupied = true;
            }
        }
    }
    // Mueve la pieza
    public bool Move(string dir)
    {
        int requiredchecks = 0;
        for (int i = 0; i < occupiedtiles.Count; i++) // Se fija que el movimiento sea posible
        {
            if (GetDirection(occupiedtiles[i], dir))
            {
                if (!GetDirection(occupiedtiles[i], dir).occupied ||
                    GetDirection(occupiedtiles[i], dir).occupied &&
                    occupiedtiles.Contains(GetDirection(occupiedtiles[i], dir)))
                    requiredchecks++;
            }
        }
        if (requiredchecks == occupiedtiles.Count) // Si es posible mueve la pieza
        {
            for (int i = 0; i < occupiedtiles.Count; i++)
            {
                occupiedtiles[i].occupied = false;
            }
            for (int i = 0; i < occupiedtiles.Count; i++)
            {
                occupiedtiles[i] = GetDirection(occupiedtiles[i], dir);
                occupiedtiles[i].occupied = true;
            }
            return true;
        }
        return false;
    }
    // Consigue la tiles a chequear dependiendo la direccion para Move
    Tile GetDirection(Tile tl, string dir)
    {
        switch (dir)
        {
            case "bot":
                return tl.bot;
            case "left":
                return tl.left;
            case "right":
                return tl.right;
        }
        return tl;
    }
    // Consigue la tiles a chequear dependiendo la direccion para Turn 
    // ( esto es lo mas "cabeza" pero como no existe el rotate para la pieza mepa k hay k hacerlo a mano )
    Tile CheckToTurn(Tile tl, Tile pivot, string dir)
    {
        try
        {
            if (tl == pivot.left) if (dir == "right") return pivot.top; else return pivot.bot;
            if (tl == pivot.bot) if (dir == "right") return pivot.left; else return pivot.right;
            if (tl == pivot.top) if (dir == "right") return pivot.right; else return pivot.left;
            if (tl == pivot.right) if (dir == "right") return pivot.bot; else return pivot.top;
            if (tl == pivot.left.left) if (dir == "right") return pivot.top.top; else return pivot.bot.bot;
            if (tl == pivot.bot.bot) if (dir == "right") return pivot.left.left; else return pivot.right.right;
            if (tl == pivot.top.top) if (dir == "right") return pivot.right.right; else return pivot.left.left;
            if (tl == pivot.right.right) if (dir == "right") return pivot.bot.bot; else return pivot.top.top;
            if (tl == pivot.bot.right) if (dir == "right") return pivot.bot.left; else return pivot.top.right;
            if (tl == pivot.bot.left) if (dir == "right") return pivot.top.left; else return pivot.bot.right;
            if (tl == pivot.top.right) if (dir == "right") return pivot.bot.right; else return pivot.top.left;
            if (tl == pivot.top.left) if (dir == "right") return pivot.top.right; else return pivot.bot.left;
        }
        catch
        {
        }
        return tl;
    }
}
