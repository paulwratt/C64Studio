﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C64Studio
{
  public partial class FormMacros : Form
  {
    private DocumentInfo      m_Doc = null;
    private TextBox           m_Edit = null;
    private StudioCore        Core = null;



    public FormMacros( StudioCore Core, DocumentInfo Doc, TextBox EditToInsert )
    {
      InitializeComponent();

      m_Doc = Doc;
      m_Edit = EditToInsert;
      this.Core = Core;

      InsertMacro( "$(Filename)" );
      InsertMacro( "$(FilenameWithoutExtension)" );
      InsertMacro( "$(FilePath)" );
      InsertMacro( "$(BuildTargetPath)" );
      InsertMacro( "$(BuildTargetFilename)" );
      InsertMacro( "$(BuildTargetFilenameWithoutExtension)" );
      InsertMacro( "$(RunPath)" );
      InsertMacro( "$(RunFilename)" );
      InsertMacro( "$(RunFilenameWithoutExtension)" );
      InsertMacro( "$(DebugStartAddress)" );
      InsertMacro( "$(DebugStartAddressHex)" );

      InsertMacro( "$(ConfigName)" );
      InsertMacro( "$(ProjectPath)" );
      InsertMacro( "$(MediaManager)" );
      InsertMacro( "$(MediaTool)" );
    }



    public FormMacros( StudioCore Core, DocumentInfo Doc, TextBox EditToInsert, bool ShowRunCommands )
    {
      InitializeComponent();

      m_Doc = Doc;
      m_Edit = EditToInsert;
      this.Core = Core;

      InsertMacro( "$(Filename)" );
      InsertMacro( "$(FilenameWithoutExtension)" );
      InsertMacro( "$(FilePath)" );
      InsertMacro( "$(BuildTargetPath)" );
      InsertMacro( "$(BuildTargetFilename)" );
      InsertMacro( "$(BuildTargetFilenameWithoutExtension)" );
      if ( ShowRunCommands )
      {
        InsertMacro( "$(RunPath)" );
        InsertMacro( "$(RunFilename)" );
        InsertMacro( "$(RunFilenameWithoutExtension)" );
      }
      InsertMacro( "$(DebugStartAddress)" );
      InsertMacro( "$(DebugStartAddressHex)" );

      InsertMacro( "$(ConfigName)" );
      InsertMacro( "$(ProjectPath)" );
      InsertMacro( "$(MediaManager)" );
      InsertMacro( "$(MediaTool)" );
    }



    private void InsertMacro( string Macro )
    {
      bool    error = false;

      ListViewItem    item = new ListViewItem( Macro );
      item.SubItems.Add( Core.MainForm.FillParameters( Macro, m_Doc, false, out error ) );

      listMacros.Items.Add( item );
    }



    private void listMacros_ItemActivate( object sender, EventArgs e )
    {
      if ( listMacros.SelectedIndices.Count == 0 )
      {
        return;
      }
      m_Edit.Text = m_Edit.Text.Insert( m_Edit.SelectionStart, listMacros.SelectedItems[0].SubItems[0].Text );
    }



    private void btnInsert_Click( object sender, EventArgs e )
    {
      if ( listMacros.SelectedIndices.Count == 0 )
      {
        return;
      }
      m_Edit.Text = m_Edit.Text.Insert( m_Edit.SelectionStart, listMacros.SelectedItems[0].SubItems[0].Text );
    }



    private void btnOK_Click( object sender, EventArgs e )
    {
      Close();
    }


  }
}
