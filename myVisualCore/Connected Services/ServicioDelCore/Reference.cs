﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace myVisualCore.ServicioDelCore {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WCCajero", Namespace="http://google.com")]
    [System.SerializableAttribute()]
    public partial class WCCajero : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cjr_codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cjr_cedulaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cjr_nombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cjr_apellidoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cjr_telefonoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cjr_direccionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string cjr_codigo {
            get {
                return this.cjr_codigoField;
            }
            set {
                if ((object.ReferenceEquals(this.cjr_codigoField, value) != true)) {
                    this.cjr_codigoField = value;
                    this.RaisePropertyChanged("cjr_codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string cjr_cedula {
            get {
                return this.cjr_cedulaField;
            }
            set {
                if ((object.ReferenceEquals(this.cjr_cedulaField, value) != true)) {
                    this.cjr_cedulaField = value;
                    this.RaisePropertyChanged("cjr_cedula");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string cjr_nombre {
            get {
                return this.cjr_nombreField;
            }
            set {
                if ((object.ReferenceEquals(this.cjr_nombreField, value) != true)) {
                    this.cjr_nombreField = value;
                    this.RaisePropertyChanged("cjr_nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string cjr_apellido {
            get {
                return this.cjr_apellidoField;
            }
            set {
                if ((object.ReferenceEquals(this.cjr_apellidoField, value) != true)) {
                    this.cjr_apellidoField = value;
                    this.RaisePropertyChanged("cjr_apellido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string cjr_telefono {
            get {
                return this.cjr_telefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.cjr_telefonoField, value) != true)) {
                    this.cjr_telefonoField = value;
                    this.RaisePropertyChanged("cjr_telefono");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string cjr_direccion {
            get {
                return this.cjr_direccionField;
            }
            set {
                if ((object.ReferenceEquals(this.cjr_direccionField, value) != true)) {
                    this.cjr_direccionField = value;
                    this.RaisePropertyChanged("cjr_direccion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://google.com", ConfigurationName="ServicioDelCore.CoreWebServiceSoap")]
    public interface CoreWebServiceSoap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://google.com is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://google.com/HelloWorld", ReplyAction="*")]
        myVisualCore.ServicioDelCore.HelloWorldResponse HelloWorld(myVisualCore.ServicioDelCore.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://google.com/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<myVisualCore.ServicioDelCore.HelloWorldResponse> HelloWorldAsync(myVisualCore.ServicioDelCore.HelloWorldRequest request);
        
        // CODEGEN: Generating message contract since element name _WCCajero from namespace http://google.com is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://google.com/InsertCajero", ReplyAction="*")]
        myVisualCore.ServicioDelCore.InsertCajeroResponse InsertCajero(myVisualCore.ServicioDelCore.InsertCajeroRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://google.com/InsertCajero", ReplyAction="*")]
        System.Threading.Tasks.Task<myVisualCore.ServicioDelCore.InsertCajeroResponse> InsertCajeroAsync(myVisualCore.ServicioDelCore.InsertCajeroRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://google.com", Order=0)]
        public myVisualCore.ServicioDelCore.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(myVisualCore.ServicioDelCore.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://google.com", Order=0)]
        public myVisualCore.ServicioDelCore.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(myVisualCore.ServicioDelCore.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://google.com")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertCajeroRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertCajero", Namespace="http://google.com", Order=0)]
        public myVisualCore.ServicioDelCore.InsertCajeroRequestBody Body;
        
        public InsertCajeroRequest() {
        }
        
        public InsertCajeroRequest(myVisualCore.ServicioDelCore.InsertCajeroRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://google.com")]
    public partial class InsertCajeroRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public myVisualCore.ServicioDelCore.WCCajero _WCCajero;
        
        public InsertCajeroRequestBody() {
        }
        
        public InsertCajeroRequestBody(myVisualCore.ServicioDelCore.WCCajero _WCCajero) {
            this._WCCajero = _WCCajero;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertCajeroResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertCajeroResponse", Namespace="http://google.com", Order=0)]
        public myVisualCore.ServicioDelCore.InsertCajeroResponseBody Body;
        
        public InsertCajeroResponse() {
        }
        
        public InsertCajeroResponse(myVisualCore.ServicioDelCore.InsertCajeroResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://google.com")]
    public partial class InsertCajeroResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int InsertCajeroResult;
        
        public InsertCajeroResponseBody() {
        }
        
        public InsertCajeroResponseBody(int InsertCajeroResult) {
            this.InsertCajeroResult = InsertCajeroResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CoreWebServiceSoapChannel : myVisualCore.ServicioDelCore.CoreWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CoreWebServiceSoapClient : System.ServiceModel.ClientBase<myVisualCore.ServicioDelCore.CoreWebServiceSoap>, myVisualCore.ServicioDelCore.CoreWebServiceSoap {
        
        public CoreWebServiceSoapClient() {
        }
        
        public CoreWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CoreWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoreWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoreWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        myVisualCore.ServicioDelCore.HelloWorldResponse myVisualCore.ServicioDelCore.CoreWebServiceSoap.HelloWorld(myVisualCore.ServicioDelCore.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            myVisualCore.ServicioDelCore.HelloWorldRequest inValue = new myVisualCore.ServicioDelCore.HelloWorldRequest();
            inValue.Body = new myVisualCore.ServicioDelCore.HelloWorldRequestBody();
            myVisualCore.ServicioDelCore.HelloWorldResponse retVal = ((myVisualCore.ServicioDelCore.CoreWebServiceSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<myVisualCore.ServicioDelCore.HelloWorldResponse> myVisualCore.ServicioDelCore.CoreWebServiceSoap.HelloWorldAsync(myVisualCore.ServicioDelCore.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<myVisualCore.ServicioDelCore.HelloWorldResponse> HelloWorldAsync() {
            myVisualCore.ServicioDelCore.HelloWorldRequest inValue = new myVisualCore.ServicioDelCore.HelloWorldRequest();
            inValue.Body = new myVisualCore.ServicioDelCore.HelloWorldRequestBody();
            return ((myVisualCore.ServicioDelCore.CoreWebServiceSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        myVisualCore.ServicioDelCore.InsertCajeroResponse myVisualCore.ServicioDelCore.CoreWebServiceSoap.InsertCajero(myVisualCore.ServicioDelCore.InsertCajeroRequest request) {
            return base.Channel.InsertCajero(request);
        }
        
        public int InsertCajero(myVisualCore.ServicioDelCore.WCCajero _WCCajero) {
            myVisualCore.ServicioDelCore.InsertCajeroRequest inValue = new myVisualCore.ServicioDelCore.InsertCajeroRequest();
            inValue.Body = new myVisualCore.ServicioDelCore.InsertCajeroRequestBody();
            inValue.Body._WCCajero = _WCCajero;
            myVisualCore.ServicioDelCore.InsertCajeroResponse retVal = ((myVisualCore.ServicioDelCore.CoreWebServiceSoap)(this)).InsertCajero(inValue);
            return retVal.Body.InsertCajeroResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<myVisualCore.ServicioDelCore.InsertCajeroResponse> myVisualCore.ServicioDelCore.CoreWebServiceSoap.InsertCajeroAsync(myVisualCore.ServicioDelCore.InsertCajeroRequest request) {
            return base.Channel.InsertCajeroAsync(request);
        }
        
        public System.Threading.Tasks.Task<myVisualCore.ServicioDelCore.InsertCajeroResponse> InsertCajeroAsync(myVisualCore.ServicioDelCore.WCCajero _WCCajero) {
            myVisualCore.ServicioDelCore.InsertCajeroRequest inValue = new myVisualCore.ServicioDelCore.InsertCajeroRequest();
            inValue.Body = new myVisualCore.ServicioDelCore.InsertCajeroRequestBody();
            inValue.Body._WCCajero = _WCCajero;
            return ((myVisualCore.ServicioDelCore.CoreWebServiceSoap)(this)).InsertCajeroAsync(inValue);
        }
    }
}