﻿// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.2914.16
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Xml;
using System.Runtime.Serialization;


[Serializable()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public class AccountsDataSet : System.Data.DataSet 
{
    
    private BankAccountsDataTable tableBankAccounts;
    
    public AccountsDataSet() {
        this.InitClass();
    }
    
    private AccountsDataSet(SerializationInfo info, StreamingContext context) {
        this.InitClass();
        this.GetSerializationData(info, context);
    }
    
    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
    public BankAccountsDataTable BankAccounts {
        get {
            return this.tableBankAccounts;
        }
    }
    
    protected override bool ShouldSerializeTables() {
        return false;
    }
    
    protected override bool ShouldSerializeRelations() {
        return false;
    }
    
    protected override void ReadXmlSerializable(XmlReader reader) {
        this.ReadXml(reader, XmlReadMode.IgnoreSchema);
    }
    
    protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        this.WriteXmlSchema(new XmlTextWriter(stream, null));
        stream.Position = 0;
        return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
    }
    
    private void InitClass() {
        this.DataSetName = "AccountsDataSet";
        this.Namespace = "http://www.tempuri.org/AccountsDataSet.xsd";
        this.tableBankAccounts = new BankAccountsDataTable();
        this.Tables.Add(this.tableBankAccounts);
    }
    
    private bool ShouldSerializeBankAccounts() {
        return false;
    }
    
    public delegate void BankAccountsRowChangeEventHandler(object sender, BankAccountsRowChangeEvent e);
    
    public class BankAccountsDataTable : DataTable, System.Collections.IEnumerable {
        
        private DataColumn columnNumber;
        
        private DataColumn columnBalance;
        
        private DataColumn columnName;
        
        internal BankAccountsDataTable() : 
                base("BankAccounts") {
            this.InitClass();
        }
        
        [System.ComponentModel.Browsable(false)]
        public int Count {
            get {
                return this.Rows.Count;
            }
        }
        
        internal DataColumn NumberColumn {
            get {
                return this.columnNumber;
            }
        }
        
        internal DataColumn BalanceColumn {
            get {
                return this.columnBalance;
            }
        }
        
        internal DataColumn NameColumn {
            get {
                return this.columnName;
            }
        }
        
        public BankAccountsRow this[int index] {
            get {
                return ((BankAccountsRow)(this.Rows[index]));
            }
        }
        
        public event BankAccountsRowChangeEventHandler BankAccountsRowChanged;
        
        public event BankAccountsRowChangeEventHandler BankAccountsRowChanging;
        
        public event BankAccountsRowChangeEventHandler BankAccountsRowDeleted;
        
        public event BankAccountsRowChangeEventHandler BankAccountsRowDeleting;
        
        public void AddBankAccountsRow(BankAccountsRow row) {
            this.Rows.Add(row);
        }
        
        public BankAccountsRow AddBankAccountsRow(int Number, System.Decimal Balance, string Name) {
            BankAccountsRow rowBankAccountsRow = ((BankAccountsRow)(this.NewRow()));
            rowBankAccountsRow.ItemArray = new object[] {
                    Number,
                    Balance,
                    Name};
            this.Rows.Add(rowBankAccountsRow);
            return rowBankAccountsRow;
        }
        
        public BankAccountsRow FindByNumber(int Number) {
            return ((BankAccountsRow)(this.Rows.Find(new object[] {
                        Number})));
        }
        
        public System.Collections.IEnumerator GetEnumerator() {
            return this.Rows.GetEnumerator();
        }
        
        private void InitClass() {
            this.columnNumber = new DataColumn("Number", typeof(int), "", System.Data.MappingType.Element);
            this.columnNumber.AllowDBNull = false;
            this.columnNumber.Unique = true;
            this.Columns.Add(this.columnNumber);
            this.columnBalance = new DataColumn("Balance", typeof(System.Decimal), "", System.Data.MappingType.Element);
            this.Columns.Add(this.columnBalance);
            this.columnName = new DataColumn("Name", typeof(string), "", System.Data.MappingType.Element);
            this.Columns.Add(this.columnName);
            this.PrimaryKey = new DataColumn[] {
                    this.columnNumber};
        }
        
        public BankAccountsRow NewBankAccountsRow() {
            return ((BankAccountsRow)(this.NewRow()));
        }
        
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
            // We need to ensure that all Rows in the tabled are typed rows.
            // Table calls newRow whenever it needs to create a account.
            // So the following conditions are covered by Row newRow(Record record)
            // * Cursor calls accounts.addRecord(record) 
            // * accounts.addRow(object[] values) calls newRow(record)    
            return new BankAccountsRow(builder);
        }
        
        protected override System.Type GetRowType() {
            return typeof(BankAccountsRow);
        }
        
        protected override void OnRowChanged(DataRowChangeEventArgs e) {
            base.OnRowChanged(e);
            if ((this.BankAccountsRowChanged != null)) {
                this.BankAccountsRowChanged(this, new BankAccountsRowChangeEvent(((BankAccountsRow)(e.Row)), e.Action));
            }
        }
        
        protected override void OnRowChanging(DataRowChangeEventArgs e) {
            base.OnRowChanging(e);
            if ((this.BankAccountsRowChanging != null)) {
                this.BankAccountsRowChanging(this, new BankAccountsRowChangeEvent(((BankAccountsRow)(e.Row)), e.Action));
            }
        }
        
        protected override void OnRowDeleted(DataRowChangeEventArgs e) {
            base.OnRowDeleted(e);
            if ((this.BankAccountsRowDeleted != null)) {
                this.BankAccountsRowDeleted(this, new BankAccountsRowChangeEvent(((BankAccountsRow)(e.Row)), e.Action));
            }
        }
        
        protected override void OnRowDeleting(DataRowChangeEventArgs e) {
            base.OnRowDeleting(e);
            if ((this.BankAccountsRowDeleting != null)) {
                this.BankAccountsRowDeleting(this, new BankAccountsRowChangeEvent(((BankAccountsRow)(e.Row)), e.Action));
            }
        }
        
        public void RemoveBankAccountsRow(BankAccountsRow row) {
            this.Rows.Remove(row);
        }
    }
    
    public class BankAccountsRow : DataRow {
        
        private BankAccountsDataTable tableBankAccounts;
        
        internal BankAccountsRow(DataRowBuilder rb) : 
                base(rb) {
            this.tableBankAccounts = ((BankAccountsDataTable)(this.Table));
        }
        
        public int Number {
            get {
                return ((int)(this[this.tableBankAccounts.NumberColumn]));
            }
            set {
                this[this.tableBankAccounts.NumberColumn] = value;
            }
        }
        
        public System.Decimal Balance {
            get {
                try {
                    return ((System.Decimal)(this[this.tableBankAccounts.BalanceColumn]));
                }
                catch (InvalidCastException e) {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set {
                this[this.tableBankAccounts.BalanceColumn] = value;
            }
        }
        
        public string Name {
            get {
                try {
                    return ((string)(this[this.tableBankAccounts.NameColumn]));
                }
                catch (InvalidCastException e) {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set {
                this[this.tableBankAccounts.NameColumn] = value;
            }
        }
        
        public bool IsBalanceNull() {
            return this.IsNull(this.tableBankAccounts.BalanceColumn);
        }
        
        public void SetBalanceNull() {
            this[this.tableBankAccounts.BalanceColumn] = System.Convert.DBNull;
        }
        
        public bool IsNameNull() {
            return this.IsNull(this.tableBankAccounts.NameColumn);
        }
        
        public void SetNameNull() {
            this[this.tableBankAccounts.NameColumn] = System.Convert.DBNull;
        }
    }
    
    public class BankAccountsRowChangeEvent : EventArgs {
        
        private BankAccountsRow eventRow;
        
        private System.Data.DataRowAction eventAction;
        
        public BankAccountsRowChangeEvent(BankAccountsRow row, DataRowAction action) {
            this.eventRow = row;
            this.eventAction = action;
        }
        
        public BankAccountsRow Row {
            get {
                return this.eventRow;
            }
        }
        
        public DataRowAction Action {
            get {
                return this.eventAction;
            }
        }
    }
}
