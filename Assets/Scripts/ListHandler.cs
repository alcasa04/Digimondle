using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Rendering.CameraUI;

public class ListHandler : MonoBehaviour
{
    public string folderName = "MisPrefabs";

    public TMPro.TMP_InputField inputField;
    public Scrollbar scrollbar;

    public GameObject holder;
    Vector3 initHolder;
    float auxSum = 0f;
    public float distance = 50f;


    List<GameObject> digimons = new List<GameObject>();

    List<Digimon> guesses = new List<Digimon>();

    int auxList = 0;

    int numGuesses = 0;
    List<GameObject> guessesList = new List<GameObject>();


    public GameObject outPut;
    public GameObject actualDigiOutPut;

    Digimon randomDigi;


    public GameObject victory;

    void Start()
    {
        initHolder = holder.transform.localPosition;
        GameObject[] prefabs = Resources.LoadAll<GameObject>(folderName);

        foreach (GameObject prefab in prefabs)
        {
            Debug.Log("Prefab cargado: " + prefab.name);
            digimons.Add(prefab);
            // Puedes instanciarlo si quieres:
            // Instantiate(prefab);
        }
        inputField.onValueChanged.AddListener(digimonShower);
        randomDigi = digimons[Random.Range(0, digimons.Count)].GetComponent<Digimon>();


    }
    private void Update()
    {
        holder.transform.localPosition = new Vector3(holder.transform.localPosition.x, 
            initHolder.y+scrollbar.value*(-auxSum),
            holder.transform.localPosition.z);
    }

    public void digimonShower(string name)
    {
        auxSum = 30f;
        clearDropdown();
        foreach(GameObject auxDigi in digimons)
        {
            if(name != "" && auxDigi.name.ContainsInsensitive(name))
            {
                GameObject aux = Instantiate(auxDigi);
                aux.transform.Find("Image").GetComponent<Image>().sprite = auxDigi.GetComponent<Digimon>().sprite;
                aux.transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text = auxDigi.GetComponent<Digimon>().digimon_name;
                aux.transform.SetParent(holder.transform);
                RectTransform rectTransform = aux.GetComponent<RectTransform>();
                rectTransform.localPosition = new Vector3(0, auxSum, 0);
                rectTransform.localScale = new Vector3(1, 1, 1);

                auxSum -= distance;
            }
        }
    }

    public void clearDropdown()
    {
        scrollbar.value = 0;
        foreach (Transform child in holder.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void guess(Digimon digi)
    {
        clearDropdown();
        print("Llego");
        GameObject outAux = Instantiate(outPut);
        outAux.transform.SetParent(GameObject.Find("Vacio").transform);
        outAux.transform.localPosition = new Vector3(0, -100, 0);
        outAux.transform.localScale = new Vector3(1, 1, 1);

        outAux.transform.GetChild(0).transform.GetComponentInChildren<TextMeshProUGUI>().text = (digi.phase).ToString();
        outAux.transform.GetChild(1).transform.GetComponentInChildren<TextMeshProUGUI>().text = digi.type;
        outAux.transform.GetChild(2).transform.GetComponentInChildren<TextMeshProUGUI>().text = digi.attribute;
        outAux.transform.GetChild(3).transform.GetComponentInChildren<TextMeshProUGUI>().text = digi.family;
        outAux.transform.GetChild(4).transform.GetComponentInChildren<TextMeshProUGUI>().text = digi.yearDebut.ToString();
        outAux.transform.GetChild(5).transform.GetComponentInChildren<TextMeshProUGUI>().text = digi.color;

        if (digi.phase == randomDigi.phase)
        {
            outAux.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = (randomDigi.phase).ToString();
        }
        else
            outAux.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 0, 0, 1);
        if (digi.type == randomDigi.type)
        {
            outAux.transform.GetChild(1).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(1).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = randomDigi.type;
        }
        else
            outAux.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 0, 0, 1);
        if (digi.attribute == randomDigi.attribute)
        {
            outAux.transform.GetChild(2).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(2).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = randomDigi.attribute;
        }
        else
            outAux.transform.GetChild(2).GetComponent<Image>().color = new Color(1, 0, 0, 1);
        if (digi.family == randomDigi.family)
        {
            outAux.transform.GetChild(3).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(3).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().text = randomDigi.family;
        }
        else
            outAux.transform.GetChild(3).GetComponent<Image>().color = new Color(1, 0, 0, 1);
        if (digi.yearDebut == randomDigi.yearDebut)
        {
            outAux.transform.GetChild(4).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(4).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().text = randomDigi.yearDebut.ToString();
        }
        else
            outAux.transform.GetChild(4).GetComponent<Image>().color = new Color(1, 0, 0, 1);
        if (digi.color == randomDigi.color)
        {
            outAux.transform.GetChild(5).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(5).GetComponent<Image>().color = new Color(0, 1, 0, 1);
            actualDigiOutPut.transform.GetChild(5).GetComponentInChildren<TextMeshProUGUI>().text = randomDigi.color;
        }
        else
            outAux.transform.GetChild(5).GetComponent<Image>().color = new Color(1, 0, 0, 1);

        numGuesses++;
        guessesList.Add(outAux);
        for(int i=0; i < guessesList.Count; i++)
        {
            guessesList[guessesList.Count-1-i].transform.localPosition = new Vector3(0, -i * 100 -100, 0);
        }

        if(digi.digimon_name == randomDigi.digimon_name)
        {
            victory.gameObject.SetActive(true);
        }
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
