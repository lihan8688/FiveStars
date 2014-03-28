using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {
	private bool _isScaling = false;
	private bool _isMoving = false;

	private Vector3 scaleTo;
	private Vector3 moveTo;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (_isMoving) {
			_moving();
		}
		if (_isScaling) {
			_scaling();
		}
	}

	public void ScaleTo(Vector3 scaleTo) {
		this.scaleTo = scaleTo;
		this._isScaling = true;
	}

	private void _scaling() {
		if (Vector3.Distance (scaleTo, this.transform.localScale) > 0.01f) {
			this.transform.localScale += (scaleTo - transform.localScale) * 0.2f;
		} else {
			this._isScaling = false;
			this.transform.localScale = scaleTo;
		}
	}

	public void MoveTo(Vector3 moveTo) {
		this.moveTo = moveTo;
		this._isMoving = true;
	}
	
	private void _moving() {
		if (Vector3.Distance (moveTo, this.transform.localPosition) > 0.01f) {
			this.transform.localPosition += (moveTo - transform.localPosition) * 0.2f;
		} else {
			this._isMoving = false;
			this.transform.localPosition = moveTo;
		}
	}
}
