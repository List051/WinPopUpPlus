

Public Class PopupHelper
    Private Shared popup As PopUpForm

    ''' <summary>
    ''' Associa un popup con testo e immagine a un controllo.
    ''' <param name="ctrl">Controllo su cui mostrare il popup (può essere un Button, PictureBox, ecc.)</param>
    ''' <param name="message">Testo del popup</param>
    ''' <param name="img">Immagine opzionale</param>
    ''' <param name="backgroundColor">Colore di sfondo del popup (opzionale, predefinito: LightYellow)</param>
    ''' <param name="textColor">Colore del testo del popup (opzionale, predefinito: Black)</param>
    ''' </summary>
    Public Shared Sub AttachPopup(ctrl As Control, message As String, Optional img As Image = Nothing, Optional backgroundColor As Color = Nothing, Optional textColor As Color = Nothing)
        ' Imposta i colori predefiniti se non forniti
        If backgroundColor = Nothing Then backgroundColor = Color.LightYellow
        If textColor = Nothing Then textColor = Color.Black

        ' Eventi per mouse enter/leave
        AddHandler ctrl.MouseEnter, Sub(sender, e)
                                        popup = New PopUpForm(message, img, backgroundColor, textColor)
                                        popup.ShowNearControl(ctrl)
                                    End Sub

        AddHandler ctrl.MouseLeave, Sub(sender, e)
                                        If popup IsNot Nothing Then
                                            popup.ClosePopup()
                                            popup = Nothing
                                        End If
                                    End Sub
    End Sub

    ''' <summary>
    ''' Mostra il popup accanto al controllo specificato.
    ''' </summary>
    ''' <param name="ctrl">Controllo associato (può essere un Button, PictureBox, ecc.)</param>
    ''' <param name="message">Testo del popup</param>
    ''' <param name="img">Immagine opzionale</param>
    ''' <param name="backgroundColor">Colore di sfondo del popup</param>
    ''' <param name="textColor">Colore del testo del popup</param>
    Private Shared Sub ShowPopup(ctrl As Control, message As String, img As Image, backgroundColor As Color, textColor As Color)
        HidePopup() ' Chiude eventuali popup esistenti

        ' Crea il nuovo popup
        popup = New PopUpForm(message, img, backgroundColor, textColor)

        ' Posiziona accanto al controllo
        Dim ctrlPosition As Point = ctrl.PointToScreen(Point.Empty)
        popup.Location = New Point(ctrlPosition.X + ctrl.Width + 5, ctrlPosition.Y)

        ' Mostra con animazione
        popup.ShowPopup()
    End Sub

    ''' <summary>
    ''' Nasconde il popup esistente in sicurezza.
    ''' </summary>
    Private Shared Sub HidePopup()
        If popup IsNot Nothing Then
            popup.ClosePopup()
            popup = Nothing
        End If
    End Sub
End Class

