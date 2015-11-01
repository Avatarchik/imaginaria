using UnityEngine;
using System.Collections;
using Vuforia;


public class ConfigureFocusMode : MonoBehaviour 
{
	public CameraDevice.FocusMode focusMode;

	// Use this for initialization
	void Start () 
	{
		CameraDevice.Instance.SetFocusMode(focusMode);
	}
	void Update () 
	{
		CameraDevice.Instance.SetFocusMode(focusMode);
	}
}
