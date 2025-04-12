''Imports System.Drawing
''Imports System.Windows.Forms

Public Class PopUpForm
    Private fadeTimer As Timer

    Public Sub New(message As String, Optional img As Image = Nothing, Optional backgroundColor As Color = Nothing, Optional textColor As Color = Nothing)
        InitializeComponent()

        ' Configura il form
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.Black
        Me.Opacity = 0  ' Inizia invisibile per il fade-in
        Me.StartPosition = FormStartPosition.Manual
        Me.Padding = New Padding(10)

        ' Imposta i colori di sfondo e del testo
        If backgroundColor = Nothing Then backgroundColor = Color.LightYellow ' Colore di sfondo predefinito
        If textColor = Nothing Then textColor = Color.Black ' Colore del testo predefinito

        ' Crea un pannello per il contenuto
        Dim panel As New Panel With {
            .BackColor = backgroundColor, ' Usa il colore di sfondo passato,
            .Padding = New Padding(10),
            .AutoSize = True
        }

        ' Crea la Label per il testo
        Dim lbl As New Label With {
            .Text = message,
            .AutoSize = True,
            .Font = New Font("Arial", 10, FontStyle.Bold),
            .ForeColor = textColor ' Usa il colore del testo passato
        }

        ' Se c'è un'immagine, aggiungiamola
        If img IsNot Nothing Then
            Dim pic As New PictureBox With {
                .Image = img,
                .SizeMode = PictureBoxSizeMode.StretchImage,
                .Size = New Size(50, 50),
                .Margin = New Padding(0, 0, 10, 0)
            }

            ' Creiamo un layout per gestire immagine + testo
            Dim layout As New FlowLayoutPanel With {
                .AutoSize = True,
                .FlowDirection = FlowDirection.LeftToRight
            }

            layout.Controls.Add(pic)
            layout.Controls.Add(lbl)
            panel.Controls.Add(layout)
        Else
            panel.Controls.Add(lbl)
        End If

        ' Aggiungi il pannello al form
        Me.Controls.Add(panel)
        Me.Size = panel.Size

        ' Configura il timer per il fade-in
        fadeTimer = New Timer With {.Interval = 30}
        AddHandler fadeTimer.Tick, AddressOf FadeIn
    End Sub

    ' Mostra il popup con animazione
    Public Sub ShowPopup()
        Me.Opacity = 0
        Me.Show()
        fadeTimer.Start()
    End Sub

    ' Effetto fade-in con controllo sulla chiusura del form
    Private Sub FadeIn(sender As Object, e As EventArgs)
        If Me.IsDisposed OrElse Not Me.Visible Then
            fadeTimer.Stop()
            fadeTimer.Dispose()
            Exit Sub
        End If

        If Me.Opacity < 1 Then
            Me.Opacity += 0.1
        Else
            fadeTimer.Stop()
        End If
    End Sub

    ' Metodo per chiudere il popup in sicurezza
    Public Sub ClosePopup()
        If fadeTimer IsNot Nothing Then
            fadeTimer.Stop()
            fadeTimer.Dispose()
        End If
        Me.Close()
    End Sub

    Public Sub ShowNearControl(ctrl As Control)
        ' Ottieni il form che contiene il controllo
        Dim parentForm As Form = ctrl.FindForm()
        If parentForm Is Nothing Then Exit Sub

        ' Calcola la posizione del controllo nel form
        Dim ctrlLocation As Point = ctrl.PointToScreen(Point.Empty)
        Dim formLocation As Point = parentForm.PointToScreen(Point.Empty)
        Dim relativeToForm As New Point(ctrlLocation.X - formLocation.X, ctrlLocation.Y - formLocation.Y)

        ' Prova a posizionare sotto il controllo
        Dim popupX As Integer = relativeToForm.X
        Dim popupY As Integer = relativeToForm.Y + ctrl.Height

        ' Se il popup uscirebbe in basso, mettilo sopra
        If popupY + Me.Height > parentForm.ClientSize.Height Then
            popupY = relativeToForm.Y - Me.Height
        End If

        ' Se uscirebbe a destra, spostalo a sinistra del controllo
        If popupX + Me.Width > parentForm.ClientSize.Width Then
            popupX = relativeToForm.X + ctrl.Width - Me.Width
        End If

        ' Non farlo uscire a sinistra
        If popupX < 0 Then popupX = 0

        ' Non farlo uscire sopra
        If popupY < 0 Then popupY = 0

        ' Imposta la posizione assoluta
        Me.Location = parentForm.PointToScreen(New Point(popupX, popupY))
        ShowPopup()
    End Sub

End Class
