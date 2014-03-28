using UnityEngine;
using System.Collections;

public class NumpadLabel : MonoBehaviour {
	public UILabel _numpadInput;
	private string _value = "";

	public void AddNumber(GameObject button) {
		string number = button.GetComponentInChildren<UILabel> ().text;
		_numpadInput.text = buildText(number);
	}

	private string buildText(string num) {
		int value = 0;
		if (int.TryParse(_value + num, out value)) {
			if (value > 255) {
				value = 255;
			}
			_value = value.ToString ();
		}
		return "+ " + _value + " pts";
	}
}
