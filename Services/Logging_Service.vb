Imports System.IO

Public Class Logging_Service
#Region "LoadLogFile"
    Public Shared Sub LoadLogFile()
ReloadFile:
        Dim dlg As New Microsoft.Win32.OpenFileDialog()

        dlg.DefaultExt = ".txt"
        dlg.Filter = "Text documents (.txt)|*.txt"

        Dim result As Nullable(Of Boolean) = dlg.ShowDialog()

        If result = True Then
            Dim filename As String = dlg.FileName
            LogFilePath = filename
        End If

        If Validate_LogFilePath() = False Then
            GoTo ReloadFile
        End If
    End Sub

    Public Shared Property LogFilePath As String
    Public Shared Function Validate_LogFilePath() As Boolean
        If LogFilePath Is Nothing Then Return False

        If File.Exists(LogFilePath) = True Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Translation"
    Public Shared Function TranslateLog() As List(Of LogItem)
        Dim l As New List(Of LogItem)

        Dim lines = System.IO.File.ReadAllLines(LogFilePath)
        For each line In lines
            Dim s = line.Split("|")

            Dim li As New LogItem
            li.Time = s(0)
            li.Type = s(1)
            li.Msg = s(2)

            l.Add(li)
        Next

        Return l
    End Function
#End Region
End Class
