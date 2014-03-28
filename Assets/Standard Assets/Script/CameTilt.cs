using UnityEngine;
using System.Collections;

public class CameTilt : MonoBehaviour {
	public Transform _hTilt;
	private bool _onMouseDown = false;
	private bool _onDrag = false;
	private Vector3 _lastMousePosition; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_onDrag) {
			if (Input.mousePosition.y > 50 && Input.mousePosition.x < Screen.width - 50) {
				return;
			}

			float distX = -(Input.mousePosition.y - _lastMousePosition.y) * 0.3f;
			float distY = (Input.mousePosition.x - _lastMousePosition.x) * 0.3f;
			if (Input.mousePosition.y > 50) {
				distY = 0;
			}
			if (Input.mousePosition.x < Screen.width - 50) {
				distX = 0;
			}

			if (Mathf.Abs(distX) > Mathf.Abs(distY)) {
				distY = 0;
			} else {
				distX = 0;
			}
			//_lastMousePosition = Input.mousePosition;
			Vector3 euler = new Vector3(_hTilt.rotation.x, _hTilt.rotation.y, _hTilt.rotation.z);
			//_hTilt.RotateAround(Vector3.left, -distX);
			//_hTilt.RotateAround(Vector3.up, distY);
			_hTilt.rotation = Quaternion.Euler(Mathf.Clamp(euler.x + distX, -30.0f, 30.0f), Mathf.Clamp(euler.y + distY, -50.0f, 50.0f), euler.z);
			//_hTilt.Rotate(new Vector3(distX, distY, .0f));
			//_hTilt.rotation = Quaternion.Euler(Mathf.Clamp(_hTilt.rotation.x + distX, -50.0f, 50.0f), Mathf.Clamp(_hTilt.rotation.y + distY, -50.0f, 50.0f), _hTilt.rotation.z);
		} else if (_onMouseDown) {
			//Debug.Log(Vector3.Distance(_lastMousePosition, Input.mousePosition));
			if (Vector3.Distance(_lastMousePosition, Input.mousePosition) > 5.0f) {
				_onDrag = true;
			}
		}

		if (Input.GetMouseButtonDown (0)) {
			_onMouseDown = true;
			_lastMousePosition = Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0)) {
			_onDrag = false;
			_onMouseDown = false;
			//_restoreTilt();
		}
	}
}
