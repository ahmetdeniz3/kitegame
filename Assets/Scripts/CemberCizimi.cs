using UnityEngine;

public class CemberCizimi : MonoBehaviour
{
    [Header("Çember Ayarlarý")]
    public float yaricap = 2f;
    public int segmentSayisi = 50; // Çember ne kadar pürüzsüz olacak
    public Color renk = Color.white;
    public float cizgiKalinligi = 0.1f;
    public Material cizgiMateriali;

    private LineRenderer lineRenderer;

    void Start()
    {
        CemberOlustur();
    }

    void CemberOlustur()
    {
        // LineRenderer bileþeni ekle
        lineRenderer = gameObject.AddComponent<LineRenderer>();

        // Material ayarý
        if (cizgiMateriali == null)
            cizgiMateriali = new Material(Shader.Find("Sprites/Default"));

        lineRenderer.material = cizgiMateriali;

        lineRenderer.startWidth = cizgiKalinligi;
        lineRenderer.endWidth = cizgiKalinligi;
        lineRenderer.sortingOrder = 1;
        lineRenderer.useWorldSpace = true;

        // Çember noktalarýný hesapla
        CemberNoktalariniHesapla();
    }

    void CemberNoktalariniHesapla()
    {
        // Segment sayýsý + 1 (son nokta baþlangýçla ayný olacak)
        lineRenderer.positionCount = segmentSayisi + 1;

        for (int i = 0; i <= segmentSayisi; i++)
        {
            // Her segmentin açýsýný hesapla
            float aci = (float)i / segmentSayisi * 2 * Mathf.PI;

            // X ve Y koordinatlarýný hesapla
            float x = Mathf.Cos(aci) * yaricap;
            float y = Mathf.Sin(aci) * yaricap;

            // Objenin kendi pozisyonuna göre nokta belirle
            Vector3 nokta = transform.position + new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, nokta);
        }
    }

    // Çemberi güncelle (runtime'da deðiþiklik için)
    public void CemberiGuncelle()
    {
        if (lineRenderer != null)
        {
            CemberNoktalariniHesapla();
        }
    }

    // Yarýçapý deðiþtir
    public void YaricapiDegistir(float yeniYaricap)
    {
        yaricap = yeniYaricap;
        CemberiGuncelle();
    }

    // Rengi deðiþtir
    public void RengiDegistir(Color yeniRenk)
    {
        renk = yeniRenk;;
    }

    // Inspector'da deðerler deðiþtiðinde otomatik güncelle
    void OnValidate()
    {
        if (Application.isPlaying && lineRenderer != null)
        {
            lineRenderer.startWidth = cizgiKalinligi;
            lineRenderer.endWidth = cizgiKalinligi;
            CemberiGuncelle();
        }
    }
}
