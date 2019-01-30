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
        vertices = new Vector3[] { new Vector3(0,0,0), new Vector3(0,0,1), new Vector3(1,0,0) };

        triangles = new int[] { 0, 1, 2 };
    }

    void CreateMesh () {
        mesh.Clear ();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
