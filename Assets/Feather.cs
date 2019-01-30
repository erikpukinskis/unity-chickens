// Builds a Mesh containing a single triangle with uvs.
// Create arrays of vertices, uvs and triangles, and copy them into the mesh.

using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Feather : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    Vector3 scale;
    Vector3 position;

    void Awake () {
        mesh = GetComponent<MeshFilter> ().mesh;
    }

    void Start()
    {
        MakeMeshData ();
        CreateMesh ();
    }


    int upSweep = 200;
    int upWidth = 400;
    int rachisBend = 200;
    int downSweep = 600;
    int tipWidth = 300;
    int length = 700;
    int curve = 100;

    void MakeMeshData () {
        vertices = new Vector3[] {
            new Vector3(0,0,0), // distal umbilicus
            new Vector3(0,curve,rachisBend), // mid rachis
            new Vector3(upWidth,0,upSweep), // up edge
            new Vector3(tipWidth,0,downSweep), // down edge
            new Vector3(0,0,length), // tip
            new Vector3(-upWidth,0,upSweep), // up edge
            new Vector3(-tipWidth,0,downSweep), // down edge
        };

        scale = new Vector3(0.12f, 0.12f, 0.12f);

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].Scale(scale);
        }

        // scale vertices by 0.12745
        // position -8, -70, 255
        int distalUmbilicus = 0;
        int midRachis = 1; 
        int upEdge = 2;
        int downEdge = 3;
        int tip = 4;
        int innerUpEdge = 5;
        int innerDownEdge = 6;

        triangles = new int[] {

            // outer vane

            distalUmbilicus,
            midRachis,
            upEdge,

            midRachis,
            downEdge,
            upEdge,

            tip,
            downEdge,
            midRachis,

            // inner vane

            distalUmbilicus,
            innerUpEdge,
            midRachis,

            midRachis,
            innerUpEdge,
            innerDownEdge,

            tip,
            midRachis,
            innerDownEdge,
        };
    }

    void CreateMesh () {
        mesh.Clear ();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
