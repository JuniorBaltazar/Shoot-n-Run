using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.PlatformManager;

public class GeneratePlatform : MonoBehaviour {

    [SerializeField] private SO_PlatformManager platformManager = null;
    [SerializeField] private Transform platformBag = null;

    private float maxOffset = 0;
    private List<GameObject> platformList = new List<GameObject>();

    #region MonoBehaviour
    private void Start() {
        this.CreatePlatform();
    }

    private void Update() {
        this.ActivePlatform();
    }
    #endregion

    //<<----------------------->>\\

    #region Create Platform
    /// <summary>
    /// Instancia as plataformas na cena.
    /// </summary>
    private void CreatePlatform () {
        for (byte i = 0; i < this.platformManager.platformPrefabList.Count; i++) {
            GameObject platformObj = Instantiate(this.platformManager.platformPrefabList[i], Vector3.zero, Quaternion.identity, this.platformBag);
            platformObj.SetActive(true);

            this.platformList.Add(platformObj);
            this.SetMaxOffsetValue(platformObj);

            if (i > 0)
                this.InitialPosition(i);
        }       
    }
    #endregion

    #region Initial Position
    /// <summary>
    /// Posiciona as plataformas no momento que são instanciadas.
    /// </summary>
    /// <param name="indexPlatform">Índce da plataforma dentro da lista (platformList).</param>
    private void InitialPosition(byte indexPlatform) {
        GameObject currentPlatform = this.platformList[indexPlatform];
        GameObject pastPlatform = this.platformList[indexPlatform - 1];

        MeshRenderer currentMesh = currentPlatform.GetComponent<MeshRenderer>();
        MeshRenderer pastMesh = pastPlatform.GetComponent<MeshRenderer>();

        float offset = (currentMesh.bounds.size.z + pastMesh.bounds.size.z) / 2;
        Vector3 initialPos = pastPlatform.transform.position + (Vector3.forward * offset);

        currentPlatform.transform.position = initialPos;        
    }
    #endregion

    //<<----------------------->>\\

    #region Active Platform
    /// <summary>
    /// Ativa as plataformas quando o player ultrapassa-as.
    /// </summary>
    private void ActivePlatform () {
        for (byte i = 0; i < this.platformList.Count; i++) {

            if (!this.platformList[i].gameObject.activeInHierarchy) {
                this.platformList[i].gameObject.SetActive(true);

                this.NewPosPlatform(i);

                //Ativas os filhos da plataforma (EX.: Obstáculos)
                for (int c = 0; c < this.platformList[i].transform.childCount; c++) {
                    this.platformList[i].transform.GetChild(c).gameObject.SetActive(true);
                }
                break;
            }
        }
    }
    #endregion

    #region New Pos Platform
    /// <summary>
    /// Posiciona as plataformas que o player já ultrapassou.
    /// </summary>
    /// <param name="indexPlatform">Índce da plataforma dentro da lista (platformList).</param>
    private void NewPosPlatform (byte indexPlatform) {        
        Vector3 newPos = Vector3.forward * this.maxOffset;
        this.platformList[indexPlatform].transform.position += newPos;
    }
    #endregion

    #region Set Max Offset Value
    /// <summary>
    /// Define a distância em que a plataforma será posicionada DURANTE o jogo.
    /// </summary>
    /// <param name="platform">Plataforma instanciada no jogo.</param>
    private void SetMaxOffsetValue(GameObject platform) {
        MeshRenderer mesh = platform.GetComponent<MeshRenderer>();
        this.maxOffset += mesh.bounds.size.z;
    }
    #endregion
}