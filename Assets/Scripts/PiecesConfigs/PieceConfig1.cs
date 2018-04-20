using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PieceConfig1 : PieceConfig{

    public override Tuple<List<Tile>, bool> GetConfig(Tile tl)
    {
        List<Tile> tllist = new List<Tile>();
        // Configuracion que va a tener la pieza, en este caso va a formar una T achatada
        tllist.Add(tl);
        tllist.Add(tl.left);
        tllist.Add(tl.right);
        tllist.Add(tl.bot);
        return new Tuple<List<Tile>, bool>(tllist, true);
    }
}
