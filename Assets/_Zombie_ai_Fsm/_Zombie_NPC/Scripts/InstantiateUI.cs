using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUI : MonoBehaviour
{
    public GameObject UIPrefab;
    // Start is called before the first frame update
    void Start()
    {
        var prefab = Instantiate(UIPrefab);
        prefab.transform.SetParent(transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
