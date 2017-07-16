Class MainWindow
    Private Sub btnOpenFile_Click(sender As Object, e As RoutedEventArgs)
        Dim dlg As New Microsoft.Win32.OpenFileDialog()

        dlg.DefaultExt = ".txt"
        dlg.Filter = "Text documents (.txt)|*.txt"

        Dim result As Nullable(Of Boolean) = dlg.ShowDialog()

        If result = True Then
            Dim filename As String = dlg.FileName
            tb_Path.Text = filename
        End If
    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles btn_Info.Click
        Log("Info")
    End Sub

    Private Sub btn_Error_Click(sender As Object, e As RoutedEventArgs) Handles btn_Error.Click
        Log("Error")
    End Sub

    Private Sub btn_Warning_Click(sender As Object, e As RoutedEventArgs) Handles btn_Warning.Click
        Log("Warning")
    End Sub


    Private Sub Log(LogType As String)
        If tb_MSG.Text = "" Or tb_Path.Text = "" Then
            MsgBox("Enter All Values.")
        Else
            Dim LogMsg As String = String.Concat("[" , DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") , "]." , "[" + LogType + "]:" , tb_MSG.Text , Environment.NewLine)
            My.Computer.FileSystem.WriteAllText(tb_Path.Text, LogMsg, True)
            MsgBox("Saved.")
        End If
    End Sub
End Class
