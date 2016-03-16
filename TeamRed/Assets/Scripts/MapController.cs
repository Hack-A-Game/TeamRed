using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour {

    public MapController instance;
    public Cell[, ] map;
    public Vector3 mapOrigin;
    private int _mapWidth = 7;
    private int _mapHeight = 11;
    private float _cellSpacing = 0.5f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        GenerateMap();
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	}
    
    void GenerateMap()
    {
        map = new Cell[_mapWidth, _mapHeight];

        for (int y = 0; y < _mapHeight; y++)
        {
            for(int x = 0; x < _mapWidth; x++)
            {
                map[x, y] = SpawnCell(x, y);       
            }
        }
    }

    Cell SpawnCell(int x, int y)
    {
        GameObject gameObject = Instantiate(Resources.Load("Cell") as GameObject);
        gameObject.transform.position = new Vector3(x * _cellSpacing, y * _cellSpacing, -9.5f);
        Cell cell = gameObject.GetComponent<Cell>();
        cell.SetPosition(x, y);
        return cell;
    }
   
}
