<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FrmUnidadMedicion.aspx.cs" Inherits="proyectoindicadores2.FrmUnidadMedicion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="container-xl">
            <div class="table-responsive">
                <div class="table-wrapper">
                    <div class="table-title">
                        <div class="row">
                            <div class="col-sm-6">
                                <h2 class="miEstilo">Gestión <b>Unidades de Medición</b></h2>
                            </div>
                            <div class="col-sm-6">
                                <a href="#crudModal" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Gestión Unidades de Medición</span></a>
                            </div>
                        </div>
                    </div>
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Descripción</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% for (int i = 0; i < arregloUnidadesMedicion.Length; i++) { %>
                            <tr>
                                <td><% Response.Write(arregloUnidadesMedicion[i].Id); %></td>
                                <td><% Response.Write(arregloUnidadesMedicion[i].Descripcion); %></td>
                                <td>
                                    <a href="#" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                                </td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <!-- Crud Modal HTML -->
        <div id="crudModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Unidad de Medición</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    </div>
                    <div class="modal-body">
                        <br>
                        <div class="container">
                            <br>
                            <div class="form-group">
                                <label>Id</label>
                                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Descripción</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="BtnGuardar_Click" />
                                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-success" OnClick="BtnConsultar_Click" />
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" OnClick="BtnModificar_Click" />
                                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn-warning" OnClick="BtnBorrar_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
