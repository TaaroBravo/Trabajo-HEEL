using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Manager : MonoBehaviour
{

    // Updateable Data ( cambia durante la ejecucion )
    TetrisPiece _currentpiece;
    float _timer;

    // Static Data ( no cambia durante la ejecucion )
    public GameObject TileGO;
    public float turntime;
    List<PieceConfig> _piecesconfig = new List<PieceConfig>();
    List<Tile> _alltiles = new List<Tile>();

    // Matrix
    public int Length;
    public int Width;
    List<Tile> X = new List<Tile>();
    List<List<Tile>> Y = new List<List<Tile>>();
    public List<Tile> StartingTiles = new List<Tile>();

    void Start()
    {
        CreateMatrix(); // Crea la matriz
        AddPiecesConfigs(); // Agrega las piezas k se vayan a usar en el nivel
        InstanceNewPiece(); // Instancia una pieza nueva random de entre las disponibles y posicion random dentro de las startingtiles
        UpdateMatrix(); // Actualiza visualmente la matriz
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.S)) Fall();
            if (Input.GetKeyDown(KeyCode.D)) _currentpiece.Move("right");
            if (Input.GetKeyDown(KeyCode.A)) _currentpiece.Move("left");
            if (Input.GetKeyDown(KeyCode.Q)) _currentpiece.Turn("left");
            if (Input.GetKeyDown(KeyCode.E)) _currentpiece.Turn("right");
            UpdateMatrix();
        }
        if (_timer > turntime) { _timer = 0; Fall(); UpdateMatrix(); }
    }
    void CreateMatrix()
    {
        for (int i = 0; i < Length; i++) // Instancia los tiles, les da posicion y nombre
        {
            X.Clear();
            for (int e = 0; e < Width; e++)
            {
                var obj = Instantiate(TileGO);
                obj.GetComponent<Tile>().initialize(new Vector3(i, e, 0), "Tile " + i + " " + e, e); // Le paso posicion, nombre e hilera
                X.Add(obj.GetComponent<Tile>());
            }
            _alltiles.AddRange(new List<Tile>(X));
            Y.Add(new List<Tile>(X));
        }
        for (int i = 0; i < Y.Count; i++) // Asignan los vecinos a los tiles ( top, bot, right, left ) y agarra los Tiles donde pueden spawnear las piezas nuevas
        {
            for (int e = 0; e < Y[i].Count; e++)
            {
                if (e != Y[i].Count - 1) Y[i][e].top = Y[i][e + 1];
                else if (i <= Y.Count - 3 && i >= 2) StartingTiles.Add(Y[i][e]);
                if (e != 0) Y[i][e].bot = Y[i][e - 1];
                if (i != Y.Count - 1) Y[i][e].right = Y[i + 1][e];
                if (i != 0) Y[i][e].left = Y[i - 1][e];
            }
        }
    }
    void AddPiecesConfigs()
    {
        _piecesconfig.Add(new PieceConfig1());
        _piecesconfig.Add(new PieceConfig2());
        _piecesconfig.Add(new PieceConfig3());
        _piecesconfig.Add(new PieceConfig4());
        _piecesconfig.Add(new PieceConfig5());
    }
    void UpdateMatrix()
    {
        for (int i = 0; i < _alltiles.Count; i++)
        {
            _alltiles[i].changestate();
        }
    }
    void InstanceNewPiece()
    {
        _currentpiece = new TetrisPiece(_piecesconfig[Random.Range(0, _piecesconfig.Count)].GetConfig((StartingTiles[Random.Range(0, StartingTiles.Count)])));
    }
    void Fall() // Chequea si la pieza colisiono moviendose para abajo
    {
        if (!_currentpiece.Move("bot"))
        {
            LowerRows(ClearFullRows());
            InstanceNewPiece();
        }
    }
    List<int> ClearFullRows() // interna de Fall - si se completo una row la borra
    {
        List<int> emptyrows = new List<int>();
        int counter = 0;
        for (int i = 0; i < X.Count; i++)
        {
            for (int e = 0; e < Y.Count; e++)
            {
                if (Y[e][i].occupied) counter++;
            }
            if (counter == Y.Count)
            {
                emptyrows.Add(i);
                for (int e = 0; e < Y.Count; e++)
                {
                    Y[e][i].occupied = false;
                }
            }
            counter = 0;
        }
        return emptyrows;
    }
    void LowerRows(List<int> rows) // interna de Fall - si se completo una row baja el resto de las rows
    {
        for (int r = 0; r < rows.Count; r++)
        {
            for (int i = 0; i < _alltiles.Count; i++)
            {
                if (_alltiles[i].row >= rows[r] && _alltiles[i].bot)
                {
                    if (_alltiles[i].occupied) _alltiles[i].bot.occupied = true;
                    _alltiles[i].occupied = false;
                }
            }
        }
    }
}
