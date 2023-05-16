using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StructureModel : MonoBehaviour
{
    float yHeight = 0;
    bool isDestroyed=false;
    private float pollutionTime;
    private float revenueTime;
    private int pollution;
    private int revenue;
    private int cost;

    public void CreateModel(GameObject model,StructureData data,float yAxis)
    {
        
        if (data.name == "Windmill")
        {
            cost = data.cost;

            if (yAxis >= 5)
            {
                pollution=data.pollution*2;
                revenue=data.revenue*2;
                pollutionTime=data.pollutionTime;
                revenueTime=data.revenueTime;
            }
            else if (yAxis >= 7)
            {
                pollution = data.pollution * 3;
                revenue = data.revenue * 3;
                pollutionTime = data.pollutionTime;
                revenueTime = data.revenueTime;
            }
        }

        if (yAxis==2)
        {
            cost = data.cost;
            pollution = data.pollution / 2;
            revenue = data.revenue * 2;
            pollutionTime = data.pollutionTime;
            revenueTime = data.revenueTime;
        }
        else
        {
            cost = data.cost;
            pollution = data.pollution;
            revenue = data.revenue ;
            pollutionTime = data.pollutionTime;
            revenueTime = data.revenueTime;
        }

        StructureSystem();

        var structure = Instantiate(model,transform);
        yHeight = structure.transform.position.y;
    }
    public void CreateModelRoad(GameObject model)
    {
        var structure = Instantiate(model, transform);
        yHeight = structure.transform.position.y;
    }
    public void SwapModel(GameObject model,Quaternion rotation)
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        var structure = Instantiate(model, transform);
        structure.transform.localPosition = new Vector3(0, yHeight, 0);
        structure.transform.localRotation = rotation;
    }
    public List<Vector3> GetLocationsFor(int width,int height)
    {
        List<Vector3> positions = new List<Vector3>();

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                positions.Add(new Vector3((int)this.transform.position.x + i, yHeight, (int)this.transform.position.z + j));
              //  Debug.Log("Deleting Location is " + ((int)this.transform.position.x + i) + " " + ((int)this.transform.position.z + j));
            }
        }

        return positions;
    }
    private void StructureSystem()
    {
        MoneyController.Instance.setMoney(-cost);
        StartCoroutine(IncreaseMoney(revenueTime,revenue));
        StartCoroutine(IncreasePollution(pollutionTime,pollution));
    }
    IEnumerator IncreaseMoney(float revenueTime,int revenue)
    {
        while (!isDestroyed)
        {
            yield return new WaitForSeconds(revenueTime);
            MoneyController.Instance.setMoney(revenue);
        }
        yield return new WaitForSeconds(0f);
    }
    IEnumerator IncreasePollution(float pollutionTime, int pollution)
    {
        Debug.Log("pol:" + pollution);
        while (!isDestroyed)
        {
            yield return new WaitForSeconds(pollutionTime);
            MoneyController.Instance.setPollution(pollution);
        }
        yield return new WaitForSeconds(0f);
    }
    private void OnDestroy()
    {
        isDestroyed = true;
    }
}
