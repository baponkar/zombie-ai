using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    float offsetHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        offsetHeight = transform.position.y - player.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        newPosition.y = player.position.y + offsetHeight;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
