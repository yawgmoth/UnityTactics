using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public int hp;
    public int owner;
    public int mp;
    public int max_mp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnStartTurn()
    {
        mp = max_mp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanMove(int from_x, int from_y, int to_x, int to_y)
    {
        float distance = Mathf.Abs(from_x - to_x) + Mathf.Abs(from_y - to_y);
        return distance < mp;
    }
}
