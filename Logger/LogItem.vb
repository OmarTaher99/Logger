Imports Prism.Mvvm

Public Class LogItem
    Inherits BindableBase
#Region "Msg"
    Private _Msg As String = "Default Value"
    Public Property Msg As String
        Get
            Dim FileReader As String
            FileReader = My.Computer.FileSystem.ReadAllText("D:\New folder (2)\SAMPLES\Logger.txt")
            Return FileReader
        End Get
        Set(value As String)
            _Msg = value
            RaisePropertyChanged("Msg")
        End Set
    End Property
#End Region
#Region "Type"
    Private _Type As String = "Error"
    Public Property Type As String
        Get
            Return _Type
        End Get
        Set(value As String)
            _Type = value
            RaisePropertyChanged("Type")
        End Set
    End Property
#End Region
#Region "Time"
    Private _Time As String = Now
    Public Property Time As String
        Get
            Return _Time
        End Get
        Set(value As String)
            _Time = value
            RaisePropertyChanged("Time")
        End Set
    End Property
#End Region
End Class
