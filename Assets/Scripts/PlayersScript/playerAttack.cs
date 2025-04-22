using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Callbacks;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

//ranged vars

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [SerializeField] private GameObject purchaseUI; 
    [SerializeField] private GameObject purchaseUI2; 
    [SerializeField] private GameObject cardSystem;





//melee vars
    private GameObject meleeAttackArea = default;
    private bool Attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;


    void Start()
    {
        meleeAttackArea = transform.Find("SwordArea").gameObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            meleeAttack();
        }

        if (Input.GetMouseButtonDown(0)){
            Shoot();
        }

        

        if(Attacking){
            timer += Time.deltaTime;

            if(timer >= timeToAttack){
                timer = 0;
                Attacking = false;
                meleeAttackArea.SetActive(Attacking);
            }
        }
        
    }

    public void setBulletType(GameObject bullet)
    {
        bulletPrefab = bullet;
        Debug.Log("Bullet Type: ");
    }

    public GameObject getBulletType()
    {
        return bulletPrefab;
    }
   
   private void meleeAttack(){
        Attacking = true;
        meleeAttackArea.SetActive(Attacking);
   }

   private void Shoot(){
    // Prevent shooting if the shop UI is open
    if (purchaseUI != null && (purchaseUI.activeSelf || purchaseUI2.activeSelf)) {
        //Debug.Log("Cannot shoot while shop is open!");
        return;
    }
    if (cardSystem.GetComponent<PlayerCardScript>().whatIsActive() >= 0){
        Debug.Log("return idk why");
        return;
        
    }
    Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
   }

   /*IEnumerator attackWaiter(){
        yield return new WaitForSeconds((float)0.25);
        Attacking = false;
        meleeAttackArea.SetActive(Attacking);
   }*/
    
}
