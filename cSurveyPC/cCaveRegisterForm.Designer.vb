<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cCaveRegisterForm
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cCaveRegisterForm))
        Me.imlFile = New System.Windows.Forms.ImageList(Me.components)
        Me.tbTabs = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tbTabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'imlFile
        '
        Me.imlFile.ImageStream = CType(resources.GetObject("imlFile.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlFile.TransparentColor = System.Drawing.Color.Transparent
        Me.imlFile.Images.SetKeyName(0, "file_extension_3gp.png")
        Me.imlFile.Images.SetKeyName(1, "file_extension_7z.png")
        Me.imlFile.Images.SetKeyName(2, "file_extension_ace.png")
        Me.imlFile.Images.SetKeyName(3, "file_extension_ai.png")
        Me.imlFile.Images.SetKeyName(4, "file_extension_aif.png")
        Me.imlFile.Images.SetKeyName(5, "file_extension_aiff.png")
        Me.imlFile.Images.SetKeyName(6, "file_extension_amr.png")
        Me.imlFile.Images.SetKeyName(7, "file_extension_asf.png")
        Me.imlFile.Images.SetKeyName(8, "file_extension_asx.png")
        Me.imlFile.Images.SetKeyName(9, "file_extension_bat.png")
        Me.imlFile.Images.SetKeyName(10, "file_extension_bin.png")
        Me.imlFile.Images.SetKeyName(11, "file_extension_bmp.png")
        Me.imlFile.Images.SetKeyName(12, "file_extension_bup.png")
        Me.imlFile.Images.SetKeyName(13, "file_extension_cab.png")
        Me.imlFile.Images.SetKeyName(14, "file_extension_cbr.png")
        Me.imlFile.Images.SetKeyName(15, "file_extension_cda.png")
        Me.imlFile.Images.SetKeyName(16, "file_extension_cdl.png")
        Me.imlFile.Images.SetKeyName(17, "file_extension_cdr.png")
        Me.imlFile.Images.SetKeyName(18, "file_extension_chm.png")
        Me.imlFile.Images.SetKeyName(19, "file_extension_dat.png")
        Me.imlFile.Images.SetKeyName(20, "file_extension_divx.png")
        Me.imlFile.Images.SetKeyName(21, "file_extension_dll.png")
        Me.imlFile.Images.SetKeyName(22, "file_extension_dmg.png")
        Me.imlFile.Images.SetKeyName(23, "file_extension_doc.png")
        Me.imlFile.Images.SetKeyName(24, "file_extension_dss.png")
        Me.imlFile.Images.SetKeyName(25, "file_extension_dvf.png")
        Me.imlFile.Images.SetKeyName(26, "file_extension_dwg.png")
        Me.imlFile.Images.SetKeyName(27, "file_extension_eml.png")
        Me.imlFile.Images.SetKeyName(28, "file_extension_eps.png")
        Me.imlFile.Images.SetKeyName(29, "file_extension_exe.png")
        Me.imlFile.Images.SetKeyName(30, "file_extension_fla.png")
        Me.imlFile.Images.SetKeyName(31, "file_extension_flv.png")
        Me.imlFile.Images.SetKeyName(32, "file_extension_gif.png")
        Me.imlFile.Images.SetKeyName(33, "file_extension_gz.png")
        Me.imlFile.Images.SetKeyName(34, "file_extension_hqx.png")
        Me.imlFile.Images.SetKeyName(35, "file_extension_htm.png")
        Me.imlFile.Images.SetKeyName(36, "file_extension_html.png")
        Me.imlFile.Images.SetKeyName(37, "file_extension_ifo.png")
        Me.imlFile.Images.SetKeyName(38, "file_extension_indd.png")
        Me.imlFile.Images.SetKeyName(39, "file_extension_iso.png")
        Me.imlFile.Images.SetKeyName(40, "file_extension_jar.png")
        Me.imlFile.Images.SetKeyName(41, "file_extension_jpeg.png")
        Me.imlFile.Images.SetKeyName(42, "file_extension_jpg.png")
        Me.imlFile.Images.SetKeyName(43, "file_extension_lnk.png")
        Me.imlFile.Images.SetKeyName(44, "file_extension_log.png")
        Me.imlFile.Images.SetKeyName(45, "file_extension_m4a.png")
        Me.imlFile.Images.SetKeyName(46, "file_extension_m4b.png")
        Me.imlFile.Images.SetKeyName(47, "file_extension_m4p.png")
        Me.imlFile.Images.SetKeyName(48, "file_extension_m4v.png")
        Me.imlFile.Images.SetKeyName(49, "file_extension_mcd.png")
        Me.imlFile.Images.SetKeyName(50, "file_extension_mdb.png")
        Me.imlFile.Images.SetKeyName(51, "file_extension_mid.png")
        Me.imlFile.Images.SetKeyName(52, "file_extension_mov.png")
        Me.imlFile.Images.SetKeyName(53, "file_extension_mp2.png")
        Me.imlFile.Images.SetKeyName(54, "file_extension_mp4.png")
        Me.imlFile.Images.SetKeyName(55, "file_extension_mpeg.png")
        Me.imlFile.Images.SetKeyName(56, "file_extension_mpg.png")
        Me.imlFile.Images.SetKeyName(57, "file_extension_msi.png")
        Me.imlFile.Images.SetKeyName(58, "file_extension_mswmm.png")
        Me.imlFile.Images.SetKeyName(59, "file_extension_ogg.png")
        Me.imlFile.Images.SetKeyName(60, "file_extension_pdf.png")
        Me.imlFile.Images.SetKeyName(61, "file_extension_png.png")
        Me.imlFile.Images.SetKeyName(62, "file_extension_pps.png")
        Me.imlFile.Images.SetKeyName(63, "file_extension_ps.png")
        Me.imlFile.Images.SetKeyName(64, "file_extension_psd.png")
        Me.imlFile.Images.SetKeyName(65, "file_extension_pst.png")
        Me.imlFile.Images.SetKeyName(66, "file_extension_ptb.png")
        Me.imlFile.Images.SetKeyName(67, "file_extension_pub.png")
        Me.imlFile.Images.SetKeyName(68, "file_extension_qbb.png")
        Me.imlFile.Images.SetKeyName(69, "file_extension_qbw.png")
        Me.imlFile.Images.SetKeyName(70, "file_extension_qxd.png")
        Me.imlFile.Images.SetKeyName(71, "file_extension_ram.png")
        Me.imlFile.Images.SetKeyName(72, "file_extension_rar.png")
        Me.imlFile.Images.SetKeyName(73, "file_extension_rm.png")
        Me.imlFile.Images.SetKeyName(74, "file_extension_rmvb.png")
        Me.imlFile.Images.SetKeyName(75, "file_extension_rtf.png")
        Me.imlFile.Images.SetKeyName(76, "file_extension_sea.png")
        Me.imlFile.Images.SetKeyName(77, "file_extension_ses.png")
        Me.imlFile.Images.SetKeyName(78, "file_extension_sit.png")
        Me.imlFile.Images.SetKeyName(79, "file_extension_sitx.png")
        Me.imlFile.Images.SetKeyName(80, "file_extension_ss.png")
        Me.imlFile.Images.SetKeyName(81, "file_extension_swf.png")
        Me.imlFile.Images.SetKeyName(82, "file_extension_tgz.png")
        Me.imlFile.Images.SetKeyName(83, "file_extension_thm.png")
        Me.imlFile.Images.SetKeyName(84, "file_extension_tif.png")
        Me.imlFile.Images.SetKeyName(85, "file_extension_tmp.png")
        Me.imlFile.Images.SetKeyName(86, "file_extension_torrent.png")
        Me.imlFile.Images.SetKeyName(87, "file_extension_ttf.png")
        Me.imlFile.Images.SetKeyName(88, "file_extension_txt.png")
        Me.imlFile.Images.SetKeyName(89, "file_extension_vcd.png")
        Me.imlFile.Images.SetKeyName(90, "file_extension_vob.png")
        Me.imlFile.Images.SetKeyName(91, "file_extension_wav.png")
        Me.imlFile.Images.SetKeyName(92, "file_extension_wma.png")
        Me.imlFile.Images.SetKeyName(93, "file_extension_wmv.png")
        Me.imlFile.Images.SetKeyName(94, "file_extension_wps.png")
        Me.imlFile.Images.SetKeyName(95, "file_extension_xls.png")
        Me.imlFile.Images.SetKeyName(96, "file_extension_xpi.png")
        Me.imlFile.Images.SetKeyName(97, "file_extension_zip.png")
        Me.imlFile.Images.SetKeyName(98, "page_white.png")
        '
        'tbTabs
        '
        Me.tbTabs.Controls.Add(Me.TabPage1)
        Me.tbTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbTabs.Location = New System.Drawing.Point(0, 0)
        Me.tbTabs.Name = "tbTabs"
        Me.tbTabs.SelectedIndex = 0
        Me.tbTabs.Size = New System.Drawing.Size(684, 278)
        Me.tbTabs.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(676, 252)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cCaveRegisterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tbTabs)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "cCaveRegisterForm"
        Me.Size = New System.Drawing.Size(684, 278)
        Me.tbTabs.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imlFile As System.Windows.Forms.ImageList
    Friend WithEvents tbTabs As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage

End Class
