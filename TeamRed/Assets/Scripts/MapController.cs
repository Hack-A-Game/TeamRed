using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{

    public static MapController instance;
    public Cell[,] map;
    public Vector3 mapOrigin;
    public int _mapWidth = 7;
    public int _mapHeight = 11;
    private float _cellSpacing = 0.24f;

    void Awake()
    {
        _mapWidth = 7;
        _mapHeight = 11;
        if (instance == null)
        {
            instance = this;
        }
        GenerateMap();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateMap()
    {
        Camera.main.transform.position = new Vector3(0.73f, 1.15f, -10f);

        map = new Cell[_mapWidth, _mapHeight];

        for (int y = 0; y < _mapHeight; y++)
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                map[x, y] = SpawnCell(x, y);
            }
        }
    }

    Cell SpawnCell(int x, int y)
    {
        GameObject gameObject = Instantiate(Resources.Load("Cell") as GameObject);
        gameObject.transform.position = new Vector3(x * _cellSpacing, y * _cellSpacing, 0f);
        Cell cell = gameObject.GetComponent<Cell>();
        cell.SetPosition(x, y);
        return cell;
    }

    public List<Cell> GetContiguousCells(Cell cell)
    {
        List<Cell> contiguousCells = new List<Cell>();

        //Bottom Left
        if(cell.posX - 1 >= 0 && cell.posY - 1 >= 0)
        {
            contiguousCells.Add(map[cell.posX - 1, cell.posY - 1]);
        }

        //Bottom
        if (cell.posY - 1 >= 0)
        {
            contiguousCells.Add(map[cell.posX, cell.posY - 1]);
        }

        //Bottom Right
        if (cell.posX + 1 < _mapWidth && cell.posY - 1 >= 0)
        {
            contiguousCells.Add(map[cell.posX + 1, cell.posY - 1]);
        }

        // Left
        if (cell.posX - 1 >= 0)
        {
            contiguousCells.Add(map[cell.posX - 1, cell.posY]);
        }

        // Right
        if (cell.posX + 1 < _mapWidth)
        {
            contiguousCells.Add(map[cell.posX + 1, cell.posY]);
        }

        //Top Left
        if (cell.posX - 1 >= 0 && cell.posY + 1 < _mapHeight)
        {
            contiguousCells.Add(map[cell.posX - 1, cell.posY + 1]);
        }

        //Top
        if (cell.posY + 1 < _mapHeight)
        {
            contiguousCells.Add(map[cell.posX, cell.posY + 1]);
        }

        //Top Right
        if (cell.posX + 1 < _mapWidth && cell.posY + 1 < _mapHeight)
        {
            contiguousCells.Add(map[cell.posX + 1, cell.posY + 1]);
        }

        return contiguousCells;
    }


}