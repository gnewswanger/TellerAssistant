﻿''' <summary>
''' <file>CheckSearchPresenter.vb</file>
''' This class is the MVC controller (presenter) for the IViewFrmCheckSearch interface used in 
''' FormCheckSearch.vb
''' </summary>
''' <author>Galen Newswanger</author>
''' <remarks></remarks>
Public Class CheckSearchPresenter
    Inherits mvcLibrary.mvcAbstractPresenter

    Public ReadOnly Property ActiveDepositNo() As String
        Get
            If CType(Me.BaseModel, DepositManagerModel).IsDepositTicketOpen Then
                Return CType(Me.BaseModel, DepositManagerModel).GetCurrentTicket.DepositNumber
            Else
                Return String.Empty
            End If
        End Get
    End Property
    Public Sub New(ByVal aView As IViewFrmCheckSearch, ByRef aModel As DepositManagerModel)
        MyBase.New(aView, aModel)
        MyBase.BaseModel.AttachObserver(Me)
        If CType(Me.BaseModel, DepositManagerModel).IsDepositTicketOpen Then
            CType(Me.View, FormCheckSearch).ActiveDepNo = CType(Me.BaseModel, DepositManagerModel).GetCurrentTicket.DepositNumber
        End If
    End Sub

    Public Sub HandleSearchRequest(ByVal value As String)
        CType(View, IViewFrmCheckSearch).Checklist = (CType(Me.BaseModel, DepositManagerModel).HandleSearchRequest(value))
    End Sub

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)
        Select Case CType(NewEvent, AbstractEventArgs).Name
            Case EventName.evnmVwCheckInserted
                CType(Me.View, IViewFrmCheckSearch).CheckAdded = CType(NewEvent, CheckDataEventArgs).modCheck

            Case EventName.evnmVwCheckAmountChanged, EventName.evnmVwCheckUpdated
                CType(Me.View, IViewFrmCheckSearch).CheckChanged = CType(NewEvent, CheckDataEventArgs).modCheck

            Case EventName.evnmVwCheckDeleted, EventName.evnmVWCheckOnlyDeleted
                CType(Me.View, IViewFrmCheckSearch).CheckDeleted = CType(NewEvent, CheckDataEventArgs).Check

        End Select
    End Sub

End Class
