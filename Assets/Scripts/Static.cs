using UnityEngine;
using System.Collections;

public class Static : MonoBehaviour 
{
	public static float velocity = 0.01f;
	public static float limite = 1f;
	public static int estado = 0;
	public static bool videoTerminado = false;
	public static int estadoVideo = 0;

	public static string uno = "HBDgOrB76Rk";// Los olvidados
	public static string dos = "sMKtYAb-83g";// Diana Salazar
	public static string tres = "sDdYI7X_GiY";// Eclipse
	public static string cuatro = "rMd7aytC4GY"; //Carretera
	public static string cinco = "EUyUPzHQwJM"; //Tlate izq
	public static string seis = "yjb7R4ZCUlc"; // Tlate der
	public static string siete = "srE5U2thlU0";// Melanie Smith
	public static string ocho = "YXVrP6nCPoY"; //A fire in my belly
	public static string nueve = "2P-1hU9DZ5o"; //Chol


	public static void PlayVideo(int index)
	{
		index += 1;
		/*Debug.Log ("Reproduciendo "+index+".mp4");
		Handheld.PlayFullScreenMovie(index+".mp4", Color.black, FullScreenMovieControlMode.Full);*/

	}


}
