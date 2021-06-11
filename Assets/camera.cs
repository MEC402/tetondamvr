using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
	//
	// VARIABLES
	//

	public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 4.0f;       // Speed of the camera when being panned
	public float zoomSpeed = 4.0f;      // Speed of the camera going back and forth

	private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
	private bool isPanning;     // Is the camera being panned?
	private bool isRotating;    // Is the camera being rotated?
	private bool isZooming;     // Is the camera zooming?

	private Camera cam;
	public float move_speed = 1f;
	private float rotation_speed = 2f;
	//
	// UPDATE
	//

	void Start()
    {
		cam = Camera.main;
    }

    void Update()
	{


		if (Input.GetKey(KeyCode.W))
        {
			cam.transform.Translate(new Vector3(0, 0, 1 * move_speed));
        }

		if (Input.GetKey(KeyCode.S))
		{
			cam.transform.Translate(new Vector3(0, 0, -1 * move_speed));
		}

		if (Input.GetKey(KeyCode.A))
		{
			cam.transform.Translate(new Vector3(-1 * move_speed, 0, 0));
		}

		if (Input.GetKey(KeyCode.D))
		{
			cam.transform.Translate(new Vector3(1 * move_speed, 0, 0));
		}


		if (Input.GetKey(KeyCode.Space))
		{
			cam.transform.Translate(new Vector3(0, 1 * move_speed, 0));
		}

		if (Input.GetKey(KeyCode.LeftShift))
		{
			cam.transform.Translate(new Vector3(0, -1 * move_speed, 0));
		}







		float pitch = Input.GetAxis("Mouse Y");
		float yaw = Input.GetAxis("Mouse X");

// cam.transform.Rotate(new Vector3(pitch, yaw, 0));
		Vector3 rotation = new Vector3(Camera.main.transform.eulerAngles.x - pitch * rotation_speed,
											 Camera.main.transform.eulerAngles.y + yaw*rotation_speed, 0);
		cam.transform.localEulerAngles = rotation;





		
		
	}
}