using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlVideo : MonoBehaviour 
{
	public GameObject PANEL_AR;
	public GameObject BOTON_CAMBIANTE;
	public Sprite Fragmento;
	public Sprite RegresarAR;
	public Text HEAD;
	public bool isT;

	private YoutubeVideo youtube;

	void Start () 
	{
		youtube = gameObject.AddComponent<YoutubeVideo> ();
		isT = false;
	}

	public void isTracking(bool i)
	{
		if(i)
		{
			PANEL_AR.SetActive(true);
			BOTON_CAMBIANTE.GetComponent<Button>().image.overrideSprite = Fragmento;
			HEAD.text = "ELIGE LA VERSIÓN DEL VIDEO";
		}
		else
		{
			PANEL_AR.SetActive(false);
		}
	}

	public void fragmentoButton()
	{
		if(Static.videoTerminado)
		{
			PANEL_AR.SetActive(false);
			Static.videoTerminado = false;
		}
		else
		{
			StartCoroutine (PlayVideoCoroutine (Static.estadoVideo + ""));
		}

	}

	public void videoCompletoButton()
	{
		switch(Static.estadoVideo)
		{
		case 1:
			StartCoroutine(youtube.LoadVideo(Static.uno));
			break;
			
		case 2:
			StartCoroutine(youtube.LoadVideo(Static.dos));
			break;
			
		case 3:
			StartCoroutine(youtube.LoadVideo(Static.tres));
			break;
			
		case 4:
			StartCoroutine(youtube.LoadVideo(Static.cuatro));
			break;
			
		case 5:
			StartCoroutine(youtube.LoadVideo(Static.cinco));
			break;
			
		case 6:
			StartCoroutine(youtube.LoadVideo(Static.seis));
			break;
			
		case 7:
			StartCoroutine(youtube.LoadVideo(Static.siete));
			break;
			
		case 8:
			StartCoroutine(youtube.LoadVideo(Static.ocho));
			break;
			
		case 9:
			StartCoroutine(youtube.LoadVideo(Static.nueve));
			break;
		}
	}
	
	IEnumerator PlayVideoCoroutine(string videoPath)
	{
		Handheld.PlayFullScreenMovie(videoPath+".mp4", Color.black, FullScreenMovieControlMode.Full);    
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();

		PANEL_AR.SetActive(true);
		HEAD.text = "FIN DEL FRAGMENTO";
		BOTON_CAMBIANTE.GetComponent<Button>().image.overrideSprite = RegresarAR;
		Static.videoTerminado = true;
	}
}
