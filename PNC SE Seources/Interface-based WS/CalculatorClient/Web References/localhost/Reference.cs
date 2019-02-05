﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50215.44
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50215.44.
// 
namespace WSInterfacesDemo.localhost {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ICalculator", Namespace="http://CalculationServices.com")]
    public partial class SimpleCalculator : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AddOperationCompleted;
        
        private System.Threading.SendOrPostCallback SubtractOperationCompleted;
        
        private System.Threading.SendOrPostCallback DivideOperationCompleted;
        
        private System.Threading.SendOrPostCallback MultiplyOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SimpleCalculator() {
            this.Url = WSInterfacesDemo.Properties.Settings.Default.CalculatorClient_localhost_SimpleCalculator;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AddCompletedEventHandler AddCompleted;
        
        /// <remarks/>
        public event SubtractCompletedEventHandler SubtractCompleted;
        
        /// <remarks/>
        public event DivideCompletedEventHandler DivideCompleted;
        
        /// <remarks/>
        public event MultiplyCompletedEventHandler MultiplyCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://CalculationServices.com/Add", RequestNamespace="http://CalculationServices.com", ResponseNamespace="http://CalculationServices.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Add(int num1, int num2) {
            object[] results = this.Invoke("Add", new object[] {
                        num1,
                        num2});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAdd(int num1, int num2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Add", new object[] {
                        num1,
                        num2}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndAdd(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void AddAsync(int num1, int num2) {
            this.AddAsync(num1, num2, null);
        }
        
        /// <remarks/>
        public void AddAsync(int num1, int num2, object userState) {
            if ((this.AddOperationCompleted == null)) {
                this.AddOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddOperationCompleted);
            }
            this.InvokeAsync("Add", new object[] {
                        num1,
                        num2}, this.AddOperationCompleted, userState);
        }
        
        private void OnAddOperationCompleted(object arg) {
            if ((this.AddCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddCompleted(this, new AddCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://CalculationServices.com/Subtract", RequestNamespace="http://CalculationServices.com", ResponseNamespace="http://CalculationServices.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Subtract(int num1, int num2) {
            object[] results = this.Invoke("Subtract", new object[] {
                        num1,
                        num2});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSubtract(int num1, int num2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Subtract", new object[] {
                        num1,
                        num2}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndSubtract(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SubtractAsync(int num1, int num2) {
            this.SubtractAsync(num1, num2, null);
        }
        
        /// <remarks/>
        public void SubtractAsync(int num1, int num2, object userState) {
            if ((this.SubtractOperationCompleted == null)) {
                this.SubtractOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSubtractOperationCompleted);
            }
            this.InvokeAsync("Subtract", new object[] {
                        num1,
                        num2}, this.SubtractOperationCompleted, userState);
        }
        
        private void OnSubtractOperationCompleted(object arg) {
            if ((this.SubtractCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SubtractCompleted(this, new SubtractCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://CalculationServices.com/Divide", RequestNamespace="http://CalculationServices.com", ResponseNamespace="http://CalculationServices.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Divide(int num1, int num2) {
            object[] results = this.Invoke("Divide", new object[] {
                        num1,
                        num2});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDivide(int num1, int num2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Divide", new object[] {
                        num1,
                        num2}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndDivide(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void DivideAsync(int num1, int num2) {
            this.DivideAsync(num1, num2, null);
        }
        
        /// <remarks/>
        public void DivideAsync(int num1, int num2, object userState) {
            if ((this.DivideOperationCompleted == null)) {
                this.DivideOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDivideOperationCompleted);
            }
            this.InvokeAsync("Divide", new object[] {
                        num1,
                        num2}, this.DivideOperationCompleted, userState);
        }
        
        private void OnDivideOperationCompleted(object arg) {
            if ((this.DivideCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DivideCompleted(this, new DivideCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://CalculationServices.com/Multiply", RequestNamespace="http://CalculationServices.com", ResponseNamespace="http://CalculationServices.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Multiply(int num1, int num2) {
            object[] results = this.Invoke("Multiply", new object[] {
                        num1,
                        num2});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginMultiply(int num1, int num2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Multiply", new object[] {
                        num1,
                        num2}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndMultiply(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void MultiplyAsync(int num1, int num2) {
            this.MultiplyAsync(num1, num2, null);
        }
        
        /// <remarks/>
        public void MultiplyAsync(int num1, int num2, object userState) {
            if ((this.MultiplyOperationCompleted == null)) {
                this.MultiplyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMultiplyOperationCompleted);
            }
            this.InvokeAsync("Multiply", new object[] {
                        num1,
                        num2}, this.MultiplyOperationCompleted, userState);
        }
        
        private void OnMultiplyOperationCompleted(object arg) {
            if ((this.MultiplyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MultiplyCompleted(this, new MultiplyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if ((((wsUri.Port >= 1024) 
                        && (wsUri.Port <= 5000)) 
                        && (string.Compare(wsUri.Host, "localHost", true) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    public delegate void AddCompletedEventHandler(object sender, AddCompletedEventArgs e);
    
    /// <remarks/>
    public partial class AddCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    public delegate void SubtractCompletedEventHandler(object sender, SubtractCompletedEventArgs e);
    
    /// <remarks/>
    public partial class SubtractCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SubtractCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    public delegate void DivideCompletedEventHandler(object sender, DivideCompletedEventArgs e);
    
    /// <remarks/>
    public partial class DivideCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DivideCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    public delegate void MultiplyCompletedEventHandler(object sender, MultiplyCompletedEventArgs e);
    
    /// <remarks/>
    public partial class MultiplyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MultiplyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}