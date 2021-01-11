Public Class Form1
    Private Sub UpdateProcessList()
        ListBox1.Items.Clear()
        Dim p As Process
        For Each p In Process.GetProcesses()
            ListBox1.Items.Add(p.ProcessName & " - " & p.Id.ToString())
        Next
        ListBox1.Sorted = True
        ListBox1.Text = "Processes running: " & ListBox1.Items.Count.ToString()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.LightGray
        Button1.ForeColor = Color.Black
        Button2.BackColor = Color.DimGray
        Button2.ForeColor = Color.White
        Button3.BackColor = Color.DimGray
        Button3.ForeColor = Color.White
        Button4.BackColor = Color.DimGray
        Button4.ForeColor = Color.White
        ListBox1.Visible = True
        Button5.Visible = True
        Button6.Visible = True
        UpdateProcessList()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.BackColor = Color.DimGray
        Button1.ForeColor = Color.White
        Button2.BackColor = Color.LightGray
        Button2.ForeColor = Color.Black
        Button3.BackColor = Color.DimGray
        Button3.ForeColor = Color.White
        Button4.BackColor = Color.DimGray
        Button4.ForeColor = Color.White
        ListBox1.Visible = False
        Button5.Visible = False
        Button6.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button1.BackColor = Color.DimGray
        Button1.ForeColor = Color.White
        Button2.BackColor = Color.DimGray
        Button2.ForeColor = Color.White
        Button3.BackColor = Color.LightGray
        Button3.ForeColor = Color.Black
        Button4.BackColor = Color.DimGray
        Button4.ForeColor = Color.White
        ListBox1.Visible = False
        Button5.Visible = False
        Button6.Visible = False
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1.BackColor = Color.DimGray
        Button1.ForeColor = Color.White
        Button2.BackColor = Color.DimGray
        Button2.ForeColor = Color.White
        Button3.BackColor = Color.DimGray
        Button3.ForeColor = Color.White
        Button4.BackColor = Color.LightGray
        Button4.ForeColor = Color.Black
        ListBox1.Visible = False
        Button5.Visible = False
        Button6.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        UpdateProcessList()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If ListBox1.SelectedItems.Count < 1 Then
            MessageBox.Show("Click on a process name to select it.", "No Process Selected")
            Return
        End If
        Dim p As Process
        For Each p In Process.GetProcesses()
            Dim arr() As String = ListBox1.SelectedItem.ToString().Split("-")
            Dim stringProcess As String = arr(0).Trim()
            Dim itemId As Integer = Convert.ToInt32(arr(1).Trim())
            If p.ProcessName = stringProcess And p.Id = itemId Then
                p.Kill()
            End If
        Next
        UpdateProcessList()
    End Sub
End Class
