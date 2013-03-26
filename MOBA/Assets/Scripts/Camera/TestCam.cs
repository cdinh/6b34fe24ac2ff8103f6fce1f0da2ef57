using UnityEngine;
using System.Collections;

public class TestCam : MonoBehaviour {

    // Put this script on a GameObject with your camera and a character controller on it.
    public GameObject target;
    float sensitivityX = 10.0f;
    float sensitivityY = 10.0f;

    float minimumX = -360.0f;
    float maximumX = 360.0f;

    float minimumY = -60.0f;
    float maximumY = 25.0f;

    float minimumScroll = 16.0f;
    float maximumScroll = 20.0f;

    private float rotationY = 0.0f;
    private float rotationX = 0.0f;
    private float mouseScroll = 18.0f;
    private bool mouseDrag = false;
    private float mouseX;
    private float mouseY;
    private Vector2 mouseStartVector;
    private bool mouseDownStart = false;
    private bool mouseWasDown = false;
    private bool haveOverriden = false;

	// Use this for initialization
	void Start () {
	
	}
    
     
    void Update () 
    {

        transform.position = target.transform.position - target.transform.forward * target.transform.FindChild("DrawCall_8").renderer.bounds.size.x;
        transform.position += new Vector3(0, target.transform.FindChild("DrawCall_8").renderer.bounds.size.y, 0);
        

        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");

        mouseStartVector = new Vector2(mouseX,mouseY);
         
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
        
        


        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        target.transform.localEulerAngles = new Vector3(0, rotationX, 0);

        mouseScroll -= Input.GetAxis ("Mouse ScrollWheel");
        mouseScroll = Mathf.Clamp (mouseScroll, minimumScroll, maximumScroll);
        Camera cameraZoom = Camera.main;
        cameraZoom.fieldOfView = mouseScroll*20+50;
        
    }
}
