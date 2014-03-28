using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	static Transform mouseDownObj = null;
	public TextMesh _numpadInput = null;
	public string _value = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit))
			if (hit.transform == transform) {
				if (mouseDownObj != gameObject.transform) {
					_restorePrevious();
				}
				string text = _numpadInput.text;
				text += _value;
				text = text.Substring(Mathf.Max(0, text.Length - 10), 10);
				_numpadInput.text = text;
				mouseDownObj = gameObject.transform;
				mouseDownObj.GetComponent<Spring>().MoveTo(new Vector3(mouseDownObj.localPosition.x,
				                                                       mouseDownObj.localPosition.y,
		                                            					0.2f));
			}
		} else if (Input.GetMouseButtonUp (0)) {
			_restorePrevious();
		}
	}

	void _restorePrevious() {
		if (mouseDownObj != null) {
			mouseDownObj.GetComponent<Spring>().MoveTo(new Vector3(mouseDownObj.localPosition.x,
			                                                       mouseDownObj.localPosition.y,
			                                                       0.0f));
			mouseDownObj = null;
		}
	}
}
