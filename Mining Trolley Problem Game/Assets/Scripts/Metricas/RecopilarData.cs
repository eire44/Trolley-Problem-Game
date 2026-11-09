using UnityEngine;
using System;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

public class RecopilarData : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        filePath = Path.Combine(
            Application.persistentDataPath,
            "MetricasJugadores.xlsx"
        );
    }

    public string RegistrarJugador(string generoFavorito)
    {
        string idJugador = "J" +
            Guid.NewGuid().ToString("N").Substring(0, 8);

        using (var workbook = AbrirWorkbook())
        {
            var hoja = ObtenerHoja(workbook, "Jugadores",
                new string[] { "ID_Jugador", "Genero_Favorito" });

            int fila = (hoja.LastRowUsed()?.RowNumber() ?? 1) + 1;

            hoja.Cell(fila, 1).Value = idJugador;
            hoja.Cell(fila, 2).Value = generoFavorito;

            workbook.SaveAs(filePath);
        }

        return idJugador;
    }

    public void RegistrarDecision(
        string idJugador,
        string idDecision,
        double latenciaSegundos,
        string alternativaElegida)
    {
        using (var workbook = AbrirWorkbook())
        {
            var hoja = ObtenerHoja(workbook, "Decisiones",
                new string[] {
                    "ID_Jugador",
                    "ID_Decision",
                    "Latencia_ms",
                    "Alternativa"
                });

            int fila = (hoja.LastRowUsed()?.RowNumber() ?? 1) + 1;

            hoja.Cell(fila, 1).Value = idJugador;
            hoja.Cell(fila, 2).Value = idDecision;
            hoja.Cell(fila, 3).Value = latenciaSegundos * 1000.0;
            hoja.Cell(fila, 4).Value = alternativaElegida;

            workbook.SaveAs(filePath);
        }
    }

    private XLWorkbook AbrirWorkbook()
    {
        if (File.Exists(filePath))
            return new XLWorkbook(filePath);

        return new XLWorkbook();
    }

    private IXLWorksheet ObtenerHoja(
        XLWorkbook workbook,
        string nombre,
        string[] encabezados)
    {
        var hoja = workbook.Worksheets
            .FirstOrDefault(x => x.Name == nombre);

        if (hoja == null)
        {
            hoja = workbook.Worksheets.Add(nombre);

            for (int i = 0; i < encabezados.Length; i++)
            {
                hoja.Cell(1, i + 1).Value = encabezados[i];
                hoja.Cell(1, i + 1).Style.Font.Bold = true;
            }
        }

        return hoja;
    }
}

