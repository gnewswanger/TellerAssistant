Imports System.Globalization

Public Class CalculatorClass

    Public Delegate Sub RegisterChangeHandler(ByVal sender As Object, ByVal e As RegisterEventArgs)
    Public Event RegisterChanged As RegisterChangeHandler

    Private fRegister1 As Single
    Private fMemRegister1 As Single
    Private fEntry As Single
    Private initval As Single
    Private displayText As String
    Public cMode As CalculatorMode
    Private fIsEntryCleared As Boolean
    Public nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat

    Public Property Register1() As Single
        Get
            Return fRegister1
        End Get
        Set(ByVal Value As Single)
            ResetRegister(Value)
        End Set
    End Property

    Public Sub New()
        ResetRegister(0)
        cMode = CalculatorMode.cmAdd
    End Sub

    Private Sub ResetEntry()
        fEntry = 0
        fIsEntryCleared = True
        displayText = fRegister1.ToString("N", nfi)
    End Sub

    Private Sub ResetRegister(ByVal num As Single)
        fRegister1 = num
        initVal = num
        ResetEntry()
        cMode = CalculatorMode.cmAdd
        OnRegisterChanged()
    End Sub

    Private Sub UpdateRegister(ByVal num As Single)
        Select Case cMode
            Case CalculatorMode.cmAdd
                fRegister1 += num
            Case CalculatorMode.cmSubtract
                fRegister1 -= num
            Case CalculatorMode.cmMultiply
                If num <> 0 Then
                    fRegister1 = fRegister1 * num
                End If
            Case CalculatorMode.cmDivide
                If num <> 0 Then
                    fRegister1 = fRegister1 / num
                End If
        End Select
        ResetEntry()
    End Sub

    Public Sub OnRegisterChanged()
        Dim e As New RegisterEventArgs
        e.Value = fRegister1
        e.Text = displayText
        RaiseEvent RegisterChanged(Me, e)
    End Sub

    Public Function ProcessKeypress(ByVal key As PadKey) As Single
        Select Case key
            Case PadKey.pkey0, PadKey.npkey0
                If fIsEntryCleared = True Then
                    displayText = "0"
                    fIsEntryCleared = False
                Else
                    displayText += "0"
                End If
            Case PadKey.pkey1, PadKey.npkey1
                If fIsEntryCleared = True Then
                    displayText = "1"
                    fIsEntryCleared = False
                Else
                    displayText += "1"
                End If
            Case PadKey.pkey2, PadKey.npkey2
                If fIsEntryCleared = True Then
                    displayText = "2"
                    fIsEntryCleared = False
                Else
                    displayText += "2"
                End If
            Case PadKey.pkey3, PadKey.npkey3
                If fIsEntryCleared = True Then
                    displayText = "3"
                    fIsEntryCleared = False
                Else
                    displayText += "3"
                End If
            Case PadKey.pkey4, PadKey.npkey4
                If fIsEntryCleared = True Then
                    displayText = "4"
                    fIsEntryCleared = False
                Else
                    displayText += "4"
                End If
            Case PadKey.pkey5, PadKey.npkey5
                If fIsEntryCleared = True Then
                    displayText = "5"
                    fIsEntryCleared = False
                Else
                    displayText += "5"
                End If
            Case PadKey.pkey6, PadKey.npkey6
                If fIsEntryCleared = True Then
                    displayText = "6"
                    fIsEntryCleared = False
                Else
                    displayText += "6"
                End If
            Case PadKey.pkey7, PadKey.npkey7
                If fIsEntryCleared = True Then
                    displayText = "7"
                    fIsEntryCleared = False
                Else
                    displayText += "7"
                End If
            Case PadKey.pkey8, PadKey.npkey8
                If fIsEntryCleared = True Then
                    displayText = "8"
                    fIsEntryCleared = False
                Else
                    displayText += "8"
                End If
            Case PadKey.pkey9, PadKey.npkey9
                If fIsEntryCleared = True Then
                    displayText = "9"
                    fIsEntryCleared = False
                Else
                    displayText += "9"
                End If
            Case PadKey.pkeyBackspace
                If displayText.Length > 0 Then
                    displayText = displayText.Remove(displayText.Length - 1, 1)
                End If
            Case PadKey.pkeyClear
                ResetRegister(initval)
            Case PadKey.pkeyClearEntry
                ResetEntry()
            Case PadKey.pkeyDot
                If displayText.LastIndexOf(".") = -1 Then
                    If fIsEntryCleared = True Then
                        displayText = "0."
                        fIsEntryCleared = False
                    Else
                        displayText += "."
                    End If
                End If
            Case PadKey.pkeyEquals
                If fIsEntryCleared = False Then
                    fEntry = CSng(displayText)
                End If
                UpdateRegister(fEntry)

            Case PadKey.pkeyMinus
                If fIsEntryCleared = False Then
                    fEntry = CSng(displayText)
                    UpdateRegister(fEntry)
                End If
                cMode = CalculatorMode.cmSubtract

            Case PadKey.pkeyPercent
                If fIsEntryCleared = False Then
                    fEntry = CSng(displayText)
                    If fEntry <> 0 Then
                        If cMode = CalculatorMode.cmMultiply Or cMode = CalculatorMode.cmDivide Then
                            UpdateRegister(fEntry / 100)
                        Else
                            UpdateRegister(fRegister1 * (fEntry / 100))
                        End If
                    End If
                End If

            Case PadKey.pkeyPlus
                If fIsEntryCleared = False Then
                    fEntry = CSng(displayText)
                End If
                UpdateRegister(fEntry)
                cMode = CalculatorMode.cmAdd
            Case PadKey.pkeyDivide
                If fIsEntryCleared = False Then
                    fEntry = CSng(displayText)
                    UpdateRegister(fEntry)
                End If
                cMode = CalculatorMode.cmDivide
            Case PadKey.pkeyTimes
                If fIsEntryCleared = False Then
                    fEntry = CSng(displayText)
                    UpdateRegister(fEntry)
                End If
                cMode = CalculatorMode.cmMultiply
        End Select
        OnRegisterChanged()
    End Function


End Class
