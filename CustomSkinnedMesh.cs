using UnityEngine;
using System.Collections;

public class CustomSkinnedMesh : MonoBehaviour {

    public Material mat;
    public Transform[] bones;
	// Use this for initialization
	void Start () {

        Mesh m = new Mesh();
        m.vertices = new Vector3[]
        {
            new Vector3(0.0f,0.0f,0.0f),
            new Vector3(-3.0f,6.0f,0.0f),
            new Vector3(3.0f,6.0f,0.0f),
            new Vector3(-4.0f,2.0f,0.0f),
            new Vector3(-6.0f,3.0f,0.0f),
            new Vector3(4.0f,2.0f,0.0f),
            new Vector3(6.0f,3.0f,0.0f),
            new Vector3(-3.0f,-6.0f,0.0f),
            new Vector3(-6.0f,-6.0f,0.0f),
            new Vector3(3.0f,-6.0f,0.0f),
            new Vector3(6.0f,-6.0f,0.0f)
        };

        m.triangles = new int[] {0,1,2,3,4,1,5,2,6,7,8,0,9,10,0        };
        m.bindposes = new Matrix4x4[]
        {
            bones[0].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[1].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[2].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[3].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[4].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[5].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[6].worldToLocalMatrix * transform.localToWorldMatrix
        };

        m.boneWeights = new BoneWeight[]
        {
           new BoneWeight() { boneIndex0 = 0, weight0 = 1f },
           new BoneWeight() { boneIndex0 = 1, weight0 = 1f },
           new BoneWeight() { boneIndex0 = 2, weight0 = 1f },
           new BoneWeight() { boneIndex0 = 3, weight0 = 1f },
           new BoneWeight() { boneIndex0 = 3, weight0 = 0f },
           new BoneWeight() { boneIndex0 = 4, weight0 = 1f },
           new BoneWeight() { boneIndex0 = 4, weight0 = 0f },
           new BoneWeight() { boneIndex0 = 5, weight0 = 1f },
           new BoneWeight() { boneIndex0 = 5, weight0 = 0f },
           new BoneWeight() { boneIndex0 = 6, weight0 = 1f },
           new BoneWeight() { boneIndex0 = 6, weight0 = 0f }
        };

        SkinnedMeshRenderer sar = GetComponent<SkinnedMeshRenderer>();
        sar.sharedMesh = m;
        sar.sharedMaterial = mat;
        sar.bones = bones;
        sar.rootBone = transform;
        sar.quality = SkinQuality.Bone1;
        //sar.quality = SkinQuality.Bone2;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
