using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileList
{
    public int player;
    public List<int> tiles;

    public TileList()
    {
        player = 0;
        tiles = new List<int>();
    }

    public bool PrintList()
    {
        foreach (var tile in tiles)
        {
            Debug.Log(player + ": " + tile);
        }
        return true;
    }
}

public class P1List : TileList
{
    public P1List()
    {
        player = 1;
    }
}

public class P2List : TileList
{
    public P2List()
    {
        player = 1;
    }
}