﻿using UnityEngine;
using UnityEngine.UI;

public class HexGridChunk : MonoBehaviour {

	HexCell[] cells;

	HexMesh hexMesh;
	Canvas gridCanvas;

	void Awake () {
		gridCanvas = GetComponentInChildren<Canvas>();
		hexMesh = GetComponentInChildren<HexMesh>();

		cells = new HexCell[HexMetrics.chunkSizeX * HexMetrics.chunkSizeZ];
	}

	public void AddCell (int index, HexCell cell) {
		cells[index] = cell;
		cell.chunk = this;
		cell.transform.SetParent(transform, false);
		cell.uiRect.SetParent(gridCanvas.transform, false);
	}

	public void Refresh () {
		enabled = true;
	}

	void LateUpdate () {
		hexMesh.Triangulate(cells);
		enabled = false;
	}
}