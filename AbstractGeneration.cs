using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGeneration : MonoBehaviour
{
    [SerializeField]
    protected TileMapGeneration tilemapGenerator = null;
    [SerializeField]
    protected Vector2Int startPos = Vector2Int.zero;

    public void GenerateDungeon()
    {
        tilemapGenerator.Clear();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
