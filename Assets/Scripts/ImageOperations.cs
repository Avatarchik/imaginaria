using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageOperations : MonoBehaviour 
{
	public void fade(GameObject image, int color, bool desaparece)//1 = blanco, 0 = negro
	{
		StartCoroutine (fade_(image, color, desaparece));
	}

	public void animateGif(Sprite[] sprites, Image image)
	{
		StartCoroutine (animateGif_(sprites, image));
	}

	IEnumerator fade_(GameObject p, float color, bool desaparece)
	{
		if(desaparece)
		{
			while(Static.limite > 0)
			{
				p.GetComponent<Image>().color = new Color(color, color, color, Static.limite);
				Static.limite-=0.01f;
				yield return new WaitForSeconds(Static.velocity);
			}
			p.SetActive(false);
		}
		else
		{
			p.SetActive(true);
			while(Static.limite < 1)
			{
				p.GetComponent<Image>().color = new Color(color, color, color, Static.limite);
				Static.limite+=0.01f;
				yield return new WaitForSeconds(Static.velocity);
			}
		}

	}

	IEnumerator animateGif_(Sprite[] s, Image i)
	{
		int t=0;
		while(t != s.Length)
		{
			foreach(Sprite sp in s)
			{
				i.sprite = sp;
				yield return new WaitForSeconds(.2f);
				t++;
			}
		}
	}
}
