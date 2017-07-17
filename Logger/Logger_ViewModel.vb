Imports Prism.Commands
Imports Prism.Mvvm

Public Class Logger_ViewModel
    Inherits BindableBase

#Region "Msg"
    Private _Msg As String
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



#Region "LogRefresh_CMD"
    Public Property LogRefresh_CMD As DelegateCommand = New DelegateCommand(AddressOf LogRefresh)
    Private Sub LogRefresh()

        Dim FileReader As String
        FileReader = My.Computer.FileSystem.ReadAllText("D:\New folder (2)\SAMPLES\Logger.txt")
        MsgBox(FileReader)

        'For Each line As String In System.IO.File.ReadAllLines("d:\temp\testdata.txt")
        '    DataGridView1.Rows.Add(line.Split(","))
        'Next
    End Sub
#End Region
#Region "LogInfo_CMD"
    Public Property LogInfo_CMD As DelegateCommand = New DelegateCommand(AddressOf LogInfo)
    Private Sub LogInfo()
        Log("Log Info Text")
    End Sub
#End Region
#Region "LogWarning_CMD"
    Public Property LogWarning_CMD As DelegateCommand = New DelegateCommand(AddressOf LogWarning)
    Private Sub LogWarning()
        Log("Log Warning Text")
    End Sub
#End Region
#Region "LogError_CMD"
    Public Property LogError_CMD As DelegateCommand = New DelegateCommand(AddressOf LogError)
    Private Sub LogError()
        Log("Log Error Text")
    End Sub
#End Region
#Region "OpenLogFile_CMD"
    Public Property OpenLogFile_CMD As DelegateCommand = New DelegateCommand(AddressOf OpenLogFile)
    Private Sub OpenLogFile()
        Process.Start("D:\New folder (2)\SAMPLES\Logger.txt")
    End Sub
#End Region

#Region "Log_Method"
    Private Sub Log(LogType As String)
        Dim LogMsg As String = String.Concat("[", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "].", "[" + LogType + "]", Environment.NewLine)
        My.Computer.FileSystem.WriteAllText("D:\New folder (2)\SAMPLES\Logger.txt", LogMsg, True)
    End Sub
#End Region

End Class
