using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    Image image = null;
    Coroutine _currentFlashRoutine = null; 

    // Start is called before the first frame update
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame

    //when calling for flash, input values of float float and a Color if needed
        public void StartFlash(float secondsForOneFlash, float maxAlpha, Color newColor)
    {
        image.color = newColor;

        maxAlpha =  Mathf.Clamp(maxAlpha, 0.0f, 1.0f);

        if(_currentFlashRoutine != null)
        {
            StopCoroutine(_currentFlashRoutine);
            _currentFlashRoutine = StartCoroutine(Flash(secondsForOneFlash, maxAlpha));
        }
    }

    IEnumerator Flash(float secondForOneFlash, float maxAlpha)
    {
        //animates the flash in
        float flashInDuration = secondForOneFlash / 2;

        for (float i = 0; i <= flashInDuration; i += Time.deltaTime)
        {
            //new color
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, i / flashInDuration);
            image.color = colorThisFrame;
            //wait time per frame
            yield return null;
        }

        float flashOutDuration = secondForOneFlash / 2;
        for( float i = 0; i <= flashOutDuration; i += Time.deltaTime)
        {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, i / flashOutDuration);
            image.color = colorThisFrame;
            yield return null;
        }
    }
}
//https://www.youtube.com/watch?v=Yw3EoV5I_PE

// I cant get it to work but basically create a public Color where you want this to activate then paste this _flashImage.StartFlash(.25f, .5f, color); on where you want the flash to happen