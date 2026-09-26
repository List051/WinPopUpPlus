
<p align="center">
  <img src="Logo.png" alt="Ital Pascal Logo" width="220">
</p>

<p align="center">
  Libreria di utilità per applicazioni VB.NET WinForms
</p>

<p align="center">

  <!-- NuGet -->
  <a href="https://www.nuget.org/packages/WinItalPascal">
    <img src="https://img.shields.io/nuget/v/WinItalPascal?style=for-the-badge" alt="NuGet Version">
  </a>
  <a href="https://www.nuget.org/packages/WinItalPascal">
    <img src="https://img.shields.io/nuget/dt/WinItalPascal?style=for-the-badge" alt="NuGet Downloads">
  </a>

  <!-- GitHub -->
  <img src="https://img.shields.io/github/stars/List051/WinItalPascal_Lib?style=for-the-badge" alt="Stars">
  <img src="https://img.shields.io/github/forks/List051/WinItalPascal_Lib?style=for-the-badge" alt="Forks">
  <img src="https://img.shields.io/github/issues/List051/WinItalPascal_Lib?style=for-the-badge" alt="Issues">
  <img src="https://img.shields.io/github/last-commit/List051/WinItalPascal_Lib?style=for-the-badge" alt="Last Commit">

  <!-- License -->
  <a href="https://github.com/List051/WinItalPascal_Lib/blob/main/License.txt">
    <img src="https://img.shields.io/github/license/List051/WinItalPascal_Lib?style=for-the-badge" alt="License">
  </a>

</p>


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
