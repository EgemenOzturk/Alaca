using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    [SerializeField]
    private float previewYOffset = 0.006f;

    [Space(10)]

    [Header("CONTROLLERS")]

    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private StructureManager structureManager;

    [Space(10)]

    [SerializeField]
    private GameObject mouseIndicator;
    [SerializeField]
    private GameObject previewObject2;

    [Space(10)]
    [SerializeField]
    private Material previewMaterialsPrefab;
    private Material previewMaterialInstance;

    private GameObject previewObject;
    private int area = 0;
    private bool isCoalFactory = false;
    Vector3Int? mousePosition;


    private void Start()
    {
        previewObject = previewObject2;
        previewMaterialInstance = new Material(previewMaterialsPrefab);
    }
    private void Update()
    {
        mousePosition = inputManager.RaycastGr();
        mouseIndicator.transform.position = (Vector3)mousePosition;
        Vector3 _position = (Vector3)mousePosition;
        if(previewObject != null)
            previewObject.transform.position = (Vector3)mousePosition;

        if (area == 1 || area == 0)
        {
            previewObject.transform.position = new Vector3(_position.x, _position.y, _position.z);
        }
        else if (area == 2 )
        {
            previewObject.transform.position = new Vector3(_position.x + 0.5f, _position.y, _position.z + 0.5f);
        }
        else if (area == 4 && !isCoalFactory)
        {
            previewObject.transform.position = new Vector3(_position.x + 1.5f, _position.y, _position.z + 1.5f);
        }
        else if (area == 6)
        {
            previewObject.transform.position = new Vector3(_position.x + 3f, _position.y+0.25f, _position.z + 3.5f);
        }
        if (isCoalFactory)
        {
            previewObject.transform.position = new Vector3(_position.x + 2.1f, _position.y, _position.z + 1.5f);
        }

    }
    public void StartShowingPlacementPreview(GameObject prefab, int _area, bool isCoal = false)
    {
        isCoalFactory = isCoal;
        area = _area;
        Vector3Int? newPos = inputManager.RaycastGr();
        previewObject = Instantiate(prefab);
        previewObject.transform.localPosition = (Vector3)newPos;
        PreparePreview(previewObject);
    }

    private void PreparePreview(GameObject previewObject)
    {
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = previewMaterialInstance;
            }
            renderer.materials = materials;
        }
        UpdatePosition(previewObject.transform.position, structureManager.GetIsBuildable());
    }
    public void StopShowingPreview()
    {
        Destroy(this.previewObject);
        previewObject = previewObject2;
    }
    public void UpdatePosition(Vector3 position, bool validity)
    {
        MovePreview(position);
        ApplyFeedback(validity);
    }

    private void ApplyFeedback(bool validity)
    {
        Color c = validity ? Color.white : Color.green;
        c.a = 0.5f;
        previewMaterialInstance.color = c;
    }

    private void MovePreview(Vector3 position)
    {
        previewObject.transform.position = new Vector3(position.x, position.y + previewYOffset, position.z);
    }
}
