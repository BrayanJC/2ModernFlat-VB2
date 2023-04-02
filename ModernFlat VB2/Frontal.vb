Imports System.Runtime.InteropServices

Public Class Frontal
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("¿Está seguro de cerrar sesión?", "Mensaje",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close() 'Cierra el formulario
        End If
    End Sub
    Dim lx, ly As Integer
    Dim sw, sh As Integer

    Private Sub btnSideMenu_Click(sender As Object, e As EventArgs) Handles btnSideMenu.Click
        If panelSideMenu.Width > 100 Then
            panelSideMenu.Width = 52

            For Each control As Control In panelMenuHeader.Controls
                If control IsNot btnSideMenu Then control.Visible = False
            Next
        Else
            panelSideMenu.Width = 230

            For Each control As Control In panelMenuHeader.Controls
                control.Visible = True
            Next
        End If
    End Sub

    Private Sub MENUPU_Click(sender As Object, e As EventArgs) Handles MENUPU.Click
        ContextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y)
    End Sub

    Private Sub PictureBox4_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox4.MouseMove

        MENUPU.Visible = True
        PictureBox4.Visible = False
    End Sub
    Private Sub panelTitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles panelTitleBar.MouseMove
        MENUPU.Visible = False
        PictureBox4.Visible = True
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        lx = Me.Location.X
        ly = Me.Location.Y
        sw = Me.Size.Width
        sh = Me.Size.Height
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        MINI.Visible = True
        btnMaximize.Visible = False
    End Sub

    Private Sub MINI_Click(sender As Object, e As EventArgs) Handles MINI.Click
        Me.Size = New Size(sw, sh)
        Me.Location = New Point(lx, ly)
        Me.WindowState = FormWindowState.Normal
        MINI.Visible = False
        btnMaximize.Visible = True
    End Sub
End Class