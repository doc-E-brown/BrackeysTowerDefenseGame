using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float heightThreshold = 10f;
    public float widthThreshold = 10f;
    
    [Header("Position Limits")]
    public float minX = 10f;
    public float maxX = 80f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minZ = -100f;
    public float maxZ = 0f;
    

    // Update is called once per frame
    void Update()
    {

        if (GameManager.isGameOver())
        {
            this.enabled = false;
            return;
        }

        float panBorderHeight = Screen.height / heightThreshold;
        float panBorderWidth = Screen.width / widthThreshold;
        
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderHeight)
        {
            if (transform.position.z < maxZ)
            {
            transform.Translate(Vector3.forward * (panSpeed * Time.deltaTime), Space.World);
                
            }
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderHeight)
        {
            if (transform.position.z > minZ)
            {
                transform.Translate(Vector3.back * (panSpeed * Time.deltaTime), Space.World);
            }
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderWidth)
        {

            if (transform.position.x < maxX)
            {
                transform.Translate(Vector3.right * (panSpeed * Time.deltaTime), Space.World);
            }
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderWidth)
        {
            if (transform.position.x > minX)
            {
                transform.Translate(Vector3.left * (panSpeed * Time.deltaTime), Space.World);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * 1000 * Time.deltaTime;
        pos.y = Math.Clamp(pos.y, minY, maxY);
        transform.position = pos;


    }
}
