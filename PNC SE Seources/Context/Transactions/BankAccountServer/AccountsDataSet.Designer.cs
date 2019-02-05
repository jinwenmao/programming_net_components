﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50215.44
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankAccountServer {
    using System;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [System.Xml.Serialization.XmlRootAttribute("AccountsDataSet")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly")]
    public partial class AccountsDataSet : System.Data.DataSet {
        
        private BankAccountsDataTable tableBankAccounts;
        
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountsDataSet() {
            this.BeginInit();
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected AccountsDataSet(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["BankAccounts"] != null)) {
                    base.Tables.Add(new BankAccountsDataTable(ds.Tables["BankAccounts"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public BankAccountsDataTable BankAccounts {
            get {
                return this.tableBankAccounts;
            }
        }
        
        public override System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [System.ComponentModel.DefaultValueAttribute(true)]
        public new bool EnforceConstraints {
            get {
                return base.EnforceConstraints;
            }
            set {
                base.EnforceConstraints = value;
            }
        }
        
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        public override System.Data.DataSet Clone() {
            AccountsDataSet cln = ((AccountsDataSet)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["BankAccounts"] != null)) {
                    base.Tables.Add(new BankAccountsDataTable(ds.Tables["BankAccounts"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.InitVars(true);
        }
        
        internal void InitVars(bool initTable) {
            this.tableBankAccounts = ((BankAccountsDataTable)(base.Tables["BankAccounts"]));
            if ((initTable == true)) {
                if ((this.tableBankAccounts != null)) {
                    this.tableBankAccounts.InitVars();
                }
            }
        }
        
        private void InitClass() {
            this.DataSetName = "AccountsDataSet";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/AccountsDataSet.xsd";
            this.EnforceConstraints = true;
            this.tableBankAccounts = new BankAccountsDataTable();
            base.Tables.Add(this.tableBankAccounts);
        }
        
        private bool ShouldSerializeBankAccounts() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs) {
            AccountsDataSet ds = new AccountsDataSet();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            xs.Add(ds.GetSchemaSerializable());
            System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            return type;
        }
        
        public delegate void BankAccountsRowChangeEventHandler(object sender, BankAccountsRowChangeEvent e);
        
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class BankAccountsDataTable : System.Data.DataTable, System.Collections.IEnumerable {
            
            private System.Data.DataColumn columnNumber;
            
            private System.Data.DataColumn columnBalance;
            
            private System.Data.DataColumn columnName;
            
            public BankAccountsDataTable() {
                this.TableName = "BankAccounts";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            internal BankAccountsDataTable(System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            protected BankAccountsDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            public System.Data.DataColumn NumberColumn {
                get {
                    return this.columnNumber;
                }
            }
            
            public System.Data.DataColumn BalanceColumn {
                get {
                    return this.columnBalance;
                }
            }
            
            public System.Data.DataColumn NameColumn {
                get {
                    return this.columnName;
                }
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
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
            
            public BankAccountsRow AddBankAccountsRow(int Number, decimal Balance, string Name) {
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
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override System.Data.DataTable Clone() {
                BankAccountsDataTable cln = ((BankAccountsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override System.Data.DataTable CreateInstance() {
                return new BankAccountsDataTable();
            }
            
            internal void InitVars() {
                this.columnNumber = base.Columns["Number"];
                this.columnBalance = base.Columns["Balance"];
                this.columnName = base.Columns["Name"];
            }
            
            private void InitClass() {
                this.columnNumber = new System.Data.DataColumn("Number", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnNumber);
                this.columnBalance = new System.Data.DataColumn("Balance", typeof(decimal), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnBalance);
                this.columnName = new System.Data.DataColumn("Name", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnName);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] {
                                this.columnNumber}, true));
                this.columnNumber.AllowDBNull = false;
                this.columnNumber.Unique = true;
            }
            
            public BankAccountsRow NewBankAccountsRow() {
                return ((BankAccountsRow)(this.NewRow()));
            }
            
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
                return new BankAccountsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(BankAccountsRow);
            }
            
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.BankAccountsRowChanged != null)) {
                    this.BankAccountsRowChanged(this, new BankAccountsRowChangeEvent(((BankAccountsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.BankAccountsRowChanging != null)) {
                    this.BankAccountsRowChanging(this, new BankAccountsRowChangeEvent(((BankAccountsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.BankAccountsRowDeleted != null)) {
                    this.BankAccountsRowDeleted(this, new BankAccountsRowChangeEvent(((BankAccountsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.BankAccountsRowDeleting != null)) {
                    this.BankAccountsRowDeleting(this, new BankAccountsRowChangeEvent(((BankAccountsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveBankAccountsRow(BankAccountsRow row) {
                this.Rows.Remove(row);
            }
            
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs) {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                AccountsDataSet ds = new AccountsDataSet();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "BankAccountsDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }
        
        public partial class BankAccountsRow : System.Data.DataRow {
            
            private BankAccountsDataTable tableBankAccounts;
            
            internal BankAccountsRow(System.Data.DataRowBuilder rb) : 
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
            
            public decimal Balance {
                get {
                    try {
                        return ((decimal)(this[this.tableBankAccounts.BalanceColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'Balance\' in table \'BankAccounts\' is DBNull.", e);
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
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'Name\' in table \'BankAccounts\' is DBNull.", e);
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
        
        public class BankAccountsRowChangeEvent : System.EventArgs {
            
            private BankAccountsRow eventRow;
            
            private System.Data.DataRowAction eventAction;
            
            public BankAccountsRowChangeEvent(BankAccountsRow row, System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public BankAccountsRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
