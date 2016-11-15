using UnityEngine;
using System.Collections;

public class FlyScript : MonoBehaviour {

    public float speed = 100;

    private Rigidbody rb;
    private Camera mainCam;
    private bool _halt;
    private bool _break;
    private Vector3 _forwardV;
    private Vector3 _rightV;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown("h"))
            _halt = true;
        if (Input.GetKeyUp("h"))
            _halt = false;
        if(Input.GetKeyDown("b"))
            _break = true;
        if(Input.GetKeyUp("b"))
            _break = false;
    }

    // Update is called once per frame
    void LateUpdate() {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //      Input.GetButton ("Fire1");
        //		Input.GetButton ("Fire2");
        if (_halt == true)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.LogWarning("Halted");
        }
        if (_break == true)
        {
            rb.AddForce(-_forwardV * 10);
            rb.AddForce(-_rightV * 10);
            rb.transform.forward = -mainCam.transform.forward;
            rb.transform.right = -mainCam.transform.right;
            Debug.LogWarning("Breaking");
        }
        if (Input.GetKeyDown("1"))
        {
            this.speed = 50;
            Debug.LogWarning("Speed = 50");
        }
        if (Input.GetKeyDown("2"))
        {
            this.speed = 100;
            Debug.LogWarning("Speed = 100");
        }
        if (Input.GetKeyDown("h"))
        {
            this.speed = 200;
            Debug.LogWarning("Speed = 200");
        }

        rb.AddForce(mainCam.transform.forward * speed * vertical);
		rb.AddForce (mainCam.transform.right * speed * horizontal);
        _forwardV = mainCam.transform.forward * speed * vertical;   //cache velocity for break
        _rightV = mainCam.transform.right * speed * horizontal;     //cache angular velocity for break
		rb.transform.forward = mainCam.transform.forward;
		rb.transform.right = mainCam.transform.right;
	}
}
