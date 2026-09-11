
<p align="center">
  <img src="Logo.png" alt="Ital Pascal Logo" width="220">
</p>

<h1 align="center">WinItalPascal</h1>
<p align="center">
  Libreria di utilità per applicazioni VB.NET WinForms
</p>


[![NuGet Version](https://img.shields.io/nuget/v/WinItalPascal?style=for-the-badge)](https://www.nuget.org/packages/WinItalPascal) [![NuGet Downloads](https://img.shields.io/nuget/dt/WinItalPascal?style=for-the-badge)](https://www.nuget.org/packages/WinItalPascal) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)](https://github.com/List051/WinItalPascal_Lib/blob/main/License.txt) [![GitHub Pages](https://img.shields.io/badge/GitHub%20Pages-online-brightgreen?style=for-the-badge)](https://list051.github.io/WinVideoShowcase/)


# WinPopUp

* Inserito in libreria WinItalPascal che troverai in NuGet

WinPopUpPlus è una libreria .NET che permette di associare popup informativi ai controlli di un form Windows Forms.
Aggiunto opzione colora Sfondo e Testo 

## Installazione
Aggiungi la libreria `WinPopUpPlus.dll` al tuo progetto tramite **Riferimenti**.

## Utilizzo
Importa la libreria nel tuo codice:

```vbnet
Imports WinPopUpPlus

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Carica le immagini dalle risorse (My.Resources)
            Dim imgInfo As Image = My.Resources.cashier  ' Nome dell'immagine senza estensione
            Dim imgWarning As Image = My.Resources.calculator_50

            ' Associa i popup ai pulsanti
            PopupHelper.AttachPopup(Button1, "Informazioni utili" & vbCr & "Altre informazioni", imgInfo)
            PopupHelper.AttachPopup(Button2, "Attenzione! Controlla i dati", imgWarning)
			
			' Esempio colora Sfondo e Testo
			 Dim imgEsci As Image = My.Resources.exit_100
			 PopupHelper.AttachPopup(EsciPicture, "aiuto" & vbCrLf & "Esci dal programma", imgEsci, Color.GreenYellow, Color.Blue)
      
        Catch ex As Exception
            MessageBox.Show("Errore nel caricamento delle immagini: " & ex.Message)
        End Try
    End Sub
End Class
