Public Class frmMain
    Private ReadOnly txtmuffins As Object

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ' Prepare the screen for the next sale input
        txtDonuts.Text = String.Empty
        txtMuff.Text = String.Empty
        Ibltotalltems.Text = String.Empty
        lblTotalSales.Text = String.Empty

        ' Restore the focus to the Doughnuts box
        txtDonuts.Focus()


    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        ' Toggle buttons visibilities
        btnCalc.Visible = False
        btnClear.Visible = False
        btnExit.Visible = False
        btnPrint.Visible = False

        ' print the sales receipt
        PrintForm1.Print()

        ' Toggle button visibilities
        btnCalc.Visible = True
        btnClear.Visible = True
        btnExit.Visible = True
        btnPrint.Visible = True

    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click

        ' Calculate Number of items sold And total sales
        lblTotalItems.Text = Val(txtDonuts.Text) + Val(txtMuff.Text)
        lblTotalSales.Text = Val(lblTotalItems.Text) * 0.5

        ' Format the total sales with the currency style
        lblTotalSales.Text = Format(lblTotalSales.Text, "currency")

    End Sub

    Private Sub lblTotalSales_Click(sender As Object, e As EventArgs) Handles lblTotalSales.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class
