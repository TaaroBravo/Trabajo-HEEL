using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PieceConfig5 : PieceConfig
{
    public override Tuple<List<Tile>, bool> GetConfig(Tile tl)
    {
        List<Tile> tllist = new List<Tile>();
        // Configuracion que va a tener la pieza, en este caso va a formar una viborita
        tllist.Add(tl);
        tllist.Add(tl.right);
        tllist.Add(tl.bot.left);
        tllist.Add(tl.bot);
        return new Tuple<List<Tile>, bool>(tllist, true);
    }
}
