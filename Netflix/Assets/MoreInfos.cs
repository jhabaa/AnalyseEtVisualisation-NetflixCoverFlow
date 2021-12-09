using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreInfos : MonoBehaviour
{
    public TextAsset csv;
    private string[][] grid;
    

    // Start is called before the first frame update
    void Start()
    {
        grid = CsvParser2.Parse(csv.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z >= -20.6 && this.transform.position.x <= 0.4f && this.transform.position.x >= 0.2f)
        {
            Vector3 largeSize = new Vector3(this.transform.position.x,
                                                    this.transform.position.y,
                                                    this.transform.position.z - 0.1f);
            this.transform.position = Vector3.MoveTowards(this.transform.position, largeSize, 1f * Time.deltaTime);
        }
        if(Input.GetMouseButton(0) == true)
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
}
