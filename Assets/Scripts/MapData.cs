using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class MapData
{
    public int width, height;
    public List<Vector3Int> cellPos;
    public List<string> tileName;
}
