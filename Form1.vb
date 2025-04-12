

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Carica immagini
            Dim imgInfo As Image = My.Resources.aiuto_50
            Dim imgWarning As Image = My.Resources.conf_tel
            Dim imgLapTop As Image = My.Resources.laptop
            ' Associa i popup ai pulsanti

            PopupHelper.AttachPopup(Button2, "Attenzione!" & vbCrLf & vbCrLf & "Questa è di default," & vbCrLf &
                    "senza passare i parametri di sfondo e testo", imgWarning)

            ' Funziona su qualsiasi controllo
            PopupHelper.AttachPopup(PictureBox, "Questo è una PictureBox", imgLapTop)

            ' Associa un popup a un pulsante con colori personalizzati
            PopupHelper.AttachPopup(Button1, "Informazioni utili", imgInfo, Color.Blue, Color.White)

        Catch ex As Exception
            MessageBox.Show("Errore nel caricamento delle immagini: " & ex.Message)
        End Try
    End Sub

End Class