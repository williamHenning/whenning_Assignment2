using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public int numPickups = 11;
    public GameObject pickUp;
    public float radius = 5;

    // Start is called before the first frame update
    void Start()
    {
        float angle = 360f / (float)numPickups;             //Determines even spacing between each pickup
        Vector3 centerPos = new Vector3(0.0f, 1.5f, 0.0f);  //Centre of circle of pickups
        
        for (int i = 0; i < numPickups; i++)
        {           
            GameObject cube = Instantiate<GameObject>(pickUp);
            cube.name = "Pickup " + i;

            //Uses the RandomCircle function below to generate the position of each pick up object 
            Vector3 pos = RandomCircle(centerPos, radius, angle * i);
            cube.transform.position = pos;

            //Chooses a random colour to assign each pickup, colour determining points
            float val = Random.Range(1,5);
            if (val==4)
            {
                cube.GetComponent<Renderer>().material.color = Color.cyan;
            }
            else if (val==3)
            {
                cube.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else if (val==2)
            {
                cube.GetComponent<Renderer>().material.color = Color.grey;
            }
            else
            {
                cube.GetComponent<Renderer>().material.color = Color.magenta;
            } 
            
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius, float ang)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
