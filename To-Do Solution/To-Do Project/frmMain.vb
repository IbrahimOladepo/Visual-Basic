' Name:         To-Do Project
' Purpose:      A To-Do List manager


Option Explicit On
Option Strict On
Option Infer Off


Public Class frmMain

    ' list components visibility array
    Dim intVisibleList() As Integer = {0, 0}


    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' toggle visibility of List Components
        txtItemA.Visible = False
        btnAddItemA.Visible = False
        btnRmvItemA.Visible = False
        chkListA.Visible = False
        chkDelListA.Visible = False

        txtItemB.Visible = False
        btnAddItemB.Visible = False
        btnRmvItemB.Visible = False
        chkListB.Visible = False
        chkDelListB.Visible = False

    End Sub


    Private Sub btnAddList_Click(sender As Object, e As EventArgs) Handles btnAddList.Click

        ' check for visible list
        If intVisibleList(0) = 0 Then
            ' no list components are visible yet
            ' make list 1 components visible
            txtItemA.Visible = True
            btnAddItemA.Visible = True
            btnRmvItemA.Visible = True
            chkListA.Visible = True

            ' update the visibility array
            intVisibleList(0) = 1

            ' update visibility of the delete list button
            chkDelListA.Visible = True
        ElseIf intVisibleList(1) = 0 Then
            ' list 1 components are visible already
            ' make list 2 compnents visible
            txtItemB.Visible = True
            btnAddItemB.Visible = True
            btnRmvItemB.Visible = True
            chkListB.Visible = True

            ' update the visibility array
            intVisibleList(1) = 1

            ' update visibility of the delete list button
            chkDelListB.Visible = True
        End If

    End Sub


    Private Sub btnRemoveList_Click(sender As Object, e As EventArgs) Handles btnRemoveList.Click

        ' check if list A is selected for deleting
        If chkDelListA.Checked Then
            txtItemA.Visible = False
            btnAddItemA.Visible = False
            btnRmvItemA.Visible = False
            chkListA.Visible = False

            ' reset list A
            chkListA.ResetText()

            ' set component visibility
            intVisibleList(0) = 0

            ' update visibility of the delete list button
            chkDelListA.Visible = False
            chkDelListA.Checked = False
        End If

        ' check if list B is selected for deleting
        If chkDelListB.Checked Then
            txtItemB.Visible = False
            btnAddItemB.Visible = False
            btnRmvItemB.Visible = False
            chkListB.Visible = False

            ' reset list B
            chkListB.ResetText()

            ' set component visibility
            intVisibleList(1) = 0

            ' update visibility of the delete list button
            chkDelListB.Visible = False
            chkDelListB.Checked = False
        End If

    End Sub


    Private Sub btnAddItemA_Click(sender As Object, e As EventArgs) Handles btnAddItemA.Click

        ' add item to list
        If txtItemA.Text IsNot "" Then
            chkListA.Items.Add(txtItemA.Text)
            txtItemA.Select()
            txtItemA.Text = ""
        End If

    End Sub


    Private Sub btnRmvItemA_Click(sender As Object, e As EventArgs) Handles btnRmvItemA.Click

        ' remove selected item
        If chkListA.SelectedIndex >= 0 Then
            chkListA.Items.RemoveAt(chkListA.SelectedIndex)
        End If

    End Sub


    Private Sub btnAddItemB_Click(sender As Object, e As EventArgs) Handles btnAddItemB.Click

        ' add item to list
        If txtItemB.Text IsNot "" Then
            chkListB.Items.Add(txtItemB.Text)
            txtItemB.Select()
            txtItemB.Text = ""
        End If

    End Sub


    Private Sub btnRmvItemB_Click(sender As Object, e As EventArgs) Handles btnRmvItemB.Click

        ' remove selected item
        If chkListB.SelectedIndex >= 0 Then
            chkListB.Items.RemoveAt(chkListB.SelectedIndex)
        End If

    End Sub

    Private Sub btnAddToAll_Click(sender As Object, e As EventArgs) Handles btnAddToAll.Click

        ' add to all lists
        If intVisibleList(0) = 1 Then
            chkListA.Items.Add(txtItemAll.Text)
            txtItemAll.Select()
        End If

        If intVisibleList(1) = 1 Then
            chkListB.Items.Add(txtItemAll.Text)
            txtItemAll.Select()
        End If

        txtItemAll.Text = ""

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' close the application
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' clear all the active lists
        If intVisibleList(0) = 1 Then
            ' delete all its content
            chkListA.Items.Clear()
        End If

        If intVisibleList(1) = 1 Then
            ' delete all its content
            chkListB.Items.Clear()
        End If
    End Sub
End Class
