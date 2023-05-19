using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using UnityEngine.InputSystem;

public class Assignments {
    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
}

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Keyboard kbd;
    public List<Assignments> assignments;
    

    void Start()
    {
        using (var client = new HttpClient())
        {           
            var task1 = Task.Run(() => client.GetAsync("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack"));
            task1.Wait();
            var response = task1.Result;
            var task2 = Task.Run(() => response.Content.ReadAsStringAsync());
            task2.Wait();
            string resp = task2.Result;
            this.assignments = JsonConvert.DeserializeObject<List<Assignments>>(resp);
            var prevposition_6 = new Vector3(4,0,5);
            var prevposition_7 = new Vector3(7, 0, 5);
            var prevposition_8 = new Vector3(4, 0, 8);
            int count = 0;
            int count_6 = 0;
            int count_7 = 0;
            int count_8 = 0;
            var plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane.transform.position = prevposition_6;
            
            Physics.autoSimulation = false;

            foreach (var ass in this.assignments)
            {
                //Thread.Sleep(1000);
                Debug.Log(ass.subject);
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
       
                //this.cubes.Add(cube);
                if (ass.grade == "6th Grade") {
                    int height = (int) count_6 / 4;
                    if (count_6 % 4 == 0)  cube.transform.position = new Vector3(prevposition_6.x, prevposition_6.y + (float) (height+.5)*cube.transform.lossyScale.y, prevposition_6.z);
                    if (count_6 % 4 == 1) cube.transform.position = new Vector3(prevposition_6.x + cube.transform.lossyScale.x, prevposition_6.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_6.z);
                    if (count_6 % 4 == 2) cube.transform.position = new Vector3(prevposition_6.x, prevposition_6.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_6.z + cube.transform.lossyScale.z);
                    if (count_6 % 4 == 3) cube.transform.position = new Vector3(prevposition_6.x + cube.transform.lossyScale.x, prevposition_6.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_6.z + cube.transform.lossyScale.z);
                }
                if (ass.grade == "7th Grade")
                {
                    int height = (int)count_7 / 4;
                    if (count_7 % 4 == 0) cube.transform.position = new Vector3(prevposition_7.x, prevposition_7.y + (float) (height +.5) * cube.transform.lossyScale.y, prevposition_7.z);
                    if (count_7 % 4 == 1) cube.transform.position = new Vector3(prevposition_7.x + cube.transform.lossyScale.x, prevposition_7.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_7.z);
                    if (count_7 % 4 == 2) cube.transform.position = new Vector3(prevposition_7.x, prevposition_7.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_7.z + cube.transform.lossyScale.z);
                    if (count_7 % 4 == 3) cube.transform.position = new Vector3(prevposition_7.x + cube.transform.lossyScale.x,  prevposition_7.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_7.z + cube.transform.lossyScale.z);
                }
                if (ass.grade == "8th Grade") {
                    int height = (int)count_8 / 4;
                    if (count_8 % 4 == 0) cube.transform.position = new Vector3(prevposition_8.x, prevposition_8.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_8.z);
                    if (count_8 % 4 == 1) cube.transform.position = new Vector3(prevposition_8.x + cube.transform.lossyScale.x, prevposition_8.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_8.z);
                    if (count_8 % 4 == 2) cube.transform.position = new Vector3(prevposition_8.x, prevposition_8.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_8.z + cube.transform.lossyScale.z);
                    if (count_8 % 4 == 3) cube.transform.position = new Vector3(prevposition_8.x + cube.transform.lossyScale.x, prevposition_8.y + (float) (height+.5) * cube.transform.lossyScale.y, prevposition_8.z + cube.transform.lossyScale.z);
                }
                if (ass.mastery == 0) { cube.GetComponent<Renderer>().material.color = Color.red; cube.tag = "red"; }
                if (ass.mastery == 1) { cube.GetComponent<Renderer>().material.color = Color.yellow; cube.tag = "yellow"; }
                if (ass.mastery == 2) { cube.GetComponent<Renderer>().material.color = Color.green; cube.tag = "green"; }

                    Rigidbody rb = cube.AddComponent(typeof(Rigidbody)) as Rigidbody;
                rb.mass = 0.0001f;
                count = count + 1;
                //if (count == 5) break;
                if (ass.grade == "6th Grade") count_6 = count_6 + 1;
                if (ass.grade == "7th Grade") count_7 = count_7 + 1;
                if (ass.grade == "8th Grade") count_8 = count_8 + 1;
            

               /* if (ass.grade == "6th Grade" && count_6 > 8) {
                    prevposition_6.y -= cube.transform.lossyScale.y;
                    Destroy(cube);
                }
                if (ass.grade == "7th Grade" && count_7 > 8) {
                    prevposition_7.y -= cube.transform.lossyScale.y;
                    Destroy(cube);
                }
                if (ass.grade == "8th Grade" && count_8 > 8) {
                    prevposition_8.y -= cube.transform.lossyScale.y;
                    Destroy(cube);
                }*/


            }

        }
        //Thread.Sleep(10000);
        Physics.autoSimulation = true;
        kbd = Keyboard.current;
    }

    // Update is called once per frame
    void Update()
    {
       if (kbd.wKey.isPressed)
       {
            GameObject[] arrayofcubes = GameObject.FindGameObjectsWithTag("red");

            foreach(var cube in arrayofcubes)
            {
                Destroy(cube);
            }
        }
    }
}
