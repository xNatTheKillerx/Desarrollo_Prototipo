using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using TMPro;

public class questionSelector : MonoBehaviour
{
    InitialData problemascr;
     
    public Text problemlabel;
    public Transform pos;
    public string[] problemasTry;
    public string[] problemas; //Arreglo que contendra las respuestas de la pirmera pregunta
    int  problema = 0; //Variable que obtendra un elemento del arreglo
    public GameObject ButtonstoInstantiate;
    public GameObject[]objectsToInstantiate;
    public GameObject bien;
    public GameObject mal;
    GameObject temp;
    GameObject temp2;
    public GameObject buttonFrac;
   
    public GameObject imagenFrac;

    float time;
    float timeDelay;

    public TMP_Text puntos;
    
    public int n;
   
    void awake(){ 
       
        problemascr=FindObjectOfType<InitialData>();
      
    }
    void Start()
    {
        
        randomButtons();
        temp = Instantiate(objectsToInstantiate[n]);
        temp2 = Instantiate(ButtonstoInstantiate);
        //mal.SetActive(false);
        //bien.SetActive(false);

    }

    public void instantiateObject(){
        Debug.Log("Objeto"+n);
        
        
    }
    public void randomButtons(){
        problemas= new string[20];
        problemasTry= new string[4];
        problemas[0]="1/2"; 
        problemas[1]="1/3";
        problemas[2]="2/8";
        problemas[3]="2/5";
        problemas[4]="4/7";
        problemas[5]="1/8";
        problemas[6]="7/4"; 
        problemas[7]="2/6";
        problemas[8]="6/6";
        problemas[9]="1/4";
        problemas[10]="10/8";
        problemas[11]="4/6";
        problemas[12]="4/5"; 
        problemas[13]="1/5";
        problemas[14]="1/9";
        problemas[15]="3/8";
        problemas[16]="3/3";
        problemas[17]="3/12";
        problemas[18]="7/10"; 
        problemas[19]="6/8";

        problemasTry[0]=""; 
        problemasTry[1]="";
        problemasTry[2]="";
        problemasTry[3]="";
        
        
        bool repetido=false;
        int indice=0;
        int m=Random.Range(0,4);
        while(indice<problemasTry.Length){
            repetido=false;
            n= Random.Range(0,20);
            for(int j=0; j<problemasTry.Length ;j++)
            {
                
                if (problemasTry[j]==problemas[n]){
                        repetido=true;
                    
                    }
            }
                if(!repetido){
                     
                    
                    problemasTry[indice]=problemas[n];
                    buttonFrac = Instantiate(ButtonstoInstantiate,  new Vector2((indice+1)*180,200), pos.transform.rotation) as GameObject;  
                    buttonFrac.name = ("button"+indice.ToString());
                    GameObject.Find("button"+indice.ToString()).GetComponentInChildren<Text>().text = problemasTry[indice];
                    buttonFrac.transform.parent=pos.transform;
                    
                    if (indice==m){
                        imagenFrac = Instantiate(objectsToInstantiate[n], pos.position, pos.transform.rotation) as GameObject;
                        imagenFrac.transform.parent=pos.transform;
                    
                        buttonFrac.GetComponent<Button>().onClick.AddListener(() => Invoke("seleccion", 1.0f));
                        
                    
                }
                    else
                    {
                    
                    buttonFrac.GetComponent<Button>().onClick.AddListener(() => Invoke("malSeleccion", 1.0f));
                    
                }
                    indice++;
                }
        }
        
    }

    public void seleccion()
    {
        bien.SetActive(true);
        
                mal.SetActive(false);
        //SceneManager.LoadScene("seleccion");

        for (int h = 0; h < 4; h++)
        {
            Destroy(buttonFrac = GameObject.Find("button" + h.ToString()));
            buttonFrac.name = "";
        }
        problema = problema + 1;
        puntos.text = problema.ToString();
        print(problema);
        Invoke("eliminar", 1.0f);
        print("Bien");
    }

    public void malSeleccion()
    {
        mal.SetActive(true);
        
           

        for (int h = 0; h < 4; h++)
        {
            Destroy(buttonFrac = GameObject.Find("button" + h.ToString()));
            buttonFrac.name = "";
        }
        // SceneManager.LoadScene("seleccion");
        Invoke("eliminar", 1.0f);
        print("Respuesta equivocada intenta otra vez");
    }

    public void eliminar()
    {
        mal.SetActive(false);
        bien.SetActive(false);
        Destroy(imagenFrac);
        randomButtons();

        //Destroy(buttonFrac);
      
    }

    public void escena()
    {
        SceneManager.LoadScene("seleccion");
    }

    // Update is called once per frame
    void Update()
    {
        if(problema>=10)
        {
            SceneManager.LoadScene("Reto");
        }
    }
}
