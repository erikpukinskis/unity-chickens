// Builds a Mesh containing a single triangle with uvs.
// Create arrays of vertices, uvs and triangles, and copy them into the mesh.

using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Feather : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    void Awake () {
        mesh = GetComponent<MeshFilter> ().mesh;
    }

    void Start()
    {
        MakeMeshData ();
        CreateMesh ();
    }


    int upSweep = 2;
    int upWidth = 4;
    int rachisBend = 2;
    int downSweep = 6;
    int tipWidth = 3;
    int length = 7;

    void MakeMeshData () {
        vertices = new Vector3[] {
            new Vector3(0,0,0),
            new Vector3(0,0,rachisBend), // mid rachis
            new Vector3(upWidth,0,upSweep), // up edge
            new Vector3(tipWidth,0,downSweep), // down edge
            new Vector3(0,0,length)
        };

        int distalUmbilicus = 0;
        int midRachis = 1; 
        int upEdge = 2;
        int downEdge = 3;
        int tip = 4;
        int leftUpEdge = 5;

        triangles = new int[] {
            distalUmbilicus,
            midRachis,
            upEdge,

            midRachis,
            downEdge,
            upEdge,

            tip,
            downEdge,
            midRachis,
        };
    }

/*
    void MakeMeshData () {

vertices = new Vector3[] {
    new Vector3(0,0,0),
    new Vector3(upWidth, upSweep, 0),
    new Vector3(0, rachisBend, 0),
    new Vector3(tipWidth, downSweep, 0),
    new Vector3(0, downSweep + tipLength)
};

        triangles = new int[] {
            distalUmbilicus,
            upEdge,
            midRachis,

            midRachis,
            upEdge,
            downEdge,

            midRachis,
            downEdge,
            tip,
        };
    }

*/
    void CreateMesh () {
        mesh.Clear ();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
