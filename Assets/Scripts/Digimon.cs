using UnityEngine;

public class Digimon : MonoBehaviour
{
    public enum Level {Baby, In_Training, Rookie, Champion, Ultimate, Mega};

    public string digimon_name;
    public Level phase;
    public string type;
    public string attribute;
    public string family;
    public int yearDebut;
    public string color;


    public Sprite sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void guess()
    {
        Debug.Log("Hit Name: " + digimon_name);
        GameObject.FindAnyObjectByType<ListHandler>().guess(this);
    }
}
