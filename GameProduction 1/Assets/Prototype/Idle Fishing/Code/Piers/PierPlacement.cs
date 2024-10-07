using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierPlacement : MonoBehaviour
{

    [Header("Script reference")]
    public GameObject CurrencyScript;

    [Header("Piers")]
    public GameObject WoodenPier;


    [Header("misc")]
    public Camera GameCam;

    void Start()
    {
        
    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) 
        {
            if (hit.collider.tag == "NewPierBlock")
            {
                //Debug.Log("Buy new pier spot?");
                hit.transform.gameObject.GetComponent<Renderer>().material.SetFloat("_IsHovering", 1);
                
            }
            else{
                hit.transform.gameObject.GetComponent<Renderer>().material.SetInt("_IsHovering", 0);
            }
            
            
        }
    }
}
