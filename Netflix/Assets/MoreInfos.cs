using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreInfos : MonoBehaviour
{
    public TextAsset csv;
    private string[][] grid;
    RaycastHit hit;
    public Camera camera;
    private Vector3 cameraCenter;
    private Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        grid = CsvParser2.Parse(csv.text);
        cameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, camera.nearClipPlane));
        originalScale = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (this.transform.position.z >= -20.8 && this.transform.position.x <= 110.4f && this.transform.position.x >= 90.2f)
        {
            Vector3 largeSize = new Vector3(this.transform.position.x,
                                                    this.transform.position.y,
                                                    this.transform.position.z - 0.1f);
            this.transform.position = Vector3.MoveTowards(this.transform.position, largeSize, 1f * Time.deltaTime);
            
        }*/
        /*if(Physics.Raycast(cameraCenter, this.transform.forward, out hit, 1000))
        {
            print("New Card");
        }*/


        /*
        rotating = true;
        Quaternion startRotation = objectToRotate.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            objectToRotate.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        objectToRotate.transform.rotation = endRotation;
        rotating = false;
        */
        if (Input.GetMouseButton(0) == true)
        {
            
        }
    }
    private void OnMouseEnter()
    {
        //this.transform.localScale = this.transform.localScale * 1.002f;
      /*  this.transform.localPosition = new Vector3(this.transform.localPosition.x,
                                                    this.transform.localPosition.y,
                                                    this.transform.localPosition.z - 0.6f);*/
        
    }
    private void OnMouseExit()
    {
        
        //this.transform.localScale = this.transform.localScale / 1.002f;
    }
    private void OnMouseDown()
    {
        /*
        Vector3 direction = new Vector3(-50, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        Quaternion targetRotation = Quaternion.Euler(direction);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 1);*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "cast")
        {
            print("Cast Enter");
            this.transform.Rotate(0f, 0f, 60f);
            //StartCoroutine(rotatePanel());

            /*
             * GameObject g = this.gameObject;
             originalScale = g.transform.localScale;
             var newScale = new Vector3(g.transform.localScale.x*1.2f, g.transform.localScale.y * 1.2f, g.transform.localScale.z * 1.2f);
             g.transform.localScale = newScale;
             */
            /*Vector3 largeSize = new Vector3(this.transform.position.x,
                                                   this.transform.position.y,
                                                   this.transform.position.z -10.0f);
            this.transform.position = Vector3.MoveTowards(this.transform.position, largeSize, 2f * Time.deltaTime);*/


        }
        
    }
    IEnumerator rotatePanel()
    {
        Vector3 direction = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 300f);
        Quaternion targetRotation = Quaternion.Euler(direction);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 50f);

        yield return null;
    }
    IEnumerator rotatePanelCounterClock()
    {
        Vector3 direction = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -300f);
        Quaternion targetRotation = Quaternion.Euler(direction);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 50f);

        yield return null;
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "cast")
        {
            print("exit");
            this.transform.Rotate(0f, 0f, -60f);
            //rotatePanelCounterClock();
        }
        /*{
            print("Cast exit");
            Vector3 largeSize = new Vector3(this.transform.position.x,
                                                   this.transform.position.y,
                                                   this.transform.position.z - 15f);
            this.transform.position = Vector3.MoveTowards(this.transform.position, largeSize, 200f * Time.deltaTime);

        }*/

    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 moveVector = new Vector3(0f, 0f, 2f);
        Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), collision.collider, true);
        if (this.transform.position.z < 10f & collision.collider.tag == "cast")
        {
            print("Moving");
            this.transform.position -= moveVector;
            

        }
        


    }


}
