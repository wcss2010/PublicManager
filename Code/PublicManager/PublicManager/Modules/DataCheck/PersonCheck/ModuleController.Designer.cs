﻿namespace PublicManager.Modules.DataCheck.PersonCheck
{
    partial class ModuleController
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.srpSearch = new PublicManager.Modules.SearchRulePanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcData);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1423, 751);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // gcData
            // 
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.Location = new System.Drawing.Point(3, 106);
            this.gcData.MainView = this.dgvDetail;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(1417, 642);
            this.gcData.TabIndex = 3;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetail});
            // 
            // dgvDetail
            // 
            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.dgvDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.dgvDetail.GridControl = this.gcData;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgvDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.dgvDetail.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.dgvDetail_RowCellStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "版本";
            this.gridColumn1.FieldName = "row1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "类型";
            this.gridColumn2.FieldName = "row2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "项目名称";
            this.gridColumn3.FieldName = "row3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 379;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "课题名称";
            this.gridColumn4.FieldName = "row4";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 295;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "姓名";
            this.gridColumn5.FieldName = "row5";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 47;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "身份证";
            this.gridColumn6.FieldName = "row6";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 169;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "性别";
            this.gridColumn7.FieldName = "row7";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 46;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "工作单位";
            this.gridColumn8.FieldName = "row8";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "职务/职称";
            this.gridColumn9.FieldName = "row9";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 66;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "专业";
            this.gridColumn10.FieldName = "row10";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 67;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "每年投入时间";
            this.gridColumn11.FieldName = "row11";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 7;
            this.gridColumn11.Width = 87;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "任务分工";
            this.gridColumn12.FieldName = "row12";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            this.gridColumn12.Width = 171;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "项目中职务";
            this.gridColumn13.FieldName = "row13";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 8;
            this.gridColumn13.Width = 72;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.srpSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1417, 88);
            this.panel1.TabIndex = 2;
            // 
            // srpSearch
            // 
            this.srpSearch.CustomButtonsNames = "结果内容搜索;列选择器";
            this.srpSearch.DisplayGridControl = this.gcData;
            this.srpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.srpSearch.IsDisplayCatalogTypePanel = true;
            this.srpSearch.IsDisplayCheckListPanel = true;
            this.srpSearch.IsDisplayContractData = false;
            this.srpSearch.IsDisplayCustomButtonPanel = true;
            this.srpSearch.IsDisplayKey1Panel = true;
            this.srpSearch.IsDisplayKey2Panel = false;
            this.srpSearch.IsDisplayKey3OR4Panel = false;
            this.srpSearch.IsDisplayKey3Panel = false;
            this.srpSearch.IsDisplayKey4Panel = false;
            this.srpSearch.IsDisplayReporterData = true;
            this.srpSearch.IsHightlightHintWithSearchAfter = false;
            this.srpSearch.Key1FieldString = "项目名称;课题名称;人员名称;人员专业;人员任务分工";
            this.srpSearch.Key1PanelWidth = 1419;
            this.srpSearch.Key2PanelWidth = 187;
            this.srpSearch.Key3OR4PanelWidth = 638;
            this.srpSearch.Key3PanelWidth = 310;
            this.srpSearch.Key4PanelWidth = 316;
            this.srpSearch.Location = new System.Drawing.Point(0, 0);
            this.srpSearch.Name = "srpSearch";
            this.srpSearch.RightButtonPanelWidth = 360;
            this.srpSearch.Size = new System.Drawing.Size(1417, 88);
            this.srpSearch.TabIndex = 8;
            this.srpSearch.OnSearchClick += new PublicManager.Modules.SearchClickDelegate(this.srpSearch_OnSearchClick);
            this.srpSearch.OnResetClick += new PublicManager.Modules.ResetClickDelegate(this.srpSearch_OnResetClick);
            this.srpSearch.OnExportToClick += new PublicManager.Modules.ExportToClickDelegate(this.srpSearch_OnExportToClick);
            this.srpSearch.OnCustomButtonClick += new PublicManager.Modules.CustomButtonClickDelegate(this.srpSearch_OnCustomButtonClick);
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1423, 751);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private SearchRulePanel srpSearch;
    }
}
