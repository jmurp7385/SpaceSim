using UnityEngine;
using System.Collections;

public class CustomCam : MonoBehaviour {
    public Transform target;
    public float oneSpeedDistance;
    public float twoSpeedDistance;
    public float threeSpeedDistance;
    public float height;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;

    private Transform _myTransform;
    private float _x;
    private float _y;
    private bool _camButtonDown = false;

    void Awake()
    {
        _myTransform = transform;
    }

    // Use this for initialization
    void Start () {
        if (target == null)
            Debug.LogWarning("Target == NULL");
        else
        {
            CameraSetUp();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            _camButtonDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _camButtonDown = false;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            if (_camButtonDown == true)
            {
                _x += Input.GetAxis("Mouse X") * xSpeed * (.02f);
                _y -= Input.GetAxis("Mouse Y") * xSpeed * (.02f);
                Quaternion rotation = Quaternion.Euler(_y, _x, 0);
                Vector3 position = rotation * new Vector3(0.0f, 0.0f, -oneSpeedDistance) + target.position;

                _myTransform.rotation = rotation;
                _myTransform.position = position;
            }
            else
            {
                _myTransform.position = new Vector3(target.position.y + height, target.position.z - oneSpeedDistance);
                _myTransform.LookAt(target);
                _x = 0;
                _y = 0;
            }
        }
    }

    public void CameraSetUp()
    {
        _myTransform.position = new Vector3(target.position.y + height, target.position.z - oneSpeedDistance);
        _myTransform.LookAt(target);
    }
}
