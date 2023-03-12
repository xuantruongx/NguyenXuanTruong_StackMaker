using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SaveMapDataToJson : MonoBehaviour
{
    [SerializeField] private MapData data = new MapData();
    [SerializeField] private Tilemap map;

    void Start()
    {
        data.cellPos = new List<Vector3Int>();
        data.tileName = new List<string>();
        map.CompressBounds();
        data.width = map.size.x;
        data.height = map.size.y;
        foreach (Vector3Int cellPos in map.cellBounds.allPositionsWithin)
        {
            TileBase tile = map.GetTile(cellPos);
            if (tile != null)
            {
                data.cellPos.Add(cellPos);
                data.tileName.Add(tile.name);
            }
        }
        string json = JsonUtility.ToJson(data);
        File.WriteAllText("tilemap_data.json", json);
        if (File.Exists("tilemap_data.json"))
            Debug.Log(Application.persistentDataPath);
    }
}
