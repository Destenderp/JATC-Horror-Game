using System.Collections;
using UnityEngine;
using TL.Core;

namespace TL.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Attack", menuName = "UtilityAI/Actions/Attack")]
    public class Attack : Action
    {

        public GameObject enemyProjectile;
        public GameObject enemyProjectilePosition;
        public GameObject enemyAttackBlood;
        public GameObject enemyCASTLEOFGLASS;
        public GameObject enemySquareOfLighting;
        public GameObject enemyLaser;

        public GameObject enemyRandomSpawns;
        public static GameObject enemySpawns;


        public static bool cameraFlashEnabled = false;
        public static bool chokeEnabled = false;
        public static bool shootEnabled = false;
        public static bool bloodEnabled = false;
        public static bool colorShiftEnabled = false;
        public static bool missleEnabled = false;
        public static bool castleOfGlassEnabled = false;
        public static bool squareOfLightingEnabled = false;
        public static bool puppeteerEnabled = false;
        public static bool stillShotEnabled = false;
        public static bool bansheeScreamEnabled = false;
        public static bool locationAttackEnabled = false;

        public static bool waitingForClicks = false;

        public static bool isPlayerFrozen = false;
        public static int objectsClicked = 0;
        public static int totalObjectsToClick = 3;
       

        public GameObject _boss;
        //public GameObject _bossPosition;
        public GameObject player;
        public GameObject playerPosition;
        int counter = 1;


        public override void Execute(BossController boss)
        {

            switch (Stats.level)
            {

                /*************************************
                 ********* Video & Audio *************
                 ************************************/
                case 1:
                    if(cameraFlashEnabled == true)
                    {
                        // VIDEO
                        cameraFlash();
                    }
                    if(stillShotEnabled == true)
                    {
                        // VIDEO
                        stillShot();
                    }
                    if (bansheeScreamEnabled == true)
                    {
                        // AUDIO
                        bansheeScream();
                    }
                    if(locationAttackEnabled == true)
                    {
                        locationAttack();
                    }
                    break;


                /***************************************
                ************* Graphics *****************
                ***************************************/
                case 2:

                    if (shootEnabled == true)
                    {
                        Debug.Log("Shoot");
                        Stats.bosses[2].damage = 5;
                        shoot();
                        shootEnabled = false;
                    }
                    if (bloodEnabled == true)
                    {
                        Debug.Log("Blood");
                        blood();
                        bloodEnabled = false;
                    }
                    if (colorShiftEnabled == true)
                    {
                        Debug.Log("Color Shift");
                        colorShift();
                        colorShiftEnabled = false;
                    }
                    break;

                /************************************
                *********** Raging Ricky ************
                ************************************/
                case 3:

                    if (shootEnabled == true)
                    {
                        Debug.Log("Shoot");
                            Stats.bosses[3].damage = 5;
                            shoot();
                            shootEnabled = false;
                    }
                    if (missleEnabled == true)
                    {
                        Debug.Log("Missle");
                            Stats.bosses[3].damage = 10;
                            missle();
                            missleEnabled = false;
                    }
                    if (castleOfGlassEnabled == true)
                    {
                        Debug.Log("CASTLEOFGLASS");
                        castleOfGlass();
                        castleOfGlassEnabled =false;
                    }
                    break;

                case 4:

                    if (chokeEnabled == true)
                    {
                        Stats.bosses[4].damage = 1;
                        Debug.Log("Choke");
                        choke();
                    }
                    if (squareOfLightingEnabled == true)
                    {
                        Debug.Log("Lighting");
                        Stats.bosses[4].damage = 12;
                        squareOfLighting();
                    }
                    if (puppeteerEnabled == true)
                    {
                        Debug.Log("Puppeteer");
                        puppeteer();

                    }

                    break;
            }


            // DONE

            void cameraFlash()
            {
                CoroutineHandler.Instance.StartRoutine(cameraAttack());
            }
            IEnumerator cameraAttack()
            {
                GameObject enemyColorShift = GameObject.Find("ColorShift");
                SpriteRenderer renderer = enemyColorShift.GetComponent<SpriteRenderer>();
                renderer.color = new Color(1f, 1f, 1f, 1f);

                    yield return new WaitForSeconds(0.5f);
                    renderer.color = new Color(1f, 1f, 1f, 0.9f);
                    yield return new WaitForSeconds(1f);
                    renderer.color = new Color(1f, 1f, 1f, 0.8f);
                    yield return new WaitForSeconds(0.5f);
                    renderer.color = new Color(1f, 1f, 1f, 0.7f);
                    yield return new WaitForSeconds(1f);
                    renderer.color = new Color(1f, 1f, 1f, 0.6f);
                    yield return new WaitForSeconds(0.5f);
                    renderer.color = new Color(1f, 1f, 1f, 0.5f);
                    yield return new WaitForSeconds(1f);
                    renderer.color = new Color(1f, 1f, 1f, 0.4f);
                    yield return new WaitForSeconds(0.5f);
                    renderer.color = new Color(1f, 1f, 1f, 0.3f);
                    yield return new WaitForSeconds(1f);
                    renderer.color = new Color(1f, 1f, 1f, 0.2f);
                    yield return new WaitForSeconds(0.5f);
                    renderer.color = new Color(1f, 1f, 1f, 0.1f);
                    yield return new WaitForSeconds(1f);
                    renderer.color = new Color(1f, 1f, 1f, 0f);
                    cameraFlashEnabled = false;
            }

            // DONE

            void stillShot()
            {
                CoroutineHandler.Instance.StartRoutine(stillShotAttack());
            }
            IEnumerator stillShotAttack()
            {
                Debug.Log("StillShotAttack Works");
                GameObject.Find("Player").GetComponent<Player>().setSpeed(0);
                yield return new WaitForSeconds(5f);
                GameObject.Find("Player").GetComponent<Player>().setSpeed(5);
                stillShotEnabled = false;
            }

            // DONE

            void bansheeScream()
            {
                Debug.Log("Banshee Scream Enabled");
            }

            void locationAttack()
            {
                // Echo locates and moves in front of the player, then does the banshee screen for a slight damage boost

                /*
                 * NEED BOSS MOVEMENT AND BANSHEE LOGIC FOR THIS TO WORK FOR AUDIO 
                 */
            }

            // DONE

            void shoot()
            {
                enemyProjectilePosition = GameObject.Find("ProjectilePosition");
                GameObject newProjectile = Instantiate(enemyProjectile, enemyProjectilePosition.transform.position, Quaternion.identity);

                player = GameObject.FindWithTag("Player");
                Rigidbody2D newProjectileRB = newProjectile.GetComponent<Rigidbody2D>();

                Vector3 direction = (player.transform.position - enemyProjectilePosition.transform.position).normalized;

                newProjectileRB.velocity = direction * 5f;
            }

            // DONE

            void missle()
            {
                enemyProjectilePosition = GameObject.Find("ProjectilePosition");
                GameObject newProjectile = Instantiate(enemyProjectile, enemyProjectilePosition.transform.position, Quaternion.identity);

                player = GameObject.FindWithTag("Player");
                Rigidbody2D newProjectileRB = newProjectile.GetComponent<Rigidbody2D>();

                Vector3 direction = (player.transform.position - enemyProjectilePosition.transform.position).normalized;

                newProjectileRB.velocity = direction * 10f;
            }

            // DONE

            void blood()
            {
                playerPosition = GameObject.Find("Player");

                GameObject newBlood = Instantiate(enemyAttackBlood, playerPosition.transform.position, Quaternion.identity);

                player = GameObject.FindWithTag("Player");
                Rigidbody2D newBloodRB = newBlood.GetComponent<Rigidbody2D>();
            }

            // DONE

            void colorShift()
            {
                GameObject enemyColorShift = GameObject.Find("ColorShift");
                SpriteRenderer renderer = enemyColorShift.GetComponent<SpriteRenderer>();
                if (counter == 1)
                {
                    Debug.Log("Red");

                    renderer.color = new Color(1f, 0.6745f, 0.7215f, .4313f);
                }
                else if (counter == 2)
                {
                    Debug.Log("Orange");
                    renderer.color = new Color(0.9647f, 0.6705f, 0.4274f, .4313f);
                }
                else if (counter == 3)
                {
                    Debug.Log("Yellow");
                    renderer.color = new Color(1f, 0.9254f, 0.0901f, .4313f);
                }
                else if (counter == 4)
                {
                    Debug.Log("Green");
                    renderer.color = new Color(0.6862f, 1f, 0.6784f, .4313f);
                }
                else if (counter == 5)
                {
                    Debug.Log("Blue");
                    renderer.color = new Color(0.6784f, 0.9137f, 1f, .4313f);
                }
                else if (counter == 6)
                {
                    Debug.Log("Indigo");
                    renderer.color = new Color(0.6901f, 0.6784f, 1f, .4313f);
                }
                else if (counter == 7)
                {
                    Debug.Log("Violet");
                    renderer.color = new Color(0.8298f, 0.6784f, 1f, 0.4313f);
                }
                counter++;
                if (counter == 8)
                {
                    counter = 1;
                }
                if (Stats.bosses[2].health == 0)
                {
                    Debug.Log("Renderer Destroyed");
                    Destroy(renderer);
                }
            }

            // DONE

            void castleOfGlass()
            {
                CoroutineHandler.Instance.StartRoutine(castleAttack());
            }
            IEnumerator castleAttack()
            {
                Debug.Log("Starting");
                isPlayerFrozen = true;
                GameObject.Find("Player").GetComponent<Player>().setSpeed(0);

                playerPosition = GameObject.Find("Player");

                GameObject castleOfGlass = Instantiate(enemyCASTLEOFGLASS, playerPosition.transform.position, Quaternion.identity);
                
                player = GameObject.FindWithTag("Player");
                Rigidbody2D newCastleOfGlassRB = castleOfGlass.GetComponent<Rigidbody2D>();

                for (int i = 0; i < totalObjectsToClick; i++)
                {
                    Vector3 randomPoint = new(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                    randomPoint.z = 10;
                    GameObject newRandomSpawn = Instantiate(enemyRandomSpawns, randomPoint, Quaternion.identity);

                    newRandomSpawn.tag = "CASTLEOFGLASSRANDOMSPAWNER";
                }
               

                waitingForClicks = true;

                yield return new WaitForSeconds(20f);

                if (objectsClicked >= totalObjectsToClick)
                {
                    Debug.Log("1");
                    isPlayerFrozen = false;
                    GameObject.Find("Player").GetComponent<Player>().setSpeed(5);
                    castleOfGlassEnabled = false;
                   
                    objectsClicked = 0;
                }
                else
                {
                    Debug.Log("2");
                    isPlayerFrozen = false;
                    Debug.Log("Player Takes A Lot Of Damage");
                    Stats.bosses[2].damage = 20;
                    castleOfGlassEnabled = false;
                }
                Destroy(castleOfGlass);
                waitingForClicks = false;
            }
            // DONE
            void choke()
            {
                CoroutineHandler.Instance.StartRoutine(chokeAttack());
            }
            IEnumerator chokeAttack()
            {
                _boss = GameObject.FindWithTag("Boss");

                for (int i = 0; i < totalObjectsToClick; i++)
                {
                    Vector3 randomPoint = new(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                    randomPoint.z = 10;
                    GameObject newRandomSpawn = Instantiate(enemyRandomSpawns, randomPoint, Quaternion.identity);
                    newRandomSpawn.tag = "CASTLEOFGLASSRANDOMSPAWNER";
                }

                waitingForClicks = true;

                yield return new WaitForSeconds(20f);
                Debug.Log("I waited 20 Seconds");
                    if (objectsClicked >= totalObjectsToClick)
                    {
                        isPlayerFrozen = false;
                        chokeEnabled = false;
                        _boss.gameObject.SetActive(false);
                        GameObject.Find("Player").GetComponent<Player>().setSpeed(5);
                        objectsClicked = 0;
                    }
                    else
                    {
                        isPlayerFrozen = false;
                        chokeEnabled = false;
                }
                 waitingForClicks = false;
                 _boss.gameObject.SetActive(true);
            }
        
        
        void squareOfLighting()
        {
                CoroutineHandler.Instance.StartRoutine(lightingAttack());
        }
            IEnumerator lightingAttack()
            {
                playerPosition = GameObject.Find("PlayerPosition");

                GameObject squareOfLighting = Instantiate(enemySquareOfLighting, playerPosition.transform.position, Quaternion.identity);

                player = GameObject.FindWithTag("Player");
                Rigidbody2D newSquareOfLigtingRB = squareOfLighting.GetComponent<Rigidbody2D>();

                yield return new WaitForSeconds(0.5f);
                Destroy(squareOfLighting);
            }


        void puppeteer()
        {

                CoroutineHandler.Instance.StartRoutine(puppeteerAttackRay());
        }
            IEnumerator puppeteerAttackRay()
            {
                enemyProjectilePosition = GameObject.Find("ProjectilePosition");
                GameObject newLaser = Instantiate(enemyLaser, enemyProjectilePosition.transform.position, Quaternion.identity);

                player = GameObject.FindWithTag("Player");
                Rigidbody2D newLaserRB = newLaser.GetComponent<Rigidbody2D>();
                Collider2D newLaserC = newLaser.GetComponent<Collider2D>();

                yield return new WaitForSeconds(1f);
            }

        boss.DoAttack(2);
          

        }
    }
   
} 
    
   


