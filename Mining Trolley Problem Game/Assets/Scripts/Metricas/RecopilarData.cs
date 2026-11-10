using ClosedXML.Excel;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class DatosMetricas
{
    public string tipo;
    public string idJugador;
    public string generoFavorito;
    public string idDecision;
    public double latenciaMs;
    public bool riesgo;
}

public class RecopilarData : MonoBehaviour
{
    string idJugadorLocal;
    int contadorDecisiones = 0;
    static RecopilarData instancia;
    private const string URL_GOOGLE_SHEETS =
    "https://script.google.com/macros/s/AKfycbwLaj1WvS-jF79xnw7y-Cy-7PmVKvF6TDSKD5FOAdXDSLthaKH75peFHL7ZbYfIumzj/exec";

    void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;

        DontDestroyOnLoad(gameObject);

    }

    public string RegistrarJugador(string generoFavorito)
    {
        string id = "J" +
            Guid.NewGuid().ToString("N").Substring(0, 8);

        idJugadorLocal = id;

        DatosMetricas datos = new DatosMetricas
        {
            tipo = "jugador",
            idJugador = id,
            generoFavorito = generoFavorito
        };

        StartCoroutine(EnviarDatos(datos));

        return idJugadorLocal;
    }

    public void RegistrarDecision(double latenciaSegundos, bool riesgoElegido)
    {
        contadorDecisiones++;
        string idDecision = "D" + contadorDecisiones.ToString("D2");

        DatosMetricas datos = new DatosMetricas
        {
            tipo = "decision",
            idJugador = idJugadorLocal,
            idDecision = idDecision,
            latenciaMs = latenciaSegundos * 1000.0,
            riesgo = riesgoElegido
        };

        StartCoroutine(EnviarDatos(datos));
    }

    //private XLWorkbook AbrirWorkbook()
    //{
    //    if (File.Exists(filePath))
    //        return new XLWorkbook(filePath);

    //    return new XLWorkbook();
    //}

    //private IXLWorksheet ObtenerHoja(XLWorkbook workbook, string nombre, string[] encabezados)
    //{
    //    var hoja = workbook.Worksheets
    //        .FirstOrDefault(x => x.Name == nombre);

    //    if (hoja == null)
    //    {
    //        hoja = workbook.Worksheets.Add(nombre);

    //        for (int i = 0; i < encabezados.Length; i++)
    //        {
    //            hoja.Cell(1, i + 1).Value = encabezados[i];
    //            hoja.Cell(1, i + 1).Style.Font.Bold = true;
    //        }
    //    }

    //    return hoja;
    //}

    public IEnumerator EnviarDatos(DatosMetricas datos)
    {
        string json = JsonUtility.ToJson(datos);

        byte[] body = Encoding.UTF8.GetBytes(json);

        using (UnityWebRequest request =
            new UnityWebRequest(URL_GOOGLE_SHEETS, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(body);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Datos enviados: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error al enviar datos: " + request.error);
            }
        }
    }
}

