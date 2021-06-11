using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   	// Update is called once per frame
	private float horizontalMovement;
	private float verticalMovement;
	// Use this for initialization
	void Start()
	{
        Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
        
		float xMovement = Input.GetAxis("Mouse X");
		float yMovement = Input.GetAxis("Mouse Y") * -1;
		transform.eulerAngles += new Vector3(yMovement, xMovement, 0.0f);

        /*
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += transform.forward * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= transform.forward * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= transform.right * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += transform.right * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.position += Vector3.down * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.position += Vector3.up * Time.deltaTime * 10;
        }
        */

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
