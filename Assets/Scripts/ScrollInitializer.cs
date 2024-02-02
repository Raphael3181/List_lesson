using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LoopScrollRect))]
[DisallowMultipleComponent]
public abstract class ScrollInitializer : MonoBehaviour, LoopScrollPrefabSource, LoopScrollDataSource {

	public GameObject item;
	public LoopScrollRect scroll;

	// Implement your own Cache Pool here. The following is just for example.
	private Stack<Transform> pool = new Stack<Transform>();
	public GameObject GetObject(int index) {
		if (pool.Count == 0) {
			return GetItem();
		}
		Transform candidate = pool.Pop();
		candidate.gameObject.SetActive(true);
		return candidate.gameObject;
	}

	protected virtual GameObject GetItem() {
		return Instantiate(item);
	}

	public void ReturnObject(Transform trans) {
		// Use `DestroyImmediate` here if you don't need Pool
		trans.SendMessage("ScrollCellReturn", SendMessageOptions.DontRequireReceiver);
		trans.gameObject.SetActive(false);
		trans.SetParent(transform, false);
		pool.Push(trans);
	}

	public abstract void ProvideData(Transform transform, int idx);

	public abstract void SetTotalCount();

	public virtual void Init() {
		pool.Clear();
		SetTotalCount();
		scroll.prefabSource = this;
		scroll.dataSource = this;
		scroll.RefillCells();
	}
}