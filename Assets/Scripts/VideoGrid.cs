using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VideoGrid : MonoBehaviour 
{
	public GameObject[] CUADROS;//Los 9 botones
	private Sprite[] cuadro0;
	private Sprite[] cuadro1;
	private Sprite[] cuadro2;
	private Sprite[] cuadro3;
	private Sprite[] cuadro4;
	private Sprite[] cuadro5;
	private Sprite[] cuadro6;
	private Sprite[] cuadro7;
	private Sprite[] cuadro8;
	public Sprite[] cuadrosOriginales;

	public bool isActive;

	private bool[] cuadroActivo;// 1 toque
	private int estado;
	private int[] touch;
	void Start () 
	{
		cuadroActivo = new bool[CUADROS.Length];
		touch = new int[CUADROS.Length];
		isActive = false;
		estado = -1;

		for(int i=0; i<touch.Length; i++)
		{
			touch[i]=0;
			cuadroActivo[i] = false;
		}
		cargaCuadros ();
	}

	void cargaCuadros()
	{
		cuadro0 = Resources.LoadAll<Sprite>("secuencias/0");
		cuadro1 = Resources.LoadAll<Sprite>("secuencias/1");
		cuadro2 = Resources.LoadAll<Sprite>("secuencias/2");
		cuadro3 = Resources.LoadAll<Sprite>("secuencias/3");
		cuadro4 = Resources.LoadAll<Sprite>("secuencias/4");
		cuadro5 = Resources.LoadAll<Sprite>("secuencias/5");
		cuadro6 = Resources.LoadAll<Sprite>("secuencias/6");
		cuadro7 = Resources.LoadAll<Sprite>("secuencias/7");
		cuadro8 = Resources.LoadAll<Sprite>("secuencias/8");
	}

	public void buttonAction(int edo)
	{
		estado = edo;
		int aux;
		touch [estado]++;
		for(int e=0; e<touch.Length; e++)
		{
			if(touch[e] == 1)
			{
				//resetTouch();
				isActive = true;
				cuadroActivo[edo] = true;
				loop(e);
				//Debug.Log("S>DFSADFADFASDF: "+e + "   " +estado+"  " + edo);
			}
			if(touch[e] == 2)
			{
				//Activar video etiquetado con estado
				touch[e] = 0;
				cuadroActivo[edo] = false;
				resetCuadros();
				aux = estado + 1;
				Handheld.PlayFullScreenMovie(aux+".mp4", Color.black, FullScreenMovieControlMode.Full);  
			}
		}

	}

	void Update () 
	{
		if(isActive)
		{
			resetTouch(estado);
			resetCuadros(estado);
			resetBooleans(estado);
		}
		else
		{
			resetTouch();
			resetCuadros();
			resetBooleans();
		}
	}

	void loop (int edo)
	{
		Debug.Log("S>DFSADFADFASDF: "+edo);
		switch(edo)
		{
		case 0:
			StartCoroutine(loop_(cuadro0,edo));
			break;

		case 1:
			StartCoroutine(loop_(cuadro1,edo));
			break;

		case 2:
			StartCoroutine(loop_(cuadro2,edo));
			break;

		case 3:
			StartCoroutine(loop_(cuadro3,edo));
			break;

		case 4:
			StartCoroutine(loop_(cuadro4,edo));
			break;

		case 5:
			StartCoroutine(loop_(cuadro5,edo));
			break;

		case 6:
			StartCoroutine(loop_(cuadro6,edo));
			break;

		case 7:
			StartCoroutine(loop_(cuadro7,edo));
			break;

		case 8: 
			StartCoroutine(loop_(cuadro8,edo));
			break;
		}
	}

	void resetCuadros(int omit)
	{
		for(int i=0; i<CUADROS.Length; i++)
		{
			if(i!=omit)
			{
				CUADROS[i].GetComponent<Button>().image.overrideSprite = cuadrosOriginales[i];
			}
		}
	}

	void resetTouch(int omit)
	{
		for(int i=0; i<CUADROS.Length; i++)
		{
			if(i!=omit)
			{
				touch[i] = 0;
			}
		}
	}

	void resetTouch()
	{
		for(int i=0; i<CUADROS.Length; i++)
		{
			touch[i] = 0;
		}
	}

	void resetCuadros()
	{
		for(int i=0; i<CUADROS.Length; i++)
		{
			CUADROS[i].GetComponent<Button>().image.overrideSprite = cuadrosOriginales[i];
		}
	}

	void resetBooleans(int omit)
	{
		for(int i=0; i<CUADROS.Length; i++)
		{
			if(i!=omit)
			{
				cuadroActivo[i] = false;
			}
		}
	}

	void resetBooleans()
	{
		for(int i=0; i<CUADROS.Length; i++)
		{
			cuadroActivo[i] = false;
		}
	}

	IEnumerator loop_(Sprite[] sp, int edo)
	{
		int lim = sp.Length;
		int counter = 0;
		while(cuadroActivo[edo])
		{
			CUADROS[edo].GetComponent<Button>().image.overrideSprite = sp[counter];
			counter ++;
			if(counter == lim)
			{
				counter =0;
			}
			yield return new WaitForSeconds(.5f);
		}
	}
}
