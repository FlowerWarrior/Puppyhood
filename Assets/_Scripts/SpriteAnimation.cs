using UnityEngine; 
using System.Collections; 
using System.Collections.Generic;

public class SpriteAnimation: MonoBehaviour 
 { 
     private SpriteRenderer spriteRenderer; 
     public Sprite[] sprites; 
     private int spriteIndex;
    [SerializeField] public float intervalTime = 0.15f;
     
 
   private void Awake()
   {
    spriteRenderer = GetComponent<SpriteRenderer>();
   }
   
     private void OnEnable() 
     {
        StartCoroutine(AnimLoop());
     }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void AnimateSprite()
    {
        spriteIndex++; 
  
      if(spriteIndex >= sprites.Length)  
      { 
        spriteIndex = 0; 
      } 
  
      spriteRenderer.sprite = sprites[spriteIndex];
    }

    IEnumerator AnimLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            AnimateSprite();
        }
    }
}