﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// 이 소스 코드가 Microsoft.VSDesigner, 버전 1.1.4322.573에서 자동으로 생성되었습니다.
// 
namespace COM.CSI_WebService {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/CSI_WebService/Service1")]
    public class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service1() {
            this.Url = "http://localhost/CSI_WebService/CSI_WebService.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CSI_WebService/Service1/HelloWorld", RequestNamespace="http://tempuri.org/CSI_WebService/Service1", ResponseNamespace="http://tempuri.org/CSI_WebService/Service1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginHelloWorld(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("HelloWorld", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndHelloWorld(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CSI_WebService/Service1/Oracle_Select_Procedure", RequestNamespace="http://tempuri.org/CSI_WebService/Service1", ResponseNamespace="http://tempuri.org/CSI_WebService/Service1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet Oracle_Select_Procedure(string Process_Name, string[] Parameter_Name, int[] Parameter_Type, string[] Parameter_Value) {
            object[] results = this.Invoke("Oracle_Select_Procedure", new object[] {
                        Process_Name,
                        Parameter_Name,
                        Parameter_Type,
                        Parameter_Value});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginOracle_Select_Procedure(string Process_Name, string[] Parameter_Name, int[] Parameter_Type, string[] Parameter_Value, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Oracle_Select_Procedure", new object[] {
                        Process_Name,
                        Parameter_Name,
                        Parameter_Type,
                        Parameter_Value}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataSet EndOracle_Select_Procedure(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CSI_WebService/Service1/Oracle_Run_Procedure", RequestNamespace="http://tempuri.org/CSI_WebService/Service1", ResponseNamespace="http://tempuri.org/CSI_WebService/Service1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object Oracle_Run_Procedure(string Process_Name, string[] Parameter_Name, int[] Parameter_Type, string[] Parameter_Value) {
            object[] results = this.Invoke("Oracle_Run_Procedure", new object[] {
                        Process_Name,
                        Parameter_Name,
                        Parameter_Type,
                        Parameter_Value});
            return ((object)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginOracle_Run_Procedure(string Process_Name, string[] Parameter_Name, int[] Parameter_Type, string[] Parameter_Value, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Oracle_Run_Procedure", new object[] {
                        Process_Name,
                        Parameter_Name,
                        Parameter_Type,
                        Parameter_Value}, callback, asyncState);
        }
        
        /// <remarks/>
        public object EndOracle_Run_Procedure(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CSI_WebService/Service1/Oracle_Run_Matrix_Procedure", RequestNamespace="http://tempuri.org/CSI_WebService/Service1", ResponseNamespace="http://tempuri.org/CSI_WebService/Service1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object Oracle_Run_Matrix_Procedure(string Process_Name, string[] Parameter_Name, int[] Parameter_Type, string[] Parameter_Matrix) {
            object[] results = this.Invoke("Oracle_Run_Matrix_Procedure", new object[] {
                        Process_Name,
                        Parameter_Name,
                        Parameter_Type,
                        Parameter_Matrix});
            return ((object)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginOracle_Run_Matrix_Procedure(string Process_Name, string[] Parameter_Name, int[] Parameter_Type, string[] Parameter_Matrix, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Oracle_Run_Matrix_Procedure", new object[] {
                        Process_Name,
                        Parameter_Name,
                        Parameter_Type,
                        Parameter_Matrix}, callback, asyncState);
        }
        
        /// <remarks/>
        public object EndOracle_Run_Matrix_Procedure(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CSI_WebService/Service1/Ora_Procedure2", RequestNamespace="http://tempuri.org/CSI_WebService/Service1", ResponseNamespace="http://tempuri.org/CSI_WebService/Service1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object Ora_Procedure2(string UpdUser, string Proc_Name, string[] Para_Name, string[] Para_Value) {
            object[] results = this.Invoke("Ora_Procedure2", new object[] {
                        UpdUser,
                        Proc_Name,
                        Para_Name,
                        Para_Value});
            return ((object)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginOra_Procedure2(string UpdUser, string Proc_Name, string[] Para_Name, string[] Para_Value, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Ora_Procedure2", new object[] {
                        UpdUser,
                        Proc_Name,
                        Para_Name,
                        Para_Value}, callback, asyncState);
        }
        
        /// <remarks/>
        public object EndOra_Procedure2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((object)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CSI_WebService/Service1/Oracle_Direct_Select_Procedure", RequestNamespace="http://tempuri.org/CSI_WebService/Service1", ResponseNamespace="http://tempuri.org/CSI_WebService/Service1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet Oracle_Direct_Select_Procedure(string UpdUser, string StrQty) {
            object[] results = this.Invoke("Oracle_Direct_Select_Procedure", new object[] {
                        UpdUser,
                        StrQty});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginOracle_Direct_Select_Procedure(string UpdUser, string StrQty, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Oracle_Direct_Select_Procedure", new object[] {
                        UpdUser,
                        StrQty}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataSet EndOracle_Direct_Select_Procedure(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }
    }
}
