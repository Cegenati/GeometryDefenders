using UnityEngine;

public class CameraController : MonoBehaviour
{


    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey("w"))
        {   
            transform.Translate(Vector3.forward*panSpeed*Time.deltaTime, Space.World); //Essentially a unit vector in the forward direction
        }   
        if (Input.GetKey("s"))
        {   
            transform.Translate(Vector3.back*panSpeed*Time.deltaTime, Space.World); //Essentially a unit vector in the forward direction
        }     
        if (Input.GetKey("d"))
        {   
            transform.Translate(Vector3.right*panSpeed*Time.deltaTime, Space.World); //Essentially a unit vector in the forward direction
        }    
        if (Input.GetKey("a"))
        {   
            transform.Translate(Vector3.left*panSpeed*Time.deltaTime, Space.World); //Essentially a unit vector in the forward direction
        }    

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY); //Stops camera from zooming through the floor or really far out of the screen
        transform.position = pos;

    }
}
