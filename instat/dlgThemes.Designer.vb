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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgThemes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgThemes))
        Me.lblThemetoEdit = New System.Windows.Forms.Label()
        Me.cmdThemeOptions = New System.Windows.Forms.Button()
        Me.ucrChkDeleteTheme = New instat.ucrCheck()
        Me.ucrSaveTheme = New instat.ucrSave()
        Me.ucrreceiverThemetoEdit = New instat.ucrReceiverSingle()
        Me.ucrSelectorThemes = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrBase = New instat.ucrButtons()
        Me.SuspendLayout()
        '
        'lblThemetoEdit
        '
        resources.ApplyResources(Me.lblThemetoEdit, "lblThemetoEdit")
        Me.lblThemetoEdit.Name = "lblThemetoEdit"
        '
        'cmdThemeOptions
        '
        resources.ApplyResources(Me.cmdThemeOptions, "cmdThemeOptions")
        Me.cmdThemeOptions.Name = "cmdThemeOptions"
        Me.cmdThemeOptions.UseVisualStyleBackColor = True
        '
        'ucrChkDeleteTheme
        '
        Me.ucrChkDeleteTheme.Checked = False
        resources.ApplyResources(Me.ucrChkDeleteTheme, "ucrChkDeleteTheme")
        Me.ucrChkDeleteTheme.Name = "ucrChkDeleteTheme"
        '
        'ucrSaveTheme
        '
        resources.ApplyResources(Me.ucrSaveTheme, "ucrSaveTheme")
        Me.ucrSaveTheme.Name = "ucrSaveTheme"
        '
        'ucrreceiverThemetoEdit
        '
        Me.ucrreceiverThemetoEdit.frmParent = Me
        resources.ApplyResources(Me.ucrreceiverThemetoEdit, "ucrreceiverThemetoEdit")
        Me.ucrreceiverThemetoEdit.Name = "ucrreceiverThemetoEdit"
        Me.ucrreceiverThemetoEdit.Selector = Nothing
        Me.ucrreceiverThemetoEdit.strNcFilePath = ""
        Me.ucrreceiverThemetoEdit.ucrSelector = Nothing
        '
        'ucrSelectorThemes
        '
        Me.ucrSelectorThemes.bShowHiddenColumns = False
        Me.ucrSelectorThemes.bUseCurrentFilter = True
        resources.ApplyResources(Me.ucrSelectorThemes, "ucrSelectorThemes")
        Me.ucrSelectorThemes.Name = "ucrSelectorThemes"
        '
        'ucrBase
        '
        resources.ApplyResources(Me.ucrBase, "ucrBase")
        Me.ucrBase.Name = "ucrBase"
        '
        'dlgThemes
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrChkDeleteTheme)
        Me.Controls.Add(Me.ucrSaveTheme)
        Me.Controls.Add(Me.cmdThemeOptions)
        Me.Controls.Add(Me.lblThemetoEdit)
        Me.Controls.Add(Me.ucrreceiverThemetoEdit)
        Me.Controls.Add(Me.ucrSelectorThemes)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgThemes"
        Me.Tag = "Themes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrSelectorThemes As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrreceiverThemetoEdit As ucrReceiverSingle
    Friend WithEvents cmdThemeOptions As Button
    Friend WithEvents lblThemetoEdit As Label
    Friend WithEvents ucrSaveTheme As ucrSave
    Friend WithEvents ucrChkDeleteTheme As ucrCheck
End Class
