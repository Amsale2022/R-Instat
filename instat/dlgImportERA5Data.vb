﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat.Translations
Public Class dlgImportERA5Data
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsImportFromCDSFunction As New RFunction
    Private clsWfsetkeyFunction As New RFunction
    Private clsConcLonFunction As New RFunction
    Private clsConcLatFunction As New RFunction
    Private Sub dlgImportERA5Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If

        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        TestOkEnabled()
    End Sub

    Private Sub InitialiseDialog()
        Dim dctDatasets As New Dictionary(Of String, String)
        Dim dctElements As New Dictionary(Of String, String)

        ucrInputMinLongitude.SetParameter(New RParameter("min_lon", 0, bNewIncludeArgumentName:=False))
        ucrInputMinLongitude.AddQuotesIfUnrecognised = False
        ucrInputMinLongitude.SetValidationTypeAsNumeric(dcmMin:=-180, dcmMax:=180)

        ucrInputMaxLongitude.SetParameter(New RParameter("max_lon", 1, bNewIncludeArgumentName:=False))
        ucrInputMaxLongitude.AddQuotesIfUnrecognised = False
        ucrInputMaxLongitude.SetValidationTypeAsNumeric(dcmMin:=-180, dcmMax:=180)

        ucrInputMinLatitude.SetParameter(New RParameter("min_lat", 0, bNewIncludeArgumentName:=False))
        ucrInputMinLatitude.AddQuotesIfUnrecognised = False
        ucrInputMinLatitude.SetValidationTypeAsNumeric(dcmMin:=-90, dcmMax:=90)

        ucrInputMaxLatitude.SetParameter(New RParameter("max_lat", 1, bNewIncludeArgumentName:=False))
        ucrInputMaxLatitude.AddQuotesIfUnrecognised = False
        ucrInputMaxLatitude.SetValidationTypeAsNumeric(dcmMin:=-90, dcmMax:=90)

        ucrInputData.SetParameter(New RParameter("dataset", 1))
        dctDatasets.Add("ERA5 hourly data (single levels)", Chr(34) & "reanalysis-era5-single-levels" & Chr(34))
        ucrInputData.SetItems(dctDatasets)
        ucrInputData.SetDropDownStyleAsNonEditable()

        ucrInputElement.SetParameter(New RParameter("elements", 2))
        dctElements.Add("Total precipitation", Chr(34) & "total_precipitation" & Chr(34))
        dctElements.Add("10m u-component of wind", Chr(34) & "10m_u_component_of_wind" & Chr(34))
        dctElements.Add("10m v-component of wind", Chr(34) & "10m_v_component_of_wind" & Chr(34))
        dctElements.Add("2m dewpoint temperature", Chr(34) & "2m_dewpoint_temperature" & Chr(34))
        dctElements.Add("2m temperature", Chr(34) & "2m_temperature" & Chr(34))
        dctElements.Add("Mean sea level pressure", Chr(34) & "mean_sea_level_pressure" & Chr(34))
        dctElements.Add("Mean wave direction", Chr(34) & "mean_wave_direction" & Chr(34))
        dctElements.Add("Mean wave period", Chr(34) & "mean_wave_period" & Chr(34))
        dctElements.Add("Sea surface temperature", Chr(34) & "sea_surface_temperature" & Chr(34))
        dctElements.Add("Significant Height of combined wind waves And swell", Chr(34) & "significant_height_of_combined_wind_waves_and_swell" & Chr(34))
        dctElements.Add("Surface pressure", Chr(34) & "surface_pressure" & Chr(34))
        ucrInputElement.SetItems(dctElements)
        ucrInputElement.SetDropDownStyleAsNonEditable()

        ucrDtpStartDate.SetParameter(New RParameter("start_date", 3))

        ucrDtpEndDate.SetParameter(New RParameter("end_date", 4))

        ucrChkDoNotImport.SetParameter(New RParameter("import", 8))
        ucrChkDoNotImport.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkDoNotImport.SetText("Don' t import data after downloading")
        ucrChkDoNotImport.SetRDefault("TRUE")

        ucrInputNewDataFrameName.SetParameter(New RParameter("new_name", 9))

        ucrInputFilePath.SetParameter(New RParameter("path", 7))
        ucrInputFilePath.IsReadOnly = True

        ucrInputUserID.SetParameter(New RParameter("user", 0))

        ucrInputAPIKey.SetParameter(New RParameter("key", 1))

        'user <- ecmwfr::wf_set_key(user = "xxx",
        '                   key = "xxx",
        '                   service = "cds")

        'data_book$import_from_cds(user = user, DataSet = "reanalysis-era5-single-levels",
        '                          elements = "total_precipitation", start_date = as.Date("1999/1/1"),
        '                          end_date = as.Date("1999/1/31"), lon = c(20, 20.3), lat = c(50, 50.3), 
        '                          path = "C:/Users/Danny/Downloads")
    End Sub

    Private Sub SetDefaults()
        clsImportFromCDSFunction = New RFunction
        clsWfsetkeyFunction = New RFunction
        clsConcLonFunction = New RFunction
        clsConcLatFunction = New RFunction

        clsWfsetkeyFunction.SetPackageName("ecmwfr")
        clsWfsetkeyFunction.SetRCommand("wf_set_key")
        clsWfsetkeyFunction.AddParameter("service", Chr(34) & "cds" & Chr(34), iPosition:=2)
        clsWfsetkeyFunction.SetAssignTo("user")

        'temporary
        clsWfsetkeyFunction.AddParameter("user", Chr(34) & "18864" & Chr(34), iPosition:=0)
        clsWfsetkeyFunction.AddParameter("key", Chr(34) & "b2a6cecb-27b0-4bcf-8b30-e7dbc48230e1" & Chr(34), iPosition:=1)

        clsImportFromCDSFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$import_from_cds")
        clsImportFromCDSFunction.AddParameter("user", clsRFunctionParameter:=clsWfsetkeyFunction, iPosition:=0)
        clsImportFromCDSFunction.AddParameter("dataset", Chr(34) & "reanalysis-era5-single-levels" & Chr(34), iPosition:=1)
        clsImportFromCDSFunction.AddParameter("elements", Chr(34) & "total_precipitation" & Chr(34), iPosition:=2)
        clsImportFromCDSFunction.AddParameter("lon", clsRFunctionParameter:=clsConcLonFunction, iPosition:=5)
        clsImportFromCDSFunction.AddParameter("lat", clsRFunctionParameter:=clsConcLatFunction, iPosition:=6)
        clsImportFromCDSFunction.AddParameter("path", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\", "/"), iPosition:=7)
        clsImportFromCDSFunction.AddParameter("start_date", clsRFunctionParameter:=ucrDtpStartDate.ValueAsRDate, iPosition:=3)
        clsImportFromCDSFunction.AddParameter("end_date", clsRFunctionParameter:=ucrDtpEndDate.ValueAsRDate, iPosition:=4)

        clsConcLonFunction.SetRCommand("c")
        clsConcLonFunction.AddParameter("min_lon", 20, bIncludeArgumentName:=False, iPosition:=0)
        clsConcLonFunction.AddParameter("max_lon", 20.3, bIncludeArgumentName:=False, iPosition:=1)

        clsConcLatFunction.SetRCommand("c")
        clsConcLatFunction.AddParameter("min_lat", 50, bIncludeArgumentName:=False, iPosition:=0)
        clsConcLatFunction.AddParameter("max_lat", 50.3, bIncludeArgumentName:=False, iPosition:=1)

        ucrBase.clsRsyntax.ClearCodes()
        ucrBase.clsRsyntax.AddToBeforeCodes(clsWfsetkeyFunction)
        ucrBase.clsRsyntax.SetBaseRFunction(clsImportFromCDSFunction)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrInputData.SetRCode(clsImportFromCDSFunction, bReset)
        ucrInputElement.SetRCode(clsImportFromCDSFunction, bReset)
        ucrDtpStartDate.SetRCode(clsImportFromCDSFunction, bReset)
        ucrDtpEndDate.SetRCode(clsImportFromCDSFunction, bReset)
        ucrInputNewDataFrameName.SetRCode(clsImportFromCDSFunction, bReset)
        ucrChkDoNotImport.SetRCode(clsImportFromCDSFunction, bReset)
        ucrInputFilePath.SetRCode(clsImportFromCDSFunction, bReset)

        ucrInputAPIKey.SetRCode(clsWfsetkeyFunction, bReset)
        ucrInputUserID.SetRCode(clsWfsetkeyFunction, bReset)

        ucrInputMinLongitude.SetRCode(clsConcLonFunction, bReset)
        ucrInputMaxLongitude.SetRCode(clsConcLonFunction, bReset)

        ucrInputMinLatitude.SetRCode(clsConcLatFunction, bReset)
        ucrInputMaxLatitude.SetRCode(clsConcLatFunction, bReset)
        SetNewDataFrameName()
    End Sub

    Private Sub TestOkEnabled()
        If ucrInputUserID.IsEmpty OrElse ucrInputAPIKey.IsEmpty OrElse ucrInputMinLongitude.IsEmpty OrElse ucrInputMaxLongitude.IsEmpty OrElse ucrInputMinLatitude.IsEmpty OrElse ucrInputMaxLatitude.IsEmpty OrElse ucrInputFilePath.IsEmpty OrElse ucrInputNewDataFrameName.IsEmpty Then
            ucrBase.OKEnabled(False)
        Else
            ucrBase.OKEnabled(True)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOkEnabled()
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Dim strPath As String

        Using dlgFolder As New FolderBrowserDialog
            dlgFolder.Description = "Choose Folder"
            If dlgFolder.ShowDialog() = DialogResult.OK Then
                ucrInputFilePath.SetName("")
                strPath = dlgFolder.SelectedPath
                ucrInputFilePath.SetName(Replace(strPath, "\", "/"))
            End If
        End Using
    End Sub

    Private Sub lnkCreateAnAccount_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCreateAnAccount.LinkClicked
        Process.Start("https://cds.climate.copernicus.eu/user/login")
    End Sub

    Private Sub SetNewDataFrameName()
        If Not ucrInputData.IsEmpty Then
            ucrInputNewDataFrameName.SetName(ucrInputData.GetText.ToLower)
        End If
    End Sub

    Private Sub ucrInputData_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputData.ControlValueChanged
        SetNewDataFrameName()
    End Sub

    Private Sub AllControls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrInputUserID.ControlContentsChanged, ucrInputAPIKey.ControlContentsChanged, ucrInputMinLongitude.ControlContentsChanged, ucrInputMaxLongitude.ControlContentsChanged, ucrInputMinLatitude.ControlContentsChanged, ucrInputMaxLatitude.ControlContentsChanged, ucrInputNewDataFrameName.ControlContentsChanged, ucrInputFilePath.ControlContentsChanged
        TestOkEnabled()
    End Sub
End Class