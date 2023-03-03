using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    [SerializeField] GameObject ground;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for(int a = 0; a < _width; a++)
        {
            for (int b = 0; b < _height; b++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(a, 0, b), Quaternion.identity);
                spawnedTile.transform.Rotate(90, 0, 0);
                spawnedTile.name = $"Tile {a}, {b}";
            }
        }

        _cam.transform.position = new Vector3(((float) _width / 2) - 0.5f, (float) (_height / 2) -3f, 0);
    }
}   
