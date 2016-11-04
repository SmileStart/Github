using UnityEngine;
using System.Collections;

public class TestPool : MonoBehaviour {

	public GameObject cubePre;
	public GameObject spherePre;


	Vector3 cubePos = Vector3.zero;
	Vector3 spherePos = Vector3.zero;


	void Start () {
		InvokeRepeating ("CreateTest", 1F, 0.5F);
		StartCoroutine (RecoverTest());
	}


	void CreateTest(){
	
		PoolManager.PoolsArray ["Cubes"].BirthGameObject (cubePre, cubePos, Quaternion.identity);
		PoolManager.PoolsArray ["Spheres"].BirthGameObject (spherePre, spherePos, Quaternion.identity);
		cubePos += 2 *  Vector3.right;     //向右
		spherePos += 2 * Vector3.forward;  //向前


	}


	IEnumerator RecoverTest(){
		yield return new WaitForSeconds (10f);
		CancelInvoke ();
	}

	void OnDestroy(){
		StopAllCoroutines ();
	}


}
