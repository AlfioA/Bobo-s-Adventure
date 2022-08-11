using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    
    [Header ("Health")]
    [SerializeField] private float startingHealth;

    public float currentHealth {get; private set;}
    public bool dead = false;
    private Animator anim;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    bool yellowApple=false;
    bool invulnerable;

    void Start(){
        Physics2D.IgnoreLayerCollision(7,6,false);
        Physics2D.IgnoreLayerCollision(7,11,false);
        Physics2D.IgnoreLayerCollision(7,14,false);
        Physics2D.IgnoreLayerCollision(7,18,false);
    }

    public void Awake(){
        invulnerable = false;
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        SetLoadHealth();
    }
    void SetLoadHealth(){
        if(PlayerStats.health==2){
            currentHealth = Mathf.Clamp(currentHealth - 1, 0, startingHealth);
        }
        else if(PlayerStats.health==1){
            currentHealth = Mathf.Clamp(currentHealth - 1, 0, startingHealth);
            currentHealth = Mathf.Clamp(currentHealth - 1, 0, startingHealth);
        }
        else{
            return;
        }
    }

    public void TakeDamage(float _damage){
        if(yellowApple==false){
            if(invulnerable==true){
                return;
            }
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            if(currentHealth > 0){
                anim.SetTrigger("Hurt");
                PlayerStats.health--;
                Debug.Log(PlayerStats.health); 
                StartCoroutine(Invulnerability());
            }
            else{
                dead = true;
                PlayerStats.dead=true;
            }
        }
        else{
            StartCoroutine(YellowInvulnerability());
        }
    }

    public void AddHealth(float _value){

        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        if(PlayerStats.health<3){
            PlayerStats.health++;
        }
    } 
    
    private IEnumerator Invulnerability(){

        Physics2D.IgnoreLayerCollision(7,6,true);
        Physics2D.IgnoreLayerCollision(7,11,true);
        Physics2D.IgnoreLayerCollision(7,14,true);
        Physics2D.IgnoreLayerCollision(7,18,true);
        for (int i = 0; i < numberOfFlashes; i++){
            spriteRend.color = new Color(1,0,0,0.5f);
            invulnerable=true;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            invulnerable=false;
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7,6,false);
        Physics2D.IgnoreLayerCollision(7,11,false);
        Physics2D.IgnoreLayerCollision(7,14,false);
        Physics2D.IgnoreLayerCollision(7,18,false);
    }

    public IEnumerator YellowInvulnerability(){
        Physics2D.IgnoreLayerCollision(7,6,true);
        for (int i = 0; i < numberOfFlashes; i++){
            spriteRend.color = new Color(1,1,0,0.5f);
            yellowApple=true;
            yield return new WaitForSeconds(10);
            yellowApple=false;
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7,6,false);
        Physics2D.IgnoreLayerCollision(7,11,false);
        Physics2D.IgnoreLayerCollision(7,14,false);
    }

    public void YellowApple(){
        StartCoroutine(YellowInvulnerability());
    }
}
