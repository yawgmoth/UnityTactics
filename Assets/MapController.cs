using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    public UnitController[] units;
    public int width;
    public int height;
    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        units = new UnitController[width * height];
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public UnitController GetUnit(int x, int y)
    {
        return units[y * width + x];
    }

    public bool AddUnit(UnitController unit, int x, int y)
    {
        if (GetUnit(x, y) != null) return false;
        if (!IsLand(x, y)) return false;
        units[y * width + x] = unit;
        unit.transform.position = tilemap.CellToWorld(new Vector3Int(x, y)) + new Vector3(0.5f, 0.5f, 0) ;
        return true;
    }

    public bool MoveUnit(int from_x, int from_y, int to_x, int to_y)
    {
        UnitController unit = GetUnit(from_x, from_y);
        if (unit == null) return false;
        if (!AddUnit(unit, to_x, to_y)) return false;
        units[from_y * width + from_x] = null;
        return true;
    }

    public bool RemoveUnit(int x, int y)
    {
        if (units[y * width + x] == null) return false;
        units[y * width + x] = null;
        return true;
    }

    public bool IsLand(int x, int y)
    {
        TileBase tile = tilemap.GetTile(new Vector3Int(x, y));
        if (tile.name == "water_0") return false;
        return true;
    }
}
