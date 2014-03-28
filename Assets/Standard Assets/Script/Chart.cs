using UnityEngine;
using System.Collections;

public class Chart : MonoBehaviour {
	public TextMesh _numpadInput = null;
	// Use this for initialization
	void Start () {
		UpdateChart();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			UpdateChart();
		}
	}

	void UpdateChart() {
		string text = _numpadInput.text;
		float scaleUnit = 0.2f;
		foreach (Transform child in transform) {
			int index = child.name.Substring(child.name.Length - 1)[0] - '0';
			char value = text[index];
			if (value == '#' || value == '*') {
				value = '0';
			}
			float scaleY = scaleUnit * (value - '0' + 1);
			child.GetComponent<Spring>().ScaleTo(new Vector3(child.localScale.x, scaleY, child.localScale.z));
		}
	}
}
