﻿using UnityEngine;

public class PlayerLookScript : MonoBehaviour
{


	public enum RotationAxis {
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxis axes = RotationAxis.MouseX;

	public float minimumVert = -85.0f;
	public float maximumVert = 85.0f;

	public float sensHorizontal = 10.0f;
	public float sensVertical = 10.0f;

	private float _rotationX = 0;

	public Camera playerCameraComponent;


	// UNITY HOOKS

	private void Update() {
        // STUB: Potentially handle look if player is active/inactive
		if(true) {
			CalculateLookRotation();
		}
	}

	// IMPLEMENTATION METHODS

	private void CalculateLookRotation() {
		if (axes == RotationAxis.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
		} else if (axes == RotationAxis.MouseY) {
			_rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
			// Clamps the vertical angle within the min and max limits
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
	}


}
