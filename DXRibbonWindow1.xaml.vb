Public Class DXRibbonWindow1
    Private Sub BarButtonItem_ItemClick(sender As Object, e As DevExpress.Xpf.Bars.ItemClickEventArgs)
        My.Computer.FileSystem.WriteAllText("D:\New folder (2)\SAMPLES\Logger.txt", "[" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "]." + "[Log Info Test]" + Environment.NewLine, True)
    End Sub
    Private Sub BarButtonItem_ItemClick_3(sender As Object, e As DevExpress.Xpf.Bars.ItemClickEventArgs)
        My.Computer.FileSystem.WriteAllText("D:\New folder (2)\SAMPLES\Logger.txt", "[" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "]." + "[Log Warning Test]" + Environment.NewLine, True)
    End Sub

    Private Sub BarButtonItem_ItemClick_1(sender As Object, e As DevExpress.Xpf.Bars.ItemClickEventArgs)
        My.Computer.FileSystem.WriteAllText("D:\New folder (2)\SAMPLES\Logger.txt", "[" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "]." + "[Log Error Test]" + Environment.NewLine, True)
    End Sub

    Private Sub BarButtonItem_ItemClick_2(sender As Object, e As DevExpress.Xpf.Bars.ItemClickEventArgs)
        Process.Start("D:\New folder (2)\SAMPLES\Logger.txt")
    End Sub
End Class
