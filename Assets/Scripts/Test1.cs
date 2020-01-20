using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
    {
    public int a;
    public int b;
    public int c;
    public int f;
    public int sum;
    public int ammountOfGrades = 0;
    public int average;
    void Start()
        {
        a = Random.Range(86, 100);
        b = Random.Range(75, 86);
        c = Random.Range(50, 75);
        f = Random.Range(0, 75);

        }

    // Update is called once per frame
    void Update()
        {
        if (Input.GetKeyDown(KeyCode.A)) {
            CalculateGrade(a);
            Debug.Log(average);
            }
        else if (Input.GetKeyDown(KeyCode.B))
            {
            CalculateGrade(b);
            Debug.Log(average);
            }
        else if (Input.GetKeyDown(KeyCode.C))
            {
            CalculateGrade(c);
            Debug.Log(average);
            }
        else if (Input.GetKeyDown(KeyCode.F))
            {
            CalculateGrade(f);
            Debug.Log(average);
            }

        }
    public int CalculateGrade(int grade)
        {
        sum += grade;
        ammountOfGrades++;
        average = sum / ammountOfGrades;
        return average;
        }
        
        
    }
       
        

