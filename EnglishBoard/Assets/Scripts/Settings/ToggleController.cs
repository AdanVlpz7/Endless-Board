using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
	public bool isOn;

	public Color onColorBg;
	public Color offColorBg;

	public Image toggleBgImage;
	public RectTransform toggle;

	public GameObject handle;
	private RectTransform handleTransform;

	private float handleSize;
	private float onPosX;
	private float offPosX;

	public float handleOffset;

	public float speed;
	static float t = 0.0f;

	private bool switching = false;
	private int caseSetting; 

	void Awake()
	{
		handleTransform = handle.GetComponent<RectTransform>();
		RectTransform handleRect = handle.GetComponent<RectTransform>();
		handleSize = handleRect.sizeDelta.x;
		float toggleSizeX = toggle.sizeDelta.x;
		onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
		offPosX = onPosX * -1;

	}


	void Start()
	{
		if (isOn)
		{
			toggleBgImage.color = onColorBg;
			handleTransform.localPosition = new Vector3(onPosX, 0f, 0f);
		}
		else
		{
			toggleBgImage.color = offColorBg;
			handleTransform.localPosition = new Vector3(offPosX, 0f, 0f);
		}
	}

	void Update()
	{

		if (switching)
		{
			Toggle(isOn);
		}
	}

	public void DoYourStaff()
	{
		Debug.Log(isOn);
	}

	public void Switching()
	{
		switching = true;
	}



	public void Toggle(bool toggleStatus)
	{

		if (toggleStatus)
		{
			TurningOff();
			if(caseSetting == 0)
            {
				UpdateFeaturesSound(2);
			}
            else
            {
				UpdateFeaturesSound(3);
            }
			//UpdateFeaturesSound(0);
		}
		else
		{
			TurningOn();
			if (caseSetting == 0)
			{
				UpdateFeaturesSound(0);
			}
			else
			{
				UpdateFeaturesSound(1);
			}
			//UpdateFeaturesSound(0);
		}

	}


	Vector3 SmoothMove(GameObject toggleHandle, float startPosX, float endPosX)
	{

		Vector3 position = new Vector3(Mathf.Lerp(startPosX, endPosX, t += speed * Time.deltaTime), 0f, 0f);
		StopSwitching();
		return position;
	}

	Color SmoothColor(Color startCol, Color endCol)
	{
		Color resultCol;
		resultCol = Color.Lerp(startCol, endCol, t += speed * Time.deltaTime);
		return resultCol;
	}

	CanvasGroup Transparency(GameObject alphaObj, float startAlpha, float endAlpha)
	{
		CanvasGroup alphaVal;
		alphaVal = alphaObj.gameObject.GetComponent<CanvasGroup>();
		alphaVal.alpha = Mathf.Lerp(startAlpha, endAlpha, t += speed * Time.deltaTime);
		return alphaVal;
	}

	void StopSwitching()
	{
		if (t > 1.0f)
		{
			switching = false;

			t = 0.0f;
			switch (isOn)
			{
				case true:
					isOn = false;
					DoYourStaff();
					break;

				case false:
					isOn = true;
					DoYourStaff();
					break;
			}

		}
	}
	public void SetIntCase(int id)
    {
		caseSetting = id;
    }
	public void UpdateFeaturesSound(int id)
	{
		AudioSource audio;
		audio = GameObject.FindGameObjectWithTag("UserManager").GetComponent<AudioSource>();
		switch (id)
		{
			case 0:
				UserManager.soundOn = 1;
				PlayerPrefs.SetInt("SoundOnKey", 1);
				break;
			case 1:
				UserManager.musicOn = 1;
				PlayerPrefs.SetInt("MusicOnKey", 1);
				audio.Play();
				break;
			case 2:
				UserManager.soundOn = 0;
				PlayerPrefs.SetInt("SoundOnKey", 0);
				//;
				break;
			case 3:
				UserManager.musicOn = 0;
				PlayerPrefs.SetInt("MusicOnKey", 0);
				audio.Stop();
				break;
		}
	}

	public void TurningOn()
    {
		toggleBgImage.color = SmoothColor(offColorBg, onColorBg);
		handleTransform.localPosition = SmoothMove(handle, offPosX, onPosX);
	}

	public void TurningOff()
    {
		toggleBgImage.color = SmoothColor(onColorBg, offColorBg);
		handleTransform.localPosition = SmoothMove(handle, onPosX, offPosX);
	}
}
