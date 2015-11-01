using UnityEngine;
using System.Collections;

public class YoutubeVideo : MonoBehaviour {

	public static YoutubeVideo Instance;
	//public bool drawBackground;
	//public Texture2D backgroundImage;
    public string serverGetVideoFile = "http://kronuz.zz.vc/video/getvideo.php";

	void Start()
	{
		Instance = this;
	}
	
	public IEnumerator LoadVideo(string vId)
	{
		//Dont change this url
		//If you change the video will not work
		string url = serverGetVideoFile+"?videoid="+vId+"&type=Download";
		WWWForm form = new WWWForm();
		form.AddField("key","youtubeDownloader");
		WWW www = new WWW(url,form);
		yield return www;
		string result = www.text;
		Debug.Log(result);

		Handheld.PlayFullScreenMovie(result, Color.black, FullScreenMovieControlMode.Full);
	}

	/*
	void OnGUI()
	{
		GUI.depth = 1;
		if(drawBackground)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundImage);
		}
	}*/



}
