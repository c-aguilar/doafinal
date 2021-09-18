Imports System.IO
Imports Microsoft.VisualBasic.Devices
Imports SiGMaDesktop.ASNs
Imports SiGMaDesktop.Containers
Imports SiGMaDesktop.AsnAssignment

Public Class SQAValidation
#Region "Properties"
    Dim ASNsClass As New ASNs
    Dim ASNsassignmentClass As New AsnAssignment
    Dim ContainersClass As New Containers
    Dim ContentClass As New ContainersContent
    Dim plantsList As ArrayList
    Dim pushDeliverySAPclass As PushDeliverySAP
    Dim asnList As List(Of ScannedASN) = New List(Of ScannedASN)
    Dim asnDuplicates As List(Of String) = New List(Of String)
    Dim containersList As List(Of Containers) = New List(Of Containers)
    Dim contentList As List(Of ContainersContent) '= New List(Of ContainersContent)
    Dim containersListRefresh As List(Of Containers) = New List(Of Containers)
    Dim contentListRefresh As List(Of ContainersContent) = New List(Of ContainersContent)
    Dim ASNinContainersList As List(Of ASNinContainer)
    Dim dwldStartReportStatus As String
    Dim AsnStatusList As List(Of ASNsStatus)
    Dim findContent As ContainersContent
    Dim findContainer As Containers
    Dim NFND As String = ""
    Dim comboBoxRole As DataGridViewComboBoxCell
    Dim sapAsnList As List(Of ASNs)
    Dim Y497List As List(Of Y497)
    Dim rowIndexSQA As Integer
    Dim rowIndexSAP As Integer
    Dim routesList As ArrayList
    Dim discrepancies As Discrepancies
    Dim excel As Excel
    Dim matWOasnDatasource As DataTable
    Dim incomAsnDatasource As DataTable
    Public Shared regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("APTIV\SiGMa\Settings")

    Public Class ScannedASN
        Public Property ASN As String
    End Class
#End Region

    Private Sub scanAsnTB_KeyUp(sender As Object, e As KeyEventArgs) Handles scanAsnTB.KeyUp
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            If asnDuplicates.Contains(scanAsnTB.Text) Then
                scannedDeskAsnDGV.AllowUserToAddRows = False
                MessageBox.Show("ASN duplicate", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                scanAsnTB.Clear()
                scanAsnTB.Focus()
            Else
                If scanAsnTB.Text <> "" Then
                    Dim asn As String = scanAsnTB.Text
                    Dim x = asn.Length - 2
                    Dim y = asn.Substring(0, 2)
                    If y.Equals("1T") Then
                        Dim cleanAsn As String = asn.Substring(2, x)
                        scannedDeskAsnDGV.DataSource = Nothing
                        asnList.Add(New ScannedASN() With {
                                .ASN = cleanAsn
                            })
                        asnDuplicates.Add(cleanAsn)
                    Else
                        scannedDeskAsnDGV.DataSource = Nothing
                        asnList.Add(New ScannedASN() With {
                                .ASN = scanAsnTB.Text
                            })
                        asnDuplicates.Add(scanAsnTB.Text)
                    End If
                    scannedDeskAsnDGV.DataSource = asnList
                    scanAsnTB.Clear()
                    scanAsnTB.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub download_Click(sender As Object, e As EventArgs) Handles download.Click
        'Validate if there is a selected route
        Me.Cursor = Cursors.WaitCursor
        If routeCB.Text = "" Or routeCB.Text Is Nothing Then
            MessageBox.Show("Please select route", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf scannedDeskAsnDGV.RowCount < 0 Then
            MessageBox.Show("Please scan ASN", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If ASNscannedMHDGV.RowCount > 0 Then
                Dim count As Integer = 0
                For i As Integer = count To ASNscannedMHDGV.RowCount - 1
                    If ASNscannedMHDGV.Rows(count).Cells(0).Value.ToString() <> "" AndAlso ASNscannedMHDGV.Rows(count).Cells(0).Value.ToString() <> Nothing Then
                        asnList.Add(New ScannedASN() With {
                                .ASN = ASNscannedMHDGV.Rows(count).Cells(0).Value.ToString()
                            })
                    End If
                    count = count + 1
                Next
            End If
            Dim sap As New SAP
            If sap.Available Then
                dwldStartReportStatus = ASNsClass.downloadStartReport(plantsList, asnList)
                If dwldStartReportStatus = "Successs" Then
                    Dim txt As DataTable = New DataTable
                    txt = CSV.Datatable("C:\aptiv\downloadStartReport.txt", vbTab, False, False)
#Region "Format datatable"
                    If txt IsNot Nothing Then
                        txt.Columns.RemoveAt(0)
                        txt.Rows(0).Delete()
                        txt.Rows(0).Delete()
                        txt.Rows(0).Delete()
                        txt.Columns.RemoveAt(1)
                        txt.Columns.RemoveAt(17)
                        txt.Columns.Add("Qty", GetType(Decimal), "Convert(Col12,'System.Decimal')")
                        Dim SapAsns_data = txt.DefaultView.ToTable(True, "Col2", "Col4", "Col5", "Col6", "Col7", "Col8", "Col9", "Col10", "Col11", "Qty", "Col13", "Col14", "Col15", "Col16", "Col17", "Col18", "Col19", "Col21")
#End Region
#Region "Query to insert into ASNs"
                        If SQL.Current.Upsert(SapAsns_data, "tmp_startReport", "CREATE TABLE #tmp_startReport (Original_document VARCHAR(20),ID VARCHAR(4),IDoc_number VARCHAR(20),Deliv_Date VARCHAR(10),Material VARCHAR(15),Plant VARCHAR(5),Vendor VARCHAR(10),Purchase_order_no VARCHAR(10),Item INT,Delivery_quantity FLOAT,Delivery VARCHAR(10),Status_of_IDoc_data_processing INT,ASN_Data_Status INT,ASN_Posting_Status INT,Deletion_Indicator VARCHAR(2),Cumulative_quantity FLOAT,JIT_No VARCHAR(12),GRT INT);",
                                                                           "MERGE dbo.ASNs AS target USING #tmp_startReport AS source ON target.Original_document = source.Original_document AND target.Material = source.Material AND target.Delivery_quantity = source.Delivery_quantity AND target.IDoc_number = source.IDoc_number AND target.Plant = source.Plant WHEN MATCHED THEN UPDATE SET ID = source.ID,IDoc_number = source.IDoc_number,Deliv_Date = source.Deliv_Date,Material = source.Material,Plant = source.Plant,Vendor = source.Vendor,Purchase_order_no = source.Purchase_order_no,Item = source.Item,Delivery_quantity = source.Delivery_quantity,Delivery = source.Delivery,Status_of_IDoc_data_processing = source.Status_of_IDoc_data_processing,ASN_Data_Status = source.ASN_Data_Status,ASN_Posting_Status = source.ASN_Posting_Status,Deletion_Indicator = source.Deletion_Indicator,Cumulative_quantity = source.Cumulative_quantity,JIT_No = source.JIT_No,GRT = source.GRT WHEN NOT MATCHED THEN INSERT (Original_document, ID, IDoc_number, Deliv_Date, Material, Plant, Vendor, Purchase_order_no, Item, Delivery_quantity, Delivery,Status_of_IDoc_data_processing, ASN_Data_Status, ASN_Posting_Status, Deletion_Indicator, Cumulative_quantity, JIT_No, GRT) VALUES (source.Original_document, source.ID, source.IDoc_number, source.Deliv_Date, source.Material, source.Plant, source.Vendor, source.Purchase_order_no,source.Item, source.Delivery_quantity, source.Delivery, source.Status_of_IDoc_data_processing, source.ASN_Data_Status, source.ASN_Posting_Status, source.Deletion_Indicator, source.Cumulative_quantity, source.JIT_No, source.GRT);") Then
                            'If the insert was successful, the inserted info is displayed
                            'Dim values = String.Join("','", asnDuplicates)
                            AsnStatusList = ASNsClass.insertASNsStatus(asnList, routeCB.Text)
                            If AsnStatusList IsNot Nothing Then
                                ASNsClass.insertRoutesASNs(asnList, routeCB.Text)
                                'For Each var In AsnStatusList
                                '    If var.Status = "NFND" Then
                                '        NFND += var.ASN + vbLf
                                '    End If
                                'Next
                            End If
                            'If NFND IsNot "" Then
                            '    MessageBox.Show(NFND, "ASNs not foud in SAP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            'End If
                            'NFND = ""
                            fillSAPdgv()
                            'SapDownloadedInfoDGV.DataSource = sapAsnList
                            If sapAsnList IsNot Nothing Then
                                sapAsnList.Clear()
                            End If
                            sapAsnList = ASNsClass.getSapASNs(routeCB.Text)
                            excetuteASNassigment()
                            asnList.Clear()
                            scannedDeskAsnDGV.DataSource = Nothing
                            ASNscannedMHDGV.DataSource = Nothing
                            ASNscannedMHDGV.Rows.Clear()
                            scanAsnTB.Focus()
#End Region
                        Else
                            MessageBox.Show("Data bulk error", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Error reading file", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                ElseIf dwldStartReportStatus = "No data" Then
                    MessageBox.Show("Please try again", "No data was found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    scannedDeskAsnDGV.DataSource = Nothing
                    ASNscannedMHDGV.DataSource = Nothing
                    ASNscannedMHDGV.Rows.Clear()
                    asnList.Clear()
                Else
                    MessageBox.Show("Error downloading information", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("No SAP session found", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        Me.Cursor = Nothing
    End Sub

    Private Sub SQAValidation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get the open routes
        routesList = SQL.Current.GetList("SELECT [IdRoute] FROM [Routes] WHERE [Status]  <> 'CLSQA'")
        For Each var In routesList
            routeCB.Items.Add(var)
        Next
    End Sub

    Private Sub routeCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles routeCB.SelectedIndexChanged
        If routeCB.Text IsNot "" Then
            Me.Cursor = Cursors.WaitCursor
            'Get the plants of selected route
            plantsList = SysPlants.Current.getRoutesPlants(routeCB.Text)
            refreshMaterialHandlerScanned(True, False)
            excetuteASNassigment()
            Me.Cursor = Nothing
        Else
            MessageBox.Show("Please select route", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub TimerRefreshMaterialHandler_Tick(sender As Object, e As EventArgs) Handles TimerRefreshMaterialHandler.Tick
        If SapDownloadedInfoDGV.RowCount > 0 And materialScannedDGV.RowCount > 0 Then
            Me.Cursor = Cursors.WaitCursor
            refreshMaterialHandlerScanned(False, True)
            Me.Cursor = Nothing
        End If
    End Sub

    Private Sub refreshMaterialHandlerScanned(isFirstLoad As Boolean, isSavedNeed As Boolean)
        If plantsList.Count = 0 Or plantsList Is Nothing Then
            plantsList = SysPlants.Current.getRoutesPlants(routeCB.Text)
        End If
        If routeCB.Text IsNot "" And routeCB.Text IsNot Nothing Then
#Region "Fill ASNs scanned by MH"
            Dim dwldAsn As ArrayList
            dwldAsn = SQL.Current.GetList(String.Format("SELECT CASE WHEN A.Status IS NULL THEN AIC.[ASN] ELSE '' END AS ASN
                                                                    FROM [AsnsInContainer] AIC 
                                                                    INNER JOIN [Containers] C ON C.IdContainer = AIC.IdContainer 
                                                                    LEFT JOIN ASNsStatus A ON A.ASN = AIC.ASN 
                                                                      WHERE C.IdRoute = {0}", routeCB.Text))
            Dim results As List(Of ScannedASN) = New List(Of ScannedASN)
            For Each var In dwldAsn
                If var IsNot "" Then
                    results.Add(New ScannedASN() With {
                        .ASN = var.ToString()
                                })
                End If
            Next
            ASNscannedMHDGV.DataSource = results
#End Region
            If isFirstLoad = True Then
#Region "Load for the first time"
                containersList = ContainersClass.getContainersByRoute(routeCB.Text)
                contentList = ContentClass.getContentByRoute(routeCB.Text)
                ASNinContainersList = New List(Of ASNinContainer)
                ASNinContainersList = ContainersClass.getASNinContainer(routeCB.Text)
                fillSAPdgv()
                If Not contentList Is Nothing Then
                    materialScannedDGV.DataSource = Nothing
                    materialScannedDGV.Rows.Clear()
                    materialScannedDGV.Columns.Clear()
                    materialScannedDGV.DataSource = contentList
                    materialScannedDGV.Columns(0).Visible = False
                    materialScannedDGV.Columns(1).Visible = False
                End If
                excecuteDiscrepancies()
#End Region
            Else
#Region "Add new scanned pallets to containers models"
                ASNinContainersList = New List(Of ASNinContainer)
                ASNinContainersList = ContainersClass.getASNinContainer(routeCB.Text)
                containersListRefresh = ContainersClass.getContainersByRoute(routeCB.Text)
                contentListRefresh = ContentClass.getContentByRoute(routeCB.Text)
                findContent = New ContainersContent
                findContainer = New Containers
                If contentList Is Nothing Then
                    contentList = ContentClass.getContentByRoute(routeCB.Text)
                Else
                    For Each var In contentListRefresh
                        findContent = contentList.Find(Function(x) x.IdContainer = var.IdContainer)
                        If findContent Is Nothing AndAlso findContent Is "" Then
                            contentList.Add(New ContainersContent() With {
                                            .IdContainer = var.IdContainer,
                                            .IdContainerContent = var.IdContainerContent,
                                            .ASN = var.ASN,
                                            .PartNumber = var.PartNumber,
                                            .Qty = var.Qty,
                                            .UOM = var.UOM
                            })
                        End If
                    Next
                End If
                If containersList Is Nothing Then
                    containersList = ContainersClass.getContainersByRoute(routeCB.Text)
                Else
                    For Each var In containersListRefresh
                        findContainer = containersList.Find(Function(x) x.IdContainer = var.IdContainer)
                        If findContainer Is Nothing AndAlso findContainer Is "" Then
                            containersList.Add(New Containers() With {
                                            .IdContainer = var.IdContainer,
                                            .HasDamage = var.HasDamage,
                                            .IdPallet = var.IdPallet,
                                            .IdPushDelivery = var.IdPushDelivery,
                                            .IdRoute = var.IdRoute,
                                            .IsPallet = var.IsPallet,
                                            .Plant = var.Plant,
                                            .ReceivedDate = var.ReceivedDate,
                                            .VendorInfo = var.VendorInfo
                            })
                        End If
                    Next
                End If
#End Region
                excetuteASNassigment()
                excecuteDiscrepancies()
            End If
        End If
        scanAsnTB.Focus()
        If ASNscannedMHDGV.RowCount > 0 Then
            Dim count As Integer = 0
            For i As Integer = count To ASNscannedMHDGV.RowCount - 1
                If Not asnDuplicates.Contains(ASNscannedMHDGV.Rows(count).Cells(0).Value.ToString()) Then
                    If ASNscannedMHDGV.Rows(count).Cells(0).Value.ToString() <> "" AndAlso ASNscannedMHDGV.Rows(count).Cells(0).Value.ToString() <> Nothing Then
                        asnDuplicates.Add(ASNscannedMHDGV.Rows(count).Cells(0).Value.ToString())
                    End If
                    count = count + 1
                End If
            Next
        End If
    End Sub

    Private Sub finishBtn_Click(sender As Object, e As EventArgs) Handles finishBtn.Click
        If Not routeCB.Text = "" Or Not routeCB.Text Is Nothing Then

        End If
        If SQL.Current.GetString(String.Format("SELECT [STATUS] FROM Routes WHERE idRoute = '{0}'", routeCB.Text)).Equals("CLSQA") Then
            MessageBox.Show("The route was finished by another user", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            clear()
        Else
            Me.Cursor = Cursors.WaitCursor
            Dim result As DialogResult = MessageBox.Show(Me, "Do you want to finish the route and save the Discrepancies file? ", "Finish", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = vbYes Then
#Region "Actualizacion de ASNs"
                'Descargar Y497 para revisar el estatus del ASN
                Y497List = ASNsClass.downloadY497(plantsList, routeCB.Text)
                If Y497List IsNot Nothing And Y497List.Count > 0 Then
                    Dim summary = (From sum In contentList
                                   Group By Key = New With {Key sum.ASN, Key sum.PartNumber} Into Group
                                   Select New With {Key .ASN = Key.ASN, Key .PartNumber = Key.PartNumber, Key .Qty = Group.Sum(Function(q) q.Qty)}).ToList()
                    For Each asn In summary
                        If asn.ASN IsNot "" Then
                            For Each pn In Y497List
                                If asn.ASN = pn.ASN And asn.Qty = pn.OutstandingQty Then
                                    SQL.Current.Update("ASNsStatus", "Status", "CMPLT", "ASN", asn.ASN)
                                ElseIf asn.ASN = pn.ASN And pn.OutstandingQty > asn.Qty Then
                                    SQL.Current.Update("ASNsStatus", "Status", "PART", "ASN", asn.ASN)
                                ElseIf pn.OutstandingQty = 0 Then
                                    SQL.Current.Update("ASNsStatus", "Status", "CMPLT", "ASN", asn.ASN)
                                End If
                            Next
                        End If
                    Next
                Else
                End If
                'probar
                For Each asn In contentList
                    If asn IsNot "" Then
                        SQL.Current.Update("ContainersContent", "ASN", asn.ASN, "IdContainerContent", asn.IdContainerContent)
                    End If
                Next
                'For i As Integer = 0 To materialScannedDGV.RowCount - 1
                '    If Not materialScannedDGV.Rows(i).Cells(5).Value Is Nothing Or Not materialScannedDGV.Rows(i).Cells(5).Value Is "" Then
                '        SQL.Current.Update("ContainersContent", "ASN", materialScannedDGV.Rows(i).Cells(5).Value, "IdContainerContent", materialScannedDGV.Rows(i).Cells(0).Value)
                '    End If
                'Next
#End Region
#Region "Creacion y asignacion de push delivery"
                pushDeliverySAPclass = New PushDeliverySAP()
                Dim pushDeliveryResult As PushDeliverySAP.PushDeliveryResult
                Dim pushDeliveryLabels As PushDeliverySAP.PushDeliveryLabels
                Dim qtyPallets As Integer = SQL.Current.GetScalar(String.Format("SELECT COUNT(*) FROM [Containers] WHERE (IdRoute = {0} AND IsPallet = 1) 
                                                                            AND IdContainer IN (SELECT IdPallet FROM [Containers] WHERE IdRoute = {0})", routeCB.Text))
                For Each plantVar In plantsList
                    pushDeliveryResult = New PushDeliverySAP.PushDeliveryResult()
                    pushDeliveryLabels = New PushDeliverySAP.PushDeliveryLabels()
                    pushDeliveryLabels = getPushDeliveryLabels(plantVar.ToString(), qtyPallets)
                    If pushDeliveryLabels.Created Then
                        pushDeliveryResult = getPushDelivery(plantVar.ToString(), pushDeliveryLabels, qtyPallets)
                    Else
                        While pushDeliveryLabels.Created = False
                            pushDeliveryLabels = getPushDeliveryLabels(plantVar.ToString(), qtyPallets)
                            pushDeliveryResult = getPushDelivery(plantVar.ToString(), pushDeliveryLabels, qtyPallets)
                        End While
                    End If
                Next
#End Region
                SQL.Current.Execute(String.Format("UPDATE [Routes] SET [Status] = 'CLSQA', [ClosedDate] = '{0}', [ClosedBy] = '{1}' WHERE IdRoute = '{2}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), User.Current.Badge, routeCB.Text))
#Region "Exportar archivo de discrepancias"
                excel = New Excel()
                excel.ExportDiscrepancies(routeCB.Text, matWOasnDatasource, incomAsnDatasource)
#End Region
                clear()
                MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Cursor = Nothing
            End If
        End If
    End Sub

    Private Sub setCellComboBoxItems(ByVal dataGrid As DataGridView, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal colToCopy As Integer, ByVal itemsToAdd As List(Of String), isList As Boolean)
        If isList Then
            Dim dgvcbc As DataGridViewComboBoxCell = CType(dataGrid.Rows(rowIndex).Cells(colIndex), DataGridViewComboBoxCell)
            dgvcbc.Items.Clear()
            For Each itemToAdd In itemsToAdd
                dgvcbc.Items.Add(itemToAdd)
            Next
        Else
            Dim dgvcbc As DataGridViewComboBoxCell = CType(dataGrid.Rows(rowIndex).Cells(colIndex), DataGridViewComboBoxCell)
            dgvcbc.Items.Clear()
            dgvcbc.Items.Add(dataGrid.Rows(rowIndex).Cells(colToCopy).Value)
            dataGrid.Rows(rowIndex).Cells(colIndex).Value = dataGrid.Rows(rowIndex).Cells(colToCopy).Value
        End If
    End Sub

    Private Sub excetuteASNassigment()
        If SapDownloadedInfoDGV.RowCount > 0 And materialScannedDGV.RowCount > 0 Then
            contentList = ASNsassignmentClass.ASNassignment(routeCB.Text, plantsList, sapAsnList, contentList)
            percentageAssigment(contentList)
#Region "Fomat data grid views"
            If Not contentList Is Nothing Then
                materialScannedDGV.DataSource = Nothing
                materialScannedDGV.Rows.Clear()
                materialScannedDGV.Columns.Clear()
                materialScannedDGV.DataSource = contentList
                materialScannedDGV.Columns(0).Visible = False
                materialScannedDGV.Columns(1).Visible = False
                Dim statusRoute As String = SQL.Current.GetString(String.Format("SELECT [Status] FROM [Routes] WHERE IdRoute = {0}", routeCB.Text))
                If statusRoute = "CLSMH" Then
                    Dim comboBoxAsn As DataGridViewComboBoxCell
                    comboBoxAsn = New DataGridViewComboBoxCell()
                    Dim comboAsn As DataGridViewColumn
                    comboAsn = New DataGridViewColumn(comboBoxAsn)
                    materialScannedDGV.Columns.Add(comboAsn)
                    materialScannedDGV.Columns(6).HeaderText = materialScannedDGV.Columns(5).HeaderText
                    For i As Integer = 0 To materialScannedDGV.RowCount - 1
                        For Each var In contentList
                            If var.IdContainerContent = materialScannedDGV.Rows(i).Cells(0).Value Then
                                If Not var.possibleASNs Is Nothing Then
                                    setCellComboBoxItems(materialScannedDGV, i, 6, 5, var.possibleASNs, True)
                                ElseIf Not var.ASN Is "" Then
                                    setCellComboBoxItems(materialScannedDGV, i, 6, 5, var.possibleASNs, False)
                                    materialScannedDGV.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                                End If
                            End If
                        Next
                    Next
                    materialScannedDGV.Columns(5).Visible = False
                End If
            End If
        End If
#End Region
    End Sub

    Private Function percentageAssigment(contentList As List(Of ContainersContent))
        Dim assigment As Integer = 0
        percentageLbl.Text = Nothing
        For Each var In contentList
            If var.ASN IsNot "" And var.ASN IsNot Nothing Then
                assigment = assigment + 1
            End If
        Next
        Dim contentCount As Integer = contentList.Count
        Dim percentage As Decimal = (assigment * contentCount) / 100
        percentageLbl.Text = percentage.ToString() + " %"
    End Function

    Private Sub clear()
        routeCB.Items.Clear()
        Dim routesList = SQL.Current.GetList("SELECT [IdRoute] FROM [Routes] WHERE [Status] <> 'CLSQA'")
        For Each x In routesList
            routeCB.Items.Add(x)
        Next
        plantsList = New ArrayList
        asnList = New List(Of ScannedASN)
        asnDuplicates = New List(Of String)
        containersList = New List(Of Containers)
        contentList = New List(Of ContainersContent)
        containersListRefresh = New List(Of Containers)
        contentListRefresh = New List(Of ContainersContent)
        ASNinContainersList = New List(Of ASNinContainer)
        AsnStatusList = New List(Of ASNsStatus)
        plantsList.Clear()
        asnList.Clear()
        asnDuplicates.Clear()
        containersList.Clear()
        contentList.Clear()
        containersListRefresh.Clear()
        contentListRefresh.Clear()
        ASNinContainersList.Clear()
        dwldStartReportStatus = ""
        AsnStatusList.Clear()
        NFND = ""
        materialScannedDGV.DataSource = Nothing
        materialScannedDGV.Rows.Clear()
        materialScannedDGV.Columns.Clear()
        materialScannedDGV.DefaultCellStyle.BackColor = Color.White
        SapDownloadedInfoDGV.DataSource = Nothing
        SapDownloadedInfoDGV.Rows.Clear()
        SapDownloadedInfoDGV.Columns.Clear()
        SapDownloadedInfoDGV.DefaultCellStyle.BackColor = Color.White
        ASNscannedMHDGV.DataSource = Nothing
        ASNscannedMHDGV.Rows.Clear()
        ASNscannedMHDGV.Columns.Clear()
        scannedDeskAsnDGV.DataSource = Nothing
        scannedDeskAsnDGV.Rows.Clear()
        scannedDeskAsnDGV.Columns.Clear()
        routeCB.Text = ""
        rowIndexSQA = 0
        rowIndexSAP = 0
        percentageLbl.Text = ""
        MatWOasnDGV.DataSource = Nothing
        MatWOasnDGV.Rows.Clear()
        MatWOasnDGV.Columns.Clear()
        asnWOmatDGV.DataSource = Nothing
        asnWOmatDGV.Rows.Clear()
        asnWOmatDGV.Columns.Clear()
        incomAsnDatasource.Clear()
        matWOasnDatasource.Clear()
    End Sub

    Private Sub scannedDeskAsnDGV_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles scannedDeskAsnDGV.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Me.scannedDeskAsnDGV.Rows(e.RowIndex).Selected = True
            rowIndexSQA = e.RowIndex
            'Me.scannedDeskAsnDGV.CurrentCell = Me.scannedDeskAsnDGV.Rows(rowIndex).Cells(1)
            Me.ContextMenuStripSQA.Show(Me.scannedDeskAsnDGV, e.Location)
            ContextMenuStripSQA.Show(Cursor.Position)
        End If
    End Sub

    Private Sub DeleteToolStripMenuItemSQA_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItemSQA.Click
        asnList.RemoveAt(rowIndexSQA)
        asnDuplicates.RemoveAt(rowIndexSQA)
        scannedDeskAsnDGV.DataSource = Nothing
        scannedDeskAsnDGV.DataSource = asnList
        'scannedDeskAsnDGV.Rows.RemoveAt(rowIndexSQA)
    End Sub

    Private Sub SapDownloadedInfoDGV_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SapDownloadedInfoDGV.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Me.SapDownloadedInfoDGV.Rows(e.RowIndex).Selected = True
            rowIndexSAP = e.RowIndex
            Me.ContextMenuStripSAP.Show(Me.SapDownloadedInfoDGV, e.Location)
            ContextMenuStripSAP.Show(Cursor.Position)
        End If
    End Sub

    Private Sub DeleteToolStripMenuItemSAP_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItemSAP.Click
        SQL.Current.Execute(String.Format("DELETE FROM [Routes_ASNs] WHERE ASN = '{0}' AND IdRoute = '{1}'", SapDownloadedInfoDGV.Rows(rowIndexSAP).Cells(0).Value.ToString(), routeCB.Text))
        SapDownloadedInfoDGV.Rows.RemoveAt(rowIndexSAP)
    End Sub

    Private Sub fillSAPdgv()
        SQL.Current.FillDataGrid(SapDownloadedInfoDGV, String.Format("SELECT DISTINCT RA.ASN, ISNULL(A.[Material],'') AS Material, ISNULL(A.[Plant],'') AS Plant, ISNULL(A.[Vendor],'') AS Vendor, 
                                                                                ISNULL(A.[Purchase_order_no],'') AS PO, ISNULL(A.[Item],'') AS Item, ISNULL(A.[Delivery_quantity],'') AS Qty
	                                                                    FROM [Routes_ASNs] RA
	                                                                    LEFT JOIN ASNs A ON A.original_document = RA.ASN
                                                                      WHERE RA.IdRoute = {0}", routeCB.Text), True, False, False)
        For i As Integer = 0 To SapDownloadedInfoDGV.RowCount - 1
            If SapDownloadedInfoDGV.Rows(i).Cells(2).Value.ToString() Is "" Then
                SapDownloadedInfoDGV.Rows(i).DefaultCellStyle.BackColor = Color.Red
                SapDownloadedInfoDGV.Rows(i).DefaultCellStyle.ForeColor = Color.White
            End If
        Next
    End Sub

    Private Function getPushDelivery(plant As String, pushDeliveryLabels As PushDeliverySAP.PushDeliveryLabels, qtyPallets As Integer) As PushDeliverySAP.PushDeliveryResult
        Dim pushDeliveryResult As PushDeliverySAP.PushDeliveryResult
        pushDeliveryResult = New PushDeliverySAP.PushDeliveryResult()
        Dim indexPalletList As Integer = 0
        Dim palletsList As ArrayList = SQL.Current.GetList(String.Format("SELECT IdContainer FROM [Containers] WHERE (IdRoute = {0} AND IsPallet = 1) 
                                                                AND IdContainer IN (SELECT IdPallet FROM [Containers] WHERE IdRoute = {0})", routeCB.Text))
        Dim pushDeliveryList As List(Of PushDeliverySAP.PushDeliveryPallet) = pushDeliverySAPclass.getPushDeliveryPallet(routeCB.Text, pushDeliveryLabels)
        Dim shipTo As String = SQL.Current.GetString(String.Format("SELECT [ShipTo] FROM [ShippingPoint] WHERE [Code] = '{0}'", plant))
        pushDeliveryResult = pushDeliverySAPclass.LM00_4_5_1_2(plant, "ZUL", regKey.GetValue("ShippingPoint").ToString(), shipTo, "US40", "30", "10", "PKXD", "", pushDeliveryList)
        If pushDeliveryResult.Finished Then
            SQL.Current.Insert("PushDeliveries", {"IdPushDelivery", "CrossDock", "Plant"}, {pushDeliveryResult.SAPDelivery, regKey.GetValue("ShippingPoint").ToString(), plant})
            For Each pushDelivery In pushDeliveryLabels.Items
                For indexPalletList = indexPalletList To palletsList.Count - 1
                    SQL.Current.Update("Containers", "IdPushDelivery", pushDeliveryResult.SAPDelivery, "IdPallet", palletsList(indexPalletList))
                    SQL.Current.Insert("PushDeliveryInContainer", {"IdContainer", "PushDelivery"}, {palletsList(indexPalletList), pushDelivery})
                    pushDeliverySAPclass.printPushDeliveries(pushDelivery, pushDeliveryResult.SAPDelivery, palletsList(indexPalletList), plant)
                    indexPalletList = indexPalletList + 1
                    Exit For
                Next
            Next
        Else
            While pushDeliveryResult.Finished = False
                pushDeliveryList.Clear()
                pushDeliveryResult = Nothing
                pushDeliveryLabels = getPushDeliveryLabels(plant, qtyPallets)
                pushDeliveryList = pushDeliverySAPclass.getPushDeliveryPallet(routeCB.Text, pushDeliveryLabels)
                pushDeliveryResult = pushDeliverySAPclass.LM00_4_5_1_2(plant, "ZUL", regKey.GetValue("ShippingPoint").ToString(), shipTo, "US40", "30", "10", "PKXD", "", pushDeliveryList)
            End While
            SQL.Current.Insert("PushDeliveries", {"IdPushDelivery", "CrossDock", "Plant"}, {pushDeliveryResult.DummyDelivery, regKey.GetValue("ShippingPoint").ToString(), plant})
            For Each pushDelivery In pushDeliveryLabels.Items
                For indexPalletList = indexPalletList To palletsList.Count - 1
                    SQL.Current.Update("Containers", "IdPushDelivery", pushDeliveryResult.DummyDelivery, "IdContainer", palletsList(indexPalletList))
                    SQL.Current.Insert("PushDeliveryInContainer", {"IdContainer", "PushDelivery"}, {palletsList(indexPalletList), pushDelivery})
                    pushDeliverySAPclass.printPushDeliveries(pushDelivery, pushDeliveryResult.DummyDelivery, palletsList(indexPalletList), plant)
                    indexPalletList = indexPalletList + 1
                    Exit For
                Next
            Next
        End If
        Return pushDeliveryResult
    End Function

    Private Function getPushDeliveryLabels(plant As String, qtyPallets As Integer) As PushDeliverySAP.PushDeliveryLabels
        Dim pushDeliveryLabels = New PushDeliverySAP.PushDeliveryLabels()
        pushDeliveryLabels = pushDeliverySAPclass.LM00_4_5_4(plant, qtyPallets)
        Return pushDeliveryLabels
    End Function

    Private Sub excecuteDiscrepancies()
        discrepancies = New Discrepancies()
        If Not MatWOasnDGV.DataSource Is Nothing Then
            MatWOasnDGV.DataSource = Nothing
            MatWOasnDGV.Rows.Clear()
            MatWOasnDGV.Columns.Clear()
        End If
        If Not asnWOmatDGV.DataSource Is Nothing Then
            asnWOmatDGV.DataSource = Nothing
            asnWOmatDGV.Rows.Clear()
            asnWOmatDGV.Columns.Clear()
        End If
        incomAsnDatasource = SQL.Current.GetDatatable(String.Format("WITH MissingMaterial AS(
	                                                    SELECT A.Original_document AS ASN, A.Material AS PartNumber 
	                                                    FROM [Routes_ASNs] RA
	                                                    INNER JOIN ASNsStatus ASS ON ASS.ASN = RA.ASN
	                                                    INNER JOIN ASNs A ON A.Original_document = RA.ASN
	                                                    WHERE RA.IdRoute = {0}
	                                                    EXCEPT
	                                                    SELECT CC.ASN, CC.PartNumber
	                                                    FROM [Routes] R 
	                                                    INNER JOIN Containers C ON C.IdRoute = R.IdRoute 
	                                                    INNER JOIN ContainersContent CC ON CC.IdContainer = C.IdContainer
	                                                    WHERE CC.ASN IS NOT NULL AND R.IdRoute = {0})
	                                                    SELECT MM.*, A.Delivery_quantity AS Qty FROM MissingMaterial MM 
                                                    INNER JOIN ASNs A ON A.Original_document = MM.ASN", routeCB.Text))
        asnWOmatDGV.DataSource = incomAsnDatasource
        matWOasnDatasource = SQL.Current.GetDatatable(String.Format("SELECT C.Plant, C.IdPallet, CC.PartNumber, CC.Qty
	                                            FROM ContainersContent CC
	                                            INNER JOIN Containers C ON C.IdContainer = CC.IdContainer
	                                            WHERE CC.ASN IS NULL AND C.IdRoute = {0}", routeCB.Text))
        MatWOasnDGV.DataSource = matWOasnDatasource
        'asnWOmatDGV.DataSource = discrepancies.getASNmissingMaterial(routeCB.Text)
        'MatWOasnDGV.DataSource = discrepancies.getMaterialWithOutASN(routeCB.Text)
    End Sub

    Private Sub exportDiscrepanciesBtn_Click(sender As Object, e As EventArgs) Handles exportDiscrepanciesBtn.Click
        excel = New Excel()
        excel.ExportDiscrepancies(routeCB.Text, matWOasnDatasource, incomAsnDatasource)
    End Sub

    'Private Sub routeCB_Enter(sender As Object, e As EventArgs) Handles routeCB.Enter
    '    If Not routeCB.Text Is "" Or Not routeCB.Text = Nothing Then
    '        Dim isFoundRoute As Boolean
    '        Me.Cursor = Cursors.WaitCursor
    '        For Each routeId In routesList.ToString()
    '            If routeId = routeCB.Text Then
    '                isFoundRoute = 1
    '            Else
    '                isFoundRoute = 0
    '            End If
    '        Next
    '        Me.Cursor = Nothing
    '        If isFoundRoute = 1 Then
    '            Me.Cursor = Cursors.WaitCursor
    '            'Get the plants of selected route
    '            plantsList = SysPlants.Current.getRoutesPlants(routeCB.Text)
    '            refreshMaterialHandlerScanned(True, False)
    '            excetuteASNassigment()
    '            Me.Cursor = Nothing
    '        Else
    '            MessageBox.Show("The entered route is not valid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If
    '    End If
    'End Sub
End Class