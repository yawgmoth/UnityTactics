using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Tilemap tilemap;
    public MapController map;

    public UnitController warrior_template;
    public GameObject selector;
    public UnitController selected;
    // Start is called before the first frame update
    void Start()
    {
        map = tilemap.gameObject.GetComponent<MapController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3Int GetClickCell()
    {
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        Vector3Int cell = tilemap.WorldToCell(mouseInWorld);
        return cell;
    }

    public void OnSelect()
    {
        Vector3Int cell = GetClickCell();
        TileBase tile = tilemap.GetTile(cell);
        
        UnitController unit = map.GetUnit(cell.x, cell.y);
        if (unit != null)
        {
            selector.transform.position = unit.transform.position;
            selected = unit;
        }
        else
        {
            UnitController new_unit = Instantiate(warrior_template);
            if (!map.AddUnit(new_unit, cell.x, cell.y))
            {
                Destroy(new_unit.gameObject);
            }
        }
    }

    public void OnMoveUnit()
    {
        if (selected == null) return;
        Vector3Int cell = GetClickCell();
        Vector3Int from_cell = tilemap.WorldToCell(selected.transform.position);
        if (!selected.CanMove(from_cell.x, from_cell.y, cell.x, cell.y)) return;
        map.MoveUnit(from_cell.x, from_cell.y, cell.x, cell.y);
        selector.transform.position = selected.transform.position;

    }
}
