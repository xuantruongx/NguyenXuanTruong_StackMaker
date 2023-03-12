using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GetData : MonoBehaviour
{
    [SerializeField] private string jsonFileName;
    [SerializeField] private int width, height;
    [SerializeField] private List<Vector3Int> tilePos;
    [SerializeField] private List<string> tileName;
    [SerializeField] private GameObject brick, unbrick, start, checkpoint, wall;

    void Start()
    {
        GetDataFromJson();
        DrawMap();
    }

    private void GetDataFromJson()
    {
        Debug.Log(jsonFileName);
        string json = File.ReadAllText(jsonFileName);
        MapData mapData = JsonUtility.FromJson<MapData>(json);
        width = mapData.width;
        height = mapData.height;
        tilePos = mapData.cellPos;
        tileName = mapData.tileName;

    }

    private void GenerateGrid(GameObject prefab, int x, int z)
    {
        Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity);
    }

    private void DrawMap()
    {
        for (int i = 0; i < tileName.Count; i++)
        {
            switch (tileName[i])
            {
                case "start":
                    Debug.Log("start" + tilePos[i]);
                    GenerateGrid(start, tilePos[i].x, tilePos[i].y);
                    break;
                case "brick":
                    Debug.Log("brick" + tilePos[i]);
                    GenerateGrid(brick, tilePos[i].x, tilePos[i].y);

                    break;
                case "unbrick":
                    Debug.Log("unbrick" + tilePos[i]);
                    GenerateGrid(unbrick, tilePos[i].x, tilePos[i].y);

                    break;
                case "wall":
                    Debug.Log("wall" + tilePos[i]);
                    GenerateGrid(wall, tilePos[i].x, tilePos[i].y);

                    break;
                case "checkpoint":
                    Debug.Log("checkpoint" + tilePos[i]);
                    GenerateGrid(checkpoint, tilePos[i].x, tilePos[i].y);

                    break;
            }
        }
    }
}