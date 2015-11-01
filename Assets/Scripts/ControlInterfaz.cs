using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlInterfaz : MonoBehaviour 
{
	public GameObject P1;//AR
	public GameObject P2;//LIBRO
	public GameObject P3;//VIDEO

	public GameObject[] PANTALLA_INICIAL;
	public GameObject GIF;
	public GameObject[] PANEL_GLOBOS;
	public GameObject[] SEGUNDA_PANTALLA;
	public GameObject BARRA;
	public GameObject[] PANEL_GLOBOS_2;
	public GameObject[] VIDEOS;
	public Sprite[] theSprites;

	private ImageOperations imageOperations;
	private VideoGrid video;
	private int estado = 0;
	void Start () 
	{
		//theSprites = Resources.LoadAll("icons", typeof(Sprite));
		imageOperations = gameObject.AddComponent<ImageOperations> ();
		video = gameObject.GetComponent<VideoGrid> ();
		StartCoroutine (start_(theSprites));
	}

	IEnumerator start_(Sprite[] sp)
	{
		imageOperations.animateGif (sp, GIF.GetComponent<Image> ());
		yield return new WaitForSeconds(2f);
		foreach(GameObject g in PANTALLA_INICIAL)
		{
			imageOperations.fade(g, 0, true);
		}
		imageOperations.fade(GIF, 0, true);
		yield return new WaitForSeconds (2f);
		Static.limite = 0.6f;
		foreach(GameObject g in PANEL_GLOBOS)
		{
			imageOperations.fade (g, 0, true);
		}
	}

	public void funcionBoton(string op)
	{
		Static.limite = 1f;
		switch(op)
		{
		case "AR":
			//Desaparecemos el panel que tiene botones
			P1.SetActive(true);
			P2.SetActive(false);
			P3.SetActive(false);
			StartCoroutine(ARCamera());

			break;

		case "LIBRO":
			P1.SetActive(false);
			P2.SetActive(true);
			P3.SetActive(false);
			foreach(GameObject g in SEGUNDA_PANTALLA)
			{
				imageOperations.fade (g, 0, true);
			}
			break;

		case "VIDEOS":
			P1.SetActive(false);
			P2.SetActive(false);
			P3.SetActive(true);
			StartCoroutine(VIDEOS_());
			break;

		case "MENU":
			video.isActive = false;
			Static.limite = 0f;
			for(int i=0; i<SEGUNDA_PANTALLA.Length-1; i++)
			{
				imageOperations.fade (SEGUNDA_PANTALLA[i], 1, false);
			}
			imageOperations.fade (SEGUNDA_PANTALLA[SEGUNDA_PANTALLA.Length-1], 0, false);
			break;

		default:
			Debug.Log("Error en algun boton");
			break;
		}
	}

	IEnumerator ARCamera()
	{
		estado = 1;
		foreach(GameObject g in SEGUNDA_PANTALLA)
		{
			imageOperations.fade (g, 0, true);
		}
		BARRA.SetActive (true);
		/*
		BARRA [0].SetActive (true);
		BARRA [1].SetActive (true);
		BARRA [2].SetActive (true);
		BARRA [1].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		BARRA [2].GetComponent<Image> ().color = new Color (0, 0, 0, 0.6f);
		*/
		yield return new WaitForSeconds(2f);
		BARRA.SetActive (false);
		/*Static.limite = 0.6f;
		BARRA [0].SetActive (false);
		imageOperations.fade (BARRA[1], 0, true);
		imageOperations.fade (BARRA[2], 0, true);
		*/
	}

	IEnumerator VIDEOS_()
	{
		estado = 3;
		for(int i=0; i<VIDEOS.Length; i++)
		{
			VIDEOS[i].SetActive(true);
			VIDEOS[i].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		VIDEOS[VIDEOS.Length-1].GetComponent<Image> ().color = new Color (0, 0, 0, 1);
		VIDEOS[VIDEOS.Length-2].GetComponent<Image> ().color = new Color (0, 0, 0, 1);
		foreach(GameObject g in SEGUNDA_PANTALLA)
		{
			imageOperations.fade (g, 0, true);
		}

		yield return new WaitForSeconds(2f);
		foreach(GameObject g in PANEL_GLOBOS_2)
		{
			imageOperations.fade (g, 0, true);
		}
	}
}
