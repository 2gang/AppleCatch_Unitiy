using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    GameObject director;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0.0f, z);
                /*transform.position = new Vector3(hit.point.x, 0.0f, hit.point.z);*/
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            this.director.GetComponent<GameDirector>().GetApple();
        }
        else if (other.gameObject.tag == "Bomb")
        {
            this.director.GetComponent<GameDirector>().GetBomb();
        }
        else
        {
            this.director.GetComponent<GameDirector>().GetBamsongi();
        }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        Destroy(other.gameObject);
    }
}

