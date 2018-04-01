using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametricSurface : MonoBehaviour {

    public string txtFile;
    private string[] objectSpecification;
    private int specificationPointer = 0;


    // Use this for initialization
    void Start()
    {
        TextAsset txtAssets = (TextAsset)Resources.Load(txtFile);
        string[] splitBy = { System.Environment.NewLine, " " };
        objectSpecification = txtAssets.text.Split(splitBy, System.StringSplitOptions.RemoveEmptyEntries);

        //Actual Object
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        //Vertices
        int verticesCount = parseAndMove(objectSpecification[specificationPointer]);
        Vector3[] vertices = new Vector3[verticesCount];
        for (int i = 0; i < verticesCount; ++i)
        {
            vertices[i] = new Vector3((float)parseAndMove(objectSpecification[specificationPointer]), (float)parseAndMove(objectSpecification[specificationPointer]), (float)parseAndMove(objectSpecification[specificationPointer]));
        }

        //Triangles
        int[] triangles = new int[42];
        int trianglesCount = parseAndMove(objectSpecification[specificationPointer]);
        for (int i = 0; i < trianglesCount; ++i)
        {
            triangles[i] = parseAndMove(objectSpecification[specificationPointer]);
            //Debug.Log(triangles[i]);
        }

        //Normals (needed to display objects in the game)
        //Vector3[] normals = new Vector3[9];

        //UVs (how textures are displayed)

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }

    int parseAndMove(string specification)
    {
        int front;
        int.TryParse(specification, out front);
        ++specificationPointer;
        return front;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
