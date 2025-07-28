using UnityEngine;

public class CreateTower : MonoBehaviour {
	[SerializeField]
	private GameObject brickPrefab;

	[SerializeField]
	private float xDistance = 0.095f;
	[SerializeField]
	private float yDistance = 0.055f;

	[SerializeField]
	private int width = 3;
	[SerializeField]
	private int height = 15;
	[SerializeField]
	private float scale = 1.0f;

	private JengARGoal UI;

	void Start() {
		UI = FindFirstObjectByType<JengARGoal>();

		GenerateTower();
	}

	private void GenerateTower() {
		if(UI != null) {
			this.height = (int) UI.towerHeight.value;
		}

		bool rotated = false;

		float startingOffset = (xDistance * 0.5f) * (width - 1) * scale;

		for(int heightIter = 0; heightIter < height; heightIter += 1) {
			for(int widthIter = 0; widthIter < width; widthIter += 1) {
				GameObject go;
				Vector3 position;
				Quaternion rotation = Quaternion.identity;
				if(rotated) {
					go = Instantiate(brickPrefab);
					position = new Vector3(0, yDistance * heightIter * scale, (xDistance * widthIter * scale) - startingOffset);
					rotation = Quaternion.AngleAxis(90.0f, Vector3.up);
				} else {
					go = Instantiate(brickPrefab);
					position = new Vector3((xDistance * widthIter * scale) - startingOffset, yDistance * heightIter * scale, 0);
				}
				go.transform.parent = this.transform;
				go.transform.localPosition = position;
				go.transform.localRotation = rotation;
				go.transform.localScale = new Vector3(scale, scale, scale);
			}

			rotated = !rotated;
		}
	}
}
