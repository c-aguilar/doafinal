Public Class Leadcode
    Public Shared Function Exist(leadcode As String) As Boolean
        Return SQL.Current.Exists("PE_Leadcodes", "Leadcode", leadcode)
    End Function
    Public Sub New(leadcode As String)
        Me.Leadcode = leadcode.ToUpper
        Dim record As Hashtable = SQL.Current.GetRecord("vw_PE_Leadcodes", "Leadcode", leadcode)
        With record
            Me.Lenght = .Item("lenght")
            Me.Ink = .Item("ink")
            Me.Print = .Item("print")
            Me.Wire = .Item("wire")
            Me.BatchQuantity = .Item("batchquantity")
            Me.Batch = .Item("batchtype")
            Me.Sequence = .Item("sequence")
            Me.Min = .Item("min")
            Me.Max = .Item("max")
            Me.Type = LeadcodeTypeString(.Item("type"))
            Me.Presser_A = .Item("presser_a")
            Me.Presser_B = .Item("presser_b")
            Me.Presser_C = .Item("presser_c")
            Me.MSpec_A = New MSpec(.Item("mspec_a"), .Item("gage_a"), .Item("cc_a"), .Item("sapcolor_a"), .Item("sapstripecolor_a"), .Item("threads_a"))
            If .Item("mspec_b") <> "" Then Me.MSpec_B = New MSpec(.Item("mspec_b"), .Item("gage_b"), .Item("cc_b"), .Item("sapcolor_b"), .Item("sapstripecolor_b"), .Item("threads_b"))
            If .Item("terminal_a") <> "" Then Me.Terminal_A = New Terminal(.Item("terminal_a"), .Item("terminalgage_a"), .Item("cch_a"), .Item("ccw_a"), .Item("ich_a"), .Item("icw_a"), .Item("strippinglenght_a"), .Item("tolerance_a"), .Item("tension_a"))
            If .Item("terminal_b") <> "" Then Me.Terminal_B = New Terminal(.Item("terminal_b"), .Item("terminalgage_b"), .Item("cch_b"), .Item("ccw_b"), .Item("ich_b"), .Item("icw_b"), .Item("strippinglenght_b"), .Item("tolerance_b"), .Item("tension_b"))
            If .Item("terminal_c") <> "" Then Me.Terminal_C = New Terminal(.Item("terminal_c"), .Item("terminalgage_c"), .Item("cch_c"), .Item("ccw_c"), .Item("ich_c"), .Item("icw_c"), .Item("strippinglenght_c"), .Item("tolerance_c"), .Item("tension_c"))
            If .Item("seal_a") <> "" Then Me.Seal_A = New Seal(.Item("seal_a"), .Item("sealcolor_a"))
            If .Item("seal_b") <> "" Then Me.Seal_B = New Seal(.Item("seal_b"), .Item("sealcolor_b"))
            If .Item("seal_c") <> "" Then Me.Seal_C = New Seal(.Item("seal_c"), .Item("sealcolor_c"))
            Me.Active = CBool(.Item("active"))
        End With
    End Sub
    Public Sub New(leadcode As String, mspec_a As MSpec, mspec_b As MSpec, terminal_a As Terminal, terminal_b As Terminal, terminal_c As Terminal, seal_a As Seal, seal_b As Seal, seal_c As Seal)
        Me.Leadcode = leadcode.ToUpper
    End Sub

    Public Property Leadcode As String
    Public Property Lenght As Decimal
    Public Property Ink As String
    Public Property Print As String
    Public Property Wire As String
    Public Property BatchQuantity As Integer
    Public Property Batch As BatchType
    Public Property Sequence As Integer
    Public Property CycleTime As Decimal '?
    Public Property Min As Integer
    Public Property Max As Integer
    Public Property Type As LeadcodeType
    Public Property MSpec_A As MSpec
    Public Property MSpec_B As MSpec
    Public Property Terminal_A As Terminal
    Public Property Terminal_B As Terminal
    Public Property Terminal_C As Terminal
    Public Property Seal_A As Seal
    Public Property Seal_B As Seal
    Public Property Seal_C As Seal
    Public Property Presser_A As String
    Public Property Presser_B As String
    Public Property Presser_C As String
    Public Property Active As Boolean
    Public Property Materials As New List(Of Harn)
    'Public Function ChangeMSpec(MSpec As String) As Boolean
    '    If RawMaterial.Format(MSpec) Then
    '        Me.MSpec_A = New MSpec(MSpec)
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    'Public Function ChangeTerminal() As Boolean

    'End Function

    Public Enum LeadcodeType
        Prototype
        RegularProduction
        Service
    End Enum

    Public Function LeadcodeTypeString(type As String) As LeadcodeType
        Select Case type
            Case "P"
                Return LeadcodeType.Prototype
            Case "R"
                Return LeadcodeType.RegularProduction
            Case "S"
                Return LeadcodeType.Service
            Case Else
                Return LeadcodeType.RegularProduction
        End Select
    End Function

    Public Function LeadcodeTypeString(type As LeadcodeType) As String
        Select Case type
            Case LeadcodeType.Prototype
                Return "P"
            Case LeadcodeType.RegularProduction
                Return "R"
            Case LeadcodeType.Service
                Return "S"
            Case Else
                Return "R"
        End Select
    End Function
    Public Enum BatchType
        A
        B
        C
    End Enum
End Class
