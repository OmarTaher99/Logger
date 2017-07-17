Imports Prism.Commands
Imports Prism.Mvvm

Public Class LoggerTest_ViewModel
    Inherits BindableBase

#Region "Msg"
    Private _Msg As String = "Default Value"
    Public Property Msg As String
        Get
            Return _Msg
        End Get
        Set(value As String)
            _Msg = value
            RaisePropertyChanged("Msg")
        End Set
    End Property
#End Region
#Region "LogFile_Path"
    Private _LogFile_Path As String
    Public Property LogFile_Path As String
        Get
            Return _LogFile_Path
        End Get
        Set(value As String)
            _LogFile_Path = value
            RaisePropertyChanged("LogFile_Path")
        End Set
    End Property
#End Region


#Region "LogInfo_CMD"
    Public Property LogInfo_CMD As DelegateCommand = New DelegateCommand(AddressOf LogInfo)
    Private Sub LogInfo()
        If Msg = "" Or LogFile_Path = "" Then
            MsgBox("Enter All Values.")
        Else
            My.Computer.FileSystem.WriteAllText(LogFile_Path, "[" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "]." + "[Info]:" + Msg + Environment.NewLine, True)
        End If
    End Sub
#End Region
#Region "LoadLogFile_CMD"
    Public Property LoadLogFile_CMD As DelegateCommand = New DelegateCommand(AddressOf LoadLogFile)
    Private Sub LoadLogFile()
        Dim dlg As New Microsoft.Win32.OpenFileDialog()

        dlg.DefaultExt = ".txt"
        dlg.Filter = "Text documents (.txt)|*.txt"

        Dim result As Nullable(Of Boolean) = dlg.ShowDialog()

        If result = True Then
            Dim filename As String = dlg.FileName
            LogFile_Path = filename
        End If
    End Sub
#End Region
End Class
