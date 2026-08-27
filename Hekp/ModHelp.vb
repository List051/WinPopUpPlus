
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

'Public Module ModHelp

'    ' Cartella Help
'    Private ReadOnly CartellaHelp As String =
'        Path.Combine(Application.StartupPath, "Help")


'    '==========================
'    ' Restituisce percorso cartella Help
'    '==========================
'    Public Function PercorsoHelp() As String

'        Return CartellaHelp

'    End Function


''==========================
'' Apre la cartella Help
''==========================
'Public Sub ApriCartella()

'    If Directory.Exists(CartellaHelp) Then

'        Process.Start(New ProcessStartInfo(CartellaHelp) With {
'            .UseShellExecute = True
'        })

'    Else

'        MessageBox.Show(
'            "La cartella Help non esiste." &
'            vbCrLf &
'            CartellaHelp,
'            "Help",
'            MessageBoxButtons.OK,
'            MessageBoxIcon.Information)

'    End If

'End Sub


''==========================
'' Restituisce Index.html
''==========================
'Public Function PercorsoIndice() As String

'    Return Path.Combine(CartellaHelp, "Index.html")

'End Function


''==========================
'' Apre Index.html nel browser
''==========================
'Public Sub ApriIndice()

'    Dim fileHtml As String = PercorsoIndice()

'    If File.Exists(fileHtml) Then

'        Process.Start(New ProcessStartInfo(fileHtml) With {
'            .UseShellExecute = True
'        })

'    Else

'        MessageBox.Show(
'            "File Index.html non trovato." &
'            vbCrLf &
'            fileHtml,
'            "Help",
'            MessageBoxButtons.OK,
'            MessageBoxIcon.Information)

'    End If

'End Sub

' End Module

'   Private Sub RjCircHelp_Click(sender As Object, e As EventArgs) Handles RjCircHelp.Click
' Visto che ho diversi file pdf per le funzioni della Libreria
' posso fare in modo di vedere una cartella predefinita \Help 
' creo cartella in Bin\Debug o in \Document\Help, inserisco i file pdf,
' aprire il file pdf direttamente Index.html
' ***************
' esempio di utilizzo

'   ModHelp.ApriIndice()

' *************
' in questo caso il FrmDocumentazione.Show() NON lo apro con il RjCircApriInde

'  End Sub

Public Module ModHelp

    Private ReadOnly CartellaHelp As String =
        Path.Combine(Application.StartupPath, "Help")


    Public Function PercorsoIndice() As String

        Return Path.Combine(CartellaHelp, "Index.html")

    End Function


    Public Sub ApriCartella()

        If Directory.Exists(CartellaHelp) Then

            Process.Start(New ProcessStartInfo(CartellaHelp) With {
                .UseShellExecute = True
            })

        End If

    End Sub

End Module