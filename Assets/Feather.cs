// Builds a Mesh containing a single triangle with uvs.
// Create arrays of vertices, uvs and triangles, and copy them into the mesh.

using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Feather : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    int upWidth = 4;
    int rachisBend = 2;
    int downSweep = 2;
    int upSweep = 6;
    int tipWidth = 3;
    int tipLength = 1;

    void Awake () {
        mesh = GetComponent<MeshFilter> ().mesh;
    }

    void Start()
    {
        MakeMeshData ();
        CreateMesh ();
    }


    void MakeMeshData () {
        vertices = new Vector3[] {
            new Vector3(0,0,0),
            new Vector3(upWidth, upSweep, 0),
            new Vector3(0, rachisBend, 0),
            new Vector3(tipWidth, downSweep, 0),
            new Vector3(0, downSweep + tipLength)
        };


        int distalUmbilicus = 0;
        int upEdge = 1;
        int midRachis = 2; 
        int downEdge = 3;
        int tip = 4;

        triangles = new int[] { distalUmbilicus,
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

    void CreateMesh () {
        mesh.Clear ();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
