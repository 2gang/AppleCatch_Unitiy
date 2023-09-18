using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    public GameObject bamsongiPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 3;
    double speed = -0.03;
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= this.ratio)
            {
                item = Instantiate(bamsongiPrefab) as GameObject;
            }
            else if ((dice > this.ratio) && (dice <= (this.ratio * 2)+2))
            {
                item = Instantiate(applePrefab) as GameObject;
            }
            else
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
        }
    }
}

