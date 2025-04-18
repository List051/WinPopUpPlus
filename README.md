# WinPopUpPlus

🎬 **Demo Video:** [Guarda su YouTube](https://youtu.be/4EyZb3B9hFM)

WinPopUpPlus è una libreria .NET che permette di associare popup informativi ai controlli di un form Windows Forms.

Aggiunto opzione colora Sfondo e Testo con versione 1.0.8

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
			
			' Esempio colora Sfondo e Testo con Cersione 1.0.8
			 Dim imgEsci As Image = My.Resources.exit_100
			 PopupHelper.AttachPopup(EsciPicture, "aiuto" & vbCrLf & "Esci dal programma", imgEsci, Color.GreenYellow, Color.Blue)
      
        Catch ex As Exception
            MessageBox.Show("Errore nel caricamento delle immagini: " & ex.Message)
        End Try
    End Sub
End Class
