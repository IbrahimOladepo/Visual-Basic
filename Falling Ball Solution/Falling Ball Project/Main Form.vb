' Name:         Falling Ball
' Purpose:      The ball falls freely and you keep it from touching
'               neither the base nor the top of the screen

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain
    Private grphGame As Graphics = Me.CreateGraphics

    Private intScore As Integer = 0
    Private boolRunning As Boolean
    Private intBallX As Integer
    Private intBallY As Integer
    Private Const intBallRadius As Integer = 25

    Private Const intBarWidth As Integer = 200
    Private Const intBarHeight As Integer = 30

    Private colLeftBars As Collection = New Collection()
    Private colRightBars As Collection = New Collection()

    Private Const intMoveRate As Integer = 10
    Private Const intFallRate As Integer = 30
    Private Const intRollRate As Integer = 10

    Private intXLimit As Integer
    Private intYLimit As Integer

    Private Const intNBars As Integer = 3

    Private Sub tmrGameTimer_Tick(sender As Object, e As EventArgs) Handles tmrGameTimer.Tick
        UpdateUI()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' initialise game
        Me.Show()
        Me.Focus()

        System.Threading.Thread.Sleep(1000)

        ' grphGame = Me.CreateGraphics
        ' grphGame.Dispose()

        intBallX = (Me.Width \ 4) - intBallRadius
        intBallY = (Me.Height \ 2) - intBallRadius

        intXLimit = Me.Width - (5 * intBallRadius \ 2)
        intYLimit = Me.Height - (2 * intBallRadius)

        InitBars()

        boolRunning = True

        tmrGameTimer.Enabled = True
    End Sub

    Private Sub UpdateUI()
        ' update the game interface
        If Not boolRunning Then
            Exit Sub
        End If

        intScore = intScore + 50
        MoveBall()
        MoveBars()
        DrawGraphics()
        'Debug.Write("Running" & vbNewLine)

    End Sub

    Private Sub DrawGraphics()
        ' update graphics
        Dim intBallDiam As Integer = intBallRadius * 2
        Dim rectBall As Rectangle = New Rectangle(intBallX, intBallY, intBallDiam, intBallDiam)
        Dim rectBar As Rectangle = New Rectangle(0, 0, intBarWidth, intBarHeight)

        ' clear screen
        ' grphGame = Me.CreateGraphics
        ' grphGame = Me.CreateGraphics
        grphGame.Clear(Color.White)
        ' grphGame.Dispose()

        ' draw ball
        grphGame.FillEllipse(Brushes.Green, rectBall)

        ' draw bars
        For intNum As Integer = 1 To intNBars
            ' left
            rectBar.Location = CType(colLeftBars(intNum), Point)
            grphGame.FillRectangle(Brushes.Aqua, rectBar)

            ' right
            rectBar.Location = CType(colRightBars(intNum), Point)
            grphGame.FillRectangle(Brushes.Aqua, rectBar)
        Next

        ' draw score
        lblScore.Text = intScore.ToString
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' manage key presses
        Select Case e.KeyCode
            Case Keys.Left
                intBallX = intBallX - intRollRate
                If intBallX <= 0 Then
                    intBallX = 0
                End If
            Case Keys.Right
                intBallX = intBallX + intRollRate
                If intBallX >= intXLimit Then
                    intBallX = intXLimit
                End If
        End Select
    End Sub

    Private Sub InitBars()
        ' add horizontal bars to the game
        Dim pntBar As Point

        ' left bars
        pntBar.X = (Me.Width \ 4) - (intBarWidth \ 2)

        pntBar.Y = (Me.Height \ 7)
        colLeftBars.Add(pntBar)

        pntBar.Y = (Me.Height \ 2) + intBallRadius
        colLeftBars.Add(pntBar)

        pntBar.Y = (Me.Height * 5 \ 7)
        colLeftBars.Add(pntBar)

        ' right bars
        pntBar.X = (Me.Width * 3 \ 4) - (intBarWidth \ 2)

        pntBar.Y = (Me.Height \ 15)
        colRightBars.Add(pntBar)

        pntBar.Y = (Me.Height * 9 \ 15)
        colRightBars.Add(pntBar)

        pntBar.Y = (Me.Height * 13 \ 15)
        colRightBars.Add(pntBar)
    End Sub

    Private Sub MoveBall()
        ' move the ball downwards or upwards taking contact into account

        Dim pntBarLoc As Point

        ' if touching screen top or bottom, Gameover
        If intBallY <= 0 Or intBallY >= intYLimit Then
            boolRunning = False
            MessageBox.Show("Gameover",
                            "Gameover", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Me.Close()
        End If

        ' if on bar, move up
        ' left
        For intNum As Integer = 1 To intNBars
            pntBarLoc = CType(colLeftBars(intNum), Point)
            If (intBallX >= pntBarLoc.X - intBallRadius And intBallX <= pntBarLoc.X + intBarWidth - intBallRadius) And (intBallY + 2 * intBallRadius >= pntBarLoc.Y And intBallY + 2 * intBallRadius <= pntBarLoc.Y + intBarHeight) Then
                intBallY = intBallY - intMoveRate
                Exit Sub
            End If
        Next

        ' right
        For intNum As Integer = 1 To intNBars
            pntBarLoc = CType(colRightBars(intNum), Point)
            If (intBallX >= pntBarLoc.X - intBallRadius And intBallX <= pntBarLoc.X + intBarWidth - intBallRadius) And (intBallY + 2 * intBallRadius >= pntBarLoc.Y And intBallY + 2 * intBallRadius <= pntBarLoc.Y + intBarHeight) Then
                intBallY = intBallY - intMoveRate
                Exit Sub
            End If
        Next

        ' otherwise move down
        intBallY = intBallY + intFallRate
    End Sub

    Private Sub MoveBars()
        Dim pntBarLoc As Point
        ' left bars
        For intNum As Integer = 1 To intNBars
            pntBarLoc = CType(colLeftBars(intNum), Point)
            pntBarLoc.Y = pntBarLoc.Y - intMoveRate
            colLeftBars.Add(pntBarLoc, After:=intNum)
            colLeftBars.Remove(intNum)
        Next

        ' right bars
        For intNum As Integer = 1 To intNBars
            pntBarLoc = CType(colRightBars(intNum), Point)
            pntBarLoc.Y = pntBarLoc.Y - intMoveRate
            colRightBars.Add(pntBarLoc, After:=intNum)
            colRightBars.Remove(intNum)
        Next

        ' remove top bar when it reaches the top and add another one at the bottom
        ' left
        pntBarLoc = CType(colLeftBars(1), Point)
        If pntBarLoc.Y <= 0 Then
            colLeftBars.Remove(1)
            pntBarLoc.Y = intYLimit
            colLeftBars.Add(pntBarLoc)
        End If

        ' right
        pntBarLoc = CType(colRightBars(1), Point)
        If pntBarLoc.Y <= 0 Then
            colRightBars.Remove(1)
            pntBarLoc.Y = intYLimit
            colRightBars.Add(pntBarLoc)
        End If
    End Sub
End Class
