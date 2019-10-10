Option Explicit On
Option Strict On
Option Infer Off


Public Class Form1

    Dim totalCostDay As Double = 0

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        ' Define variables and constants

        ' Arabic appetizers and drinks
        Const hummesCost As Double = 2.5
        Const grapeLeavesCost As Double = 4.5
        Const samposaCost As Double = 2.5
        Const flafelCost As Double = 3.5
        Const qamarAdenCost As Double = 1.5
        Const tamrHindiCost As Double = 2.5
        Const vimtoCost As Double = 1.99
        Const turkishCoffeeCost As Double = 2.99

        ' American appetizers and drinks
        Const onionRingsCost As Double = 9.0
        Const potatoSkinsCost As Double = 9.0
        Const mozzSticksCost As Double = 9.0
        Const macCheeseCost As Double = 5.0
        Const hotChocolateCost As Double = 2.99
        Const wineCost As Double = 10.0
        Const sweetTeaCost As Double = 2.99
        Const shirleyTempleCost As Double = 7.0

        ' Arabic desserts
        Const konafaCost As Double = 4.5
        Const baklavaCost As Double = 3.5
        Const maamoulCookiesCost As Double = 3.5

        ' American desserts
        Const chocolateCakeCost As Double = 2.5
        Const bananaSplitsCost As Double = 2.5
        Const sundaeCost As Double = 5.0
        Const applePieCost As Double = 2.5

        ' tip and tax
        Const taxRate As Double = 0.08       ' 8    percent
        Const tipRate As Double = 0.15       ' 15   percent

        ' textBox variables (Qty = Quantity)
        Dim hummesQty As Double
        Dim grapeLeavesQty As Double
        Dim samposaQty As Double
        Dim flafelQty As Double
        Dim qamarAdenQty As Double
        Dim tamrHindiQty As Double
        Dim vimtoQty As Double
        Dim turkishCoffeeQty As Double
        Dim onionRingsQty As Double
        Dim potatoSkinsQty As Double
        Dim mozzSticksQty As Double
        Dim macCheeseQty As Double
        Dim hotChocolateQty As Double
        Dim wineQty As Double
        Dim sweetTeaQty As Double
        Dim shirleyTempleQty As Double
        Dim konafaQty As Double
        Dim baklavaQty As Double
        Dim maamoulCookiesQty As Double
        Dim chocolateCakeQty As Double
        Dim bananaSplitsQty As Double
        Dim sundaeQty As Double
        Dim applePieQty As Double

        Dim ARAADCost As Double              ' Arabic Appetizers and Drinks
        Dim AMAADCost As Double              ' American Appetizers and Drinks
        Dim ARDCost As Double                ' Arabic Desserts
        Dim AMDCost As Double                ' American Desserts

        Dim tip As Double
        Dim tax As Double
        Dim totalInterim As Double
        Dim totalCost As Double


        ' Get inputs from textboxes
        Double.TryParse(txtHummus.Text, hummesQty)
        Double.TryParse(txtGrapeLeaves.Text, grapeLeavesQty)
        Double.TryParse(txtSamposa.Text, samposaQty)
        Double.TryParse(txtFlafel.Text, flafelQty)
        Double.TryParse(txtQamarAden.Text, qamarAdenQty)
        Double.TryParse(txtTamrHindi.Text, tamrHindiQty)
        Double.TryParse(txtVimto.Text, vimtoQty)
        Double.TryParse(txtTurkishCoffee.Text, turkishCoffeeQty)
        Double.TryParse(txtOnionRings.Text, onionRingsQty)
        Double.TryParse(txtPotatoSkins.Text, potatoSkinsQty)
        Double.TryParse(txtMozzSticks.Text, mozzSticksQty)
        Double.TryParse(txtMacCheese.Text, macCheeseQty)
        Double.TryParse(txtHotChocolate.Text, hotChocolateQty)
        Double.TryParse(txtWine.Text, wineQty)
        Double.TryParse(txtSweetTea.Text, sweetTeaQty)
        Double.TryParse(txtShirleyTemple.Text, shirleyTempleQty)
        Double.TryParse(txtKonafa.Text, konafaQty)
        Double.TryParse(txtBaklava.Text, baklavaQty)
        Double.TryParse(txtMaamoulCookies.Text, maamoulCookiesQty)
        Double.TryParse(txtChocolateCake.Text, chocolateCakeQty)
        Double.TryParse(txtBananaSplits.Text, bananaSplitsQty)
        Double.TryParse(txtSundae.Text, sundaeQty)
        Double.TryParse(txtApplePie.Text, applePieQty)

        ' Calculations
        ARAADCost = hummesCost * hummesQty + grapeLeavesCost * grapeLeavesQty _
                    + samposaCost * samposaQty + flafelCost * flafelQty _
                    + qamarAdenCost * qamarAdenQty + tamrHindiCost * tamrHindiQty _
                    + vimtoCost * vimtoQty + turkishCoffeeCost * turkishCoffeeQty

        AMAADCost = onionRingsCost * onionRingsQty + mozzSticksCost * mozzSticksQty _
                    + potatoSkinsCost * potatoSkinsQty + macCheeseCost * macCheeseQty _
                    + hotChocolateCost * hotChocolateQty + wineCost * wineQty _
                    + sweetTeaCost * sweetTeaQty + shirleyTempleCost * shirleyTempleQty

        ARDCost = konafaCost * konafaQty + baklavaCost * baklavaQty _
                    + maamoulCookiesCost * maamoulCookiesQty

        AMDCost = chocolateCakeCost * chocolateCakeQty + bananaSplitsCost * bananaSplitsQty _
                    + sundaeCost * sundaeQty + applePieCost * applePieQty


        totalInterim = ARAADCost + AMAADCost + ARDCost + AMDCost

        tip = tipRate * totalInterim

        tax = taxRate * totalInterim

        totalCost = totalInterim + tip + tax

        totalCostDay = totalCostDay + totalCost

        ' Set output values
        txtTip.Text = tip.ToString("C2")

        txtTax.Text = tax.ToString("C2")

        txtTotalCost.Text = totalCost.ToString("C2")

        txtTotalCostDay.Text = totalCostDay.ToString("C2")

    End Sub

    Private Sub btnPrintReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintReceipt.Click

        ' hide cost for the day
        txtTotalCostDay.Hide()
        lblTotalCostDay.Hide()

        ' print the receipt
        PrintForm1.Print()

        ' unhide cost for the day
        txtTotalCostDay.Visible = True
        lblTotalCostDay.Visible = True

    End Sub
End Class
