using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for checking combo progress and adding bonus points onto the score if combo succeeds.
/// </summary>
public class ComboValidator : MonoBehaviour
{
	public List<EnumValue> currentLevelComboPattern;
	public List<EnumValue> currentCombo;

    // Start is called before the first frame update
    void Start()
    {
		reset();
    }

	/// <summary>
	/// rest the combo patterns at start of every brand new game session. (not evey level)
	/// </summary>
	public void reset() {
		currentCombo = new List<EnumValue>();
		currentLevelComboPattern = new List<EnumValue>();
	}

	public void validateCombo(ItemStats stats) {
		if (stats) {
			//todo add into current combo and compare to currentLevelComboPattern for progress
		} else {
			Debug.Log("Failed to validateCombo in ComboValidator, stats is null");
		}
	}

	/// <summary>
	/// Every new level shoudl set this.
	/// </summary>
	/// <param name="itemTypes">Item types.</param>
	public void setCombo(List<EnumValue> itemTypes) {
		currentLevelComboPattern = itemTypes;
	}

}
