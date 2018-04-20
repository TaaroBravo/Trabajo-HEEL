using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PieceConfig // Es basicamente una interface para que las config compartan clase y poder hacer una lista en el Manager
{
    virtual public Tuple<List<Tile>, bool> GetConfig(Tile tl)
    {
        List<Tile> example = new List<Tile>();
        return new Tuple<List<Tile>, bool>(example, true);
    }
}
